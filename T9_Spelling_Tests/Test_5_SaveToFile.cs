using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_5_SaveToFile
    {
        [Test]
        public void SmallFile()
        {            
            string fileContent = "2" + '\n' + "abc" + '\n' + "";
            string filePath = Test_StaticData.CreateAndFillFile(fileContent);

            ParseT9 parseT9 = new ParseT9() { NeedSaveToFile = false };
            bool res = parseT9.ProcessFileAsync(filePath).Result;
            parseT9.OutFilePath = Path.GetTempFileName();
            parseT9.SaveToFile();

            Assert.That(File.Exists(parseT9.OutFilePath), Is.EqualTo(true));

            File.Delete(filePath);
            File.Delete(parseT9.OutFilePath);
        }

        [Test, Timeout(2000)]
        public void BigFile()
        {
            string fileContent = Test_StaticData.BigFileContent;
            string filePath = Test_StaticData.CreateAndFillFile(fileContent);

            ParseT9 parseT9 = new ParseT9() { NeedSaveToFile = false };
            bool res = parseT9.ProcessFileAsync(filePath).Result;
            parseT9.OutFilePath = Path.GetTempFileName();
            parseT9.SaveToFile();

            string resultHash = Test_StaticData.GetFileHash(parseT9.OutFilePath);
            File.Delete(filePath);
            File.Delete(parseT9.OutFilePath);

            Assert.That(resultHash, Is.EqualTo(Test_StaticData.BigFileHash));
        }
    }
}
