﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9_SpellingLib
{
    public class ParseT9
    {
        //Параметры запуска
        public bool NeedSaveToFile { get; set; }
        public string FilePath { get; set; }
        public string OutFilePath { get; set; }


        //Итоги
        ConcurrentDictionary<int, string> _resultConcurrentDictionary;
        public ConcurrentDictionary<int, string> ResultConcurrentDictionary {
            get
            {
                _resultConcurrentDictionary = _resultConcurrentDictionary ?? new ConcurrentDictionary<int, string>();
                return _resultConcurrentDictionary;
            }

            private set
            {
                _resultConcurrentDictionary = value;
            }
        }

        //Конструкторы
        public ParseT9()
        {

        }

        public ParseT9(string filePath, string outFilePath)
        {
            FilePath = filePath;
            OutFilePath = outFilePath;

            if (outFilePath != null && outFilePath != "")
            {
                NeedSaveToFile = true;
            }
        }


        //Обработка строки асинхронная
        public async Task<string> ProcessAsync(string s, int i = -1)
        {
            string res = await Task.Run(() => Process(s, i)).ConfigureAwait(false);
            
            return res;
        }

        //Обработка строки простая
        public string Process(string s, int i = -1)
        {
            StringBuilder ret = new StringBuilder();

            if (i != -1)
            {
                ret.Append(StaticData.StartString);
                ret.Append(i);
                ret.Append(StaticData.MiddleString);
            }

            try
            {                
                int prevNumber = -1;
                CharStruct curCs;

                foreach (var item in s)
                {
                    curCs = GetCharStruct(item, prevNumber);
                    ret.Append(curCs.Code);

                    prevNumber = curCs.Number;
                }
            }
            catch (Exception)
            {
                //Ошибка преобразования                
                //Можно логгировать ошибки
                //Сейчас заканчиваем парсить текущую строку - возвращаем что смогли
            }

            //Добавить в результат
            string res = ret.ToString();
            ResultConcurrentDictionary.TryAdd(i, res);

            //Возвращаем то, что смогли преобразовать
            return res;
        }

        //Обработка файла асинхронная
        public async Task<bool> ProcessFileAsync(string filePath = null)
        {
            filePath = filePath ?? FilePath;
            int i = 0;

            try
            {
                // чтение из файла
                using (StreamReader sr = new StreamReader(filePath))
                {
                    //1-строка в файле - кол-во строк в файле
                    string s = sr.ReadLine();
                    int sCnt = Convert.ToInt32(s);
                    ResultConcurrentDictionary = new ConcurrentDictionary<int, string>(sCnt, sCnt);

                    //Набор task'ов
                    List<Task<string>> l = new List<Task<string>>();
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        l.Add(ProcessAsync(s, ++i));
                    }

                    //Ожидаем завершения всех потоков
                    await Task.WhenAll(l);

                    if (NeedSaveToFile && OutFilePath != null && OutFilePath != "")
                    {
                        //Когда все сделали - сохранить в файл
                        if (!SaveToFile())
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }            
        }        

        //Обработка файла простая
        public bool ProcessFile(string filePath = null)
        {
            filePath = filePath ?? FilePath;
            int i = 0;

            try
            {
                //чтение из файла
                using (StreamReader sr = new StreamReader(filePath))
                {
                    //Считываем первую строку файла - по условию задания должна быть числом строк в файле                    
                    string s = sr.ReadLine();
                    int sCnt = Convert.ToInt32(s);

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        Process(s, ++i);                        
                    }

                    if (NeedSaveToFile && OutFilePath != null && OutFilePath != "")
                    {
                        //Когда все сделали - сохранить в файл                        
                        if (!SaveToFile())
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }        

        //Сохранение в файл
        public bool SaveToFile()
        {
            try
            {                            
                int i = ResultConcurrentDictionary.Count;

                using (StreamWriter writer = new StreamWriter(OutFilePath))
                {
                    foreach (var item in ResultConcurrentDictionary.OrderBy(r => r.Key))
                    {                
                        writer.WriteLine(item.Value);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                //Ошибка сохранения в файл
                return false;
            }
        }

        //Получить номер символа
        public string GetCode(char c)
        {
            if (StaticData.CharMeta.ContainsKey(c))
            {
                return StaticData.CharMeta[c].Code;
            }
            else
            {
                return "";
            }
        }

        //Представление символа в зависимости от номера предыдущего символа
        public CharStruct GetCharStruct(char c, int prevNumber = -1)
        {
            CharStruct curMeta;

            if (StaticData.CharMeta.ContainsKey(c))
            {
                curMeta = StaticData.CharMeta[c];

                if (curMeta.Number == prevNumber)
                {
                    curMeta.Code = StaticData.SpaceChar + curMeta.Code;
                }

                return curMeta;
            }
            else
            {
                curMeta = new CharStruct { Code = "", Number = -1 };
            }

            return curMeta;
        }
    }
}
