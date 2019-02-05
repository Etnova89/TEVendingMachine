using System;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the file path: ");
            string filePath = Console.ReadLine();
            Console.WriteLine("Please enter the file name: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Please enter the return file path: ");
            string returnPath = Console.ReadLine();
            string fullPath = Path.Combine(filePath, fileName);
            string returnFullPath = Path.Combine(filePath, returnPath);


            Console.WriteLine("Please enter your search phrase: ");
            string searchPhrase = Console.ReadLine();
            Console.WriteLine("What would you like the search phrase to be replaced with? ");
            string replacementPhrase = Console.ReadLine();

            using (StreamReader sr = new StreamReader(fullPath))
            {
                using (StreamWriter sw = new StreamWriter(returnFullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        line = line.Replace(searchPhrase, replacementPhrase);
                        sw.WriteLine(line);
                    }
                }
            }
        }

    }
}

