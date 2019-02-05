using System;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doesFileExist = false;
            string fileName = "";
            string filePath = "";
            string fullPath = "";


            while (doesFileExist != true)
            {
                Console.WriteLine("Please enter the file path: ");                      //prompt for filepath
                filePath = Console.ReadLine();
                Console.WriteLine("Please enter the file name: ");                      //prompt for filename
                fileName = Console.ReadLine();
                fullPath = Path.Combine(filePath, fileName);
                doesFileExist = File.Exists(fullPath);

                if (doesFileExist == false)                                             //checks to see if file exists at that path
                {
                    Console.WriteLine("That file name or path is incorrect");
                }
            }

            Console.WriteLine("Please enter the name for the copy: ");
            string returnPath = Console.ReadLine();

            string returnFullPath = Path.Combine(filePath, returnPath);

            if (File.Exists(returnFullPath) == true)
            {
                Console.WriteLine("This File name already exists");
                Console.ReadLine()
                System.Environment.Exit(0);
            }


            Console.WriteLine("Please enter your search phrase: ");
            string searchPhrase = Console.ReadLine();
            Console.WriteLine("What would you like the search phrase to be replaced with? ");
            string replacementPhrase = Console.ReadLine();
            int counter = 0;
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    using (StreamWriter sw = new StreamWriter(returnFullPath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line.Contains(searchPhrase))
                            {
                                counter++;
                            }

                            line = line.Replace(searchPhrase, replacementPhrase);
                            sw.WriteLine(line);

                        }
                        Console.WriteLine($"There have been {counter} changes");
                        Console.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("There is no file that exists by that name");

            }
        }
    }
}


