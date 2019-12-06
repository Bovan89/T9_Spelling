using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9_SpellingLib
{
    public class StaticData
    {
        public static readonly char SpaceChar = ' ';

        public static readonly string StartString = "Case #";
        public static readonly string MiddleString = ": ";

        //Если начальные условия статичны, почему бы для быстроты выполнения не запихать их в статичную структуру?
        public static readonly Dictionary<char, CharStruct> CharMeta = new Dictionary<char, CharStruct>
        {
            {'a', new CharStruct() { Number = 2, Code = "2"} }, {'b', new CharStruct() { Number = 2, Code = "22"} }, {'c', new CharStruct() { Number = 2, Code = "222"} },
            {'d', new CharStruct() { Number = 3, Code = "3"} }, {'e', new CharStruct() { Number = 3, Code = "33"} }, {'f', new CharStruct() { Number = 3, Code = "333"} },
            {'g', new CharStruct() { Number = 4, Code = "4"} }, {'h', new CharStruct() { Number = 4, Code = "44"} }, {'i', new CharStruct() { Number = 4, Code = "444"} },
            {'j', new CharStruct() { Number = 5, Code = "5"} }, {'k', new CharStruct() { Number = 5, Code = "55"} }, {'l', new CharStruct() { Number = 5, Code = "555"} },
            {'m', new CharStruct() { Number = 6, Code = "6"} }, {'n', new CharStruct() { Number = 6, Code = "66"} }, {'o', new CharStruct() { Number = 6, Code = "666"} },
            {'p', new CharStruct() { Number = 7, Code = "7"} }, {'q', new CharStruct() { Number = 7, Code = "77"} }, {'r', new CharStruct() { Number = 7, Code = "777"} }, {'s', new CharStruct() { Number = 7, Code = "7777"} },
            {'t', new CharStruct() { Number = 8, Code = "8"} }, {'u', new CharStruct() { Number = 8, Code = "88"} }, {'v', new CharStruct() { Number = 8, Code = "888"} },
            {'w', new CharStruct() { Number = 9, Code = "9"} }, {'x', new CharStruct() { Number = 9, Code = "99"} }, {'y', new CharStruct() { Number = 9, Code = "999"} }, {'z', new CharStruct() { Number = 9, Code = "9999"} },
            {' ', new CharStruct() { Number = 0, Code = "0"} }
        };        
    }

    public struct CharStruct
    {
        public int Number;
        public string Code;
    }
}

