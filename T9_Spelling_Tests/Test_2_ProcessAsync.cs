using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_2_ProcessAsync
    {
        [Test]
        public void OneChar()
        {
            ParseT9 parseT9 = new ParseT9();

            string res = parseT9.ProcessAsync("a").Result;

            Assert.That(res, Is.EqualTo("2"));
        }

        [Test]
        public void AllChars()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.ProcessAsync("abcdefghijklmnopqrstuvwxyz").Result;

            Assert.That(res, Is.EqualTo("2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 9999"));
        }

        [Test, Timeout(2000)]
        public void ManyChars()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.ProcessAsync("abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz ").Result;

            Assert.That(res, Is.EqualTo("2 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 999902 22 2223 33 3334 44 4445 55 5556 66 6667 77 777 77778 88 8889 99 999 99990"));
        }

        [Test]
        public void WithPrefix()
        {
            ParseT9 parseT9 = new ParseT9();
            string res = parseT9.ProcessAsync("abc", 1).Result;

            Assert.That(res, Is.EqualTo(StaticData.StartString + "1" + StaticData.MiddleString + "2 22 222"));
        }
    }
}
