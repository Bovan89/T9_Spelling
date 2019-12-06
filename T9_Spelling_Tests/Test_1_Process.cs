using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{    
    public class Test_1_Process
    {
        [Test]
        public void OneChar()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("a");

            Assert.That(res, Is.EqualTo("2"));
        }

        [Test]
        public void OneBadChar()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("1");

            Assert.That(res, Is.EqualTo(""));
        }

        [Test]
        public void WithPrefix()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("abc", 1);

            Assert.That(res, Is.EqualTo(StaticData.StartString + "1" + StaticData.MiddleString + "2 22 222"));
        }

        [Test]
        public void ManyChars()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("hello world");

            Assert.That(res, Is.EqualTo("4433555 555666096667775553"));
        }

        [Test]
        public void AllCharsSpaces()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("a b c d e f g h i j k l m n o p q r s t u v w x y z ");

            Assert.That(res, Is.EqualTo("2022022203033033304044044405055055506066066607077077707777080880888090990999099990"));
        }

        [Test]
        public void AllChars()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("abcdefghijklmnopqrstuvwxyz");

            Assert.That(res, Is.EqualTo("2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 9999"));
        }                

        [Test, Timeout(2000)]
        public void LongRunning()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.Process("abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz ");

            Assert.That(res, Is.EqualTo("2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 99990"));
        }
    }
}
