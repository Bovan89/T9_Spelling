using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_3_ProcessFile
    {
        [Test]
        public void BadFilePathFile()
        {
            ParseT9 parseT9 = new ParseT9();

            bool res = parseT9.ProcessFile("");

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void EmptyFile()
        {
            string filePath = CreateAndFillFile("");
            ParseT9 parseT9 = new ParseT9();            

            bool res = parseT9.ProcessFile(filePath);

            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void FileWithoutStringNumbers()
        {
            string filePath = CreateAndFillFile("abc");
            ParseT9 parseT9 = new ParseT9();                        

            bool res = parseT9.ProcessFile(filePath);

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void SmallFile()
        {
            string fileContent = "2" + '\n' + "abc" + '\n' + "";
            string filePath = CreateAndFillFile(fileContent);
            ParseT9 parseT9 = new ParseT9();

            bool res = parseT9.ProcessFile(filePath);

            string retStr;
            parseT9.ResultConcurrentDictionary.TryGetValue(1, out retStr);

            File.Delete(filePath);

            Assert.That(retStr, Is.EqualTo(StaticData.StartString + "1" + StaticData.MiddleString + "2 22 222"));
        }

        [Test, Timeout(2000)]
        public void BigFile()
        {            
            string filePath = CreateAndFillFile(Test_StaticData.BigFileContent);
            string outFilePath = CreateAndFillFile();

            ParseT9 parseT9 = new ParseT9(filePath, outFilePath);
            bool res = parseT9.ProcessFile();

            //Сравниваем с эталонным хэшем файла - означает что конвертировали правильно            
            string resultHash = FileHash(outFilePath);

            File.Delete(filePath);
            File.Delete(outFilePath);

            Assert.That(resultHash, Is.EqualTo(Test_StaticData.BigFileHash));
        }

        //создать файл
        private string CreateAndFillFile(string text = null)
        {
            string path = Path.GetTempFileName();
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter file = new StreamWriter(path))
            {
                if (text != null && text != "")
                {
                    file.Write(text);
                    file.Close();
                }
            }

            return path;
        }

        private string FileHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }        
    }
}
