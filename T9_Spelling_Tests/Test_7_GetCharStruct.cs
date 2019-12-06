using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_7_GetCharStruct
    {
        [Test]
        public void GoodChar()
        {
            ParseT9 parseT9 = new ParseT9();

            CharStruct s = parseT9.GetCharStruct('a');

            Assert.That(s.Code, Is.EqualTo("2"));
        }

        [Test]
        public void BadChar()
        {
            ParseT9 parseT9 = new ParseT9();

            CharStruct s = parseT9.GetCharStruct('%');

            Assert.That(s.Code, Is.EqualTo(""));
        }
    }
}
