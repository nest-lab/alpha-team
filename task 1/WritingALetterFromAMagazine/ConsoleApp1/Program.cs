using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 0;
            int colNumber = 100;

            int lineMagazine = 0;
            int colMagazine = 100;
            var letterList = new List<string[]>();
            var foundWord = new List<string[]>();

            int OccurenceInMagazine = 0;
            int OccurenceInLetter = 0;


            List<string> FinalFinding = new List<string>();
            List<string> wasFound = new List<string>();
            using (StreamReader reader = new StreamReader("Letter.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    letterList.Add(line.Split(' '));
                    lineNumber++;
                }
            }

            Console.WriteLine("============================");

            var magazineList = new List<string[]>();

            using (StreamReader reader = new StreamReader("Magazine.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    magazineList.Add(line.Split(' '));
                    lineMagazine++;
                }
            }

            for (int i = 0; i < lineNumber; i++)
            {
                for (int j = 0; j < colNumber; j++)
                {
                    try
                    {
                        //Console.WriteLine(letterList[i][j]);
                        string searchWord = (letterList[i][j]).ToString();
                        for (int a = 0; a < lineMagazine; a++)
                        {
                            for (int b = 0; b < colMagazine; b++)
                            {
                                try
                                {
                                    if ((magazineList[a][b]).Contains(searchWord))
                                    {
                                        Console.WriteLine(searchWord);
                                        wasFound.Add(searchWord);
                                    }
                                    else
                                    {
                                        Console.WriteLine(FinalAnswer());
                                        Console.ReadLine();
                                    }
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {

                    }

                }
            }

            Console.ReadLine();

            string FinalAnswer()
            {
                string result = "The letter Cannot be formed from the Magazine";
                return result;
            }

            foreach (var item in wasFound)
            {
                for (int a = 0; a < lineMagazine; a++)
                {
                    for (int b = 0; b < colMagazine; b++)
                    {
                        try
                        {
                            if ((magazineList[a][b]).Contains(item))
                            {
                                OccurenceInMagazine++;
                            }
                            else
                            {
                                Console.WriteLine(FinalAnswer());
                                Console.ReadLine();
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }

                    for (int i = 0; i < lineNumber; i++)
                    {
                        for (int j = 0; j < colNumber; j++)
                        {
                            try
                            {
                                if ((magazineList[i][j]).Contains(item))
                                {
                                    OccurenceInLetter++;
                                }
                                else
                                {
                                    Console.WriteLine(FinalAnswer());
                                    Console.ReadLine();
                                }
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }

                    if (OccurenceInMagazine == OccurenceInLetter)
                    {
                        FinalFinding.Add(item);
                    }
                    else
                    {
                        Console.WriteLine(FinalAnswer());
                        Console.ReadLine();
                    }

                }

            }
        }
    }
}
  

