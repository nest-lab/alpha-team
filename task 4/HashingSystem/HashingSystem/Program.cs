using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] separators = new char[] { ' ', ',', '.' };
            string[] beersArr = text.Split(separators);

            var newtext = new Regex("#");
            foreach (var item in beersArr)
            {
                var matches = newtext.Matches(item);
                if (matches != null)
                {
                    foreach (Match m in matches)
                    {
                        Console.WriteLine("The hashing works and this is it:");
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("No hash tagging system");
                }
                
            }
           
            Console.ReadLine();
        }
    }
}
