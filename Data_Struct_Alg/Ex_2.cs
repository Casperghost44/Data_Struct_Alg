using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Data_Struct_Alg_Les_04
{
    public static class Ex_2
    {
        public static string Input()
        {
            string input = GetFileTextContent("../../../input_2.txt");
            char[] trimch = new char[] { '{', '}', ' '};
            string inp = input.Trim(trimch);
            return inp;

        }
        public static string GetFileTextContent(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("File does not exist. File name: " + fullPath);
            }

            string textContent = string.Empty;

            using (var reader = new StreamReader(fullPath))
            {
                textContent = reader.ReadToEnd();
            }

            return textContent;
        }
        public static void Run()
        {
            string input = Input();
            SortedDictionary<string, int> output = Count(input);
            Output(output);
        }
        private static SortedDictionary<string, int> Count(string input)
        {
            char[] separetors = new char[] { ',' };
            string[] arr = input.Split(separetors);
            SortedDictionary<string, int> numCount = new SortedDictionary<string, int>();
            foreach (string num in arr)
            {
                int count = 1;
                if (numCount.ContainsKey(num))
                    count = numCount[num] + 1;
                numCount[num] = count;
            }
            return numCount;

        }
        public static void Output(SortedDictionary<string, int> output)
        {
            Console.Write("{");
            foreach (var pair in output)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.Write(pair.Key + ", ");
                }
            }
            Console.Write("}");

        }
    }
}

