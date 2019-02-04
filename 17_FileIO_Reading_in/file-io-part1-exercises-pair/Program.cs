using System;
using System.Collections.Generic;
using System.IO;

namespace file_io_part1_exercises_pair
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Please enter file path.");
            string filePath = Console.ReadLine();

            Console.WriteLine("Please enter file name");
            string fileName = Console.ReadLine();

            string fullPath = Path.Combine(filePath, fileName);

            List<string> allWords = new List<string>();
            List<string> allSentences = new List<string>();
            int sentenceCount = 0;
            try
            {
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line != "")
                        {
                            string[] lineArray = line.Split(' ');
                            allWords.AddRange(lineArray);
                        }
                    }

                }

                using (StreamReader readerSentences = new StreamReader(fullPath))
                {
                    while (!readerSentences.EndOfStream)
                    {

                        string sentence = readerSentences.ReadLine();
                        foreach (char item in sentence)
                        {
                            if (item == '!')
                            {
                                sentenceCount++;
                            }
                            else if (item == '.')
                            {
                                sentenceCount++;
                            }
                            else if (item == '?')
                            {
                                sentenceCount++;
                            }

                        }

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(allWords.Count);
            //Console.WriteLine(allSentences.Count);
            Console.WriteLine(sentenceCount);

            Console.ReadLine();
        }
    }
}
