using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_0_Start
    {
        [Test]
        public void StaticData_CharMeta_Fill()
        {
            Assert.That(StaticData.CharMeta.Count, Is.EqualTo(27));
        }

        [Test]
        public void ParseT9Constructor_WithoutPars()
        {
            ParseT9 parseT9 = new ParseT9();

            Assert.IsNotNull(parseT9);
        }

        [Test]
        public void ParseT9Constructor_FilePath()
        {
            string path = "1";            

            ParseT9 parseT9 = new ParseT9(path, null);

            Assert.That(parseT9.FilePath, Is.EqualTo(path));
        }

        [Test]
        public void ParseT9Constructor_OutFilePath()
        {
            string path = "1";

            ParseT9 parseT9 = new ParseT9(null, path);

            Assert.That(parseT9.OutFilePath, Is.EqualTo(path));
        }

        [Test]
        public void ParseT9_NeedSaveToFile()
        {
            ParseT9 parseT9 = new ParseT9();

            parseT9.NeedSaveToFile = true;

            Assert.That(parseT9.NeedSaveToFile, Is.EqualTo(true));
        }

        [Test]
        public void ParseT9_Dictionary()
        {
            ParseT9 parseT9 = new ParseT9();

            Assert.IsNotNull(parseT9.ResultConcurrentDictionary);            
        }
    }
}
