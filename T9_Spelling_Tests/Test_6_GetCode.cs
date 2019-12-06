using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_6_GetCode
    {
        [Test]
        public void GoodChar()
        {
            ParseT9 parseT9 = new ParseT9();
            
            string code = parseT9.GetCode('a');

            Assert.That(code, Is.EqualTo("2"));
        }

        [Test]
        public void BadChar()
        {
            ParseT9 parseT9 = new ParseT9();

            string code = parseT9.GetCode('$');

            Assert.That(code, Is.EqualTo(""));
        }
    }
}
