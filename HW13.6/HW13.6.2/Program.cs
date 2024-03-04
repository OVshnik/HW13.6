using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;
using HW13_6_2;
using System.Diagnostics;
using System.Windows.Markup;

namespace HW13_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path1 = Path.Combine("C:\\Users\\MSI\\Documents", "Text.txt");

            List<string> values = new();

            string? symbols = File.ReadAllText(path1);
            var array = symbols.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in array)
            {
                values.Add(item);
            }

            var uniqWords = values.ToHashSet();
            Dictionary<string, int> keyValuePairs = new();
            foreach (string word in uniqWords)
            {
                keyValuePairs.Add(word, 0);
            }

            foreach (var i in values)
            {
                foreach (var pair in keyValuePairs)
                {
                    if (i == pair.Key)
                    {
                        keyValuePairs[pair.Key] = pair.Value + 1;
                    }
                }
            }

            var result = keyValuePairs.OrderByDescending(z => z.Value);
            int j = 0;
            Console.WriteLine("10 наиболее распространенных слов в тексте:");
            for (var i = result.ElementAt(j); j < 10; j++)
            {
                Console.WriteLine($" слово ({result.ElementAt(j).Key}) используется {result.ElementAt(j).Value} раз");
            }
        }
    }
}