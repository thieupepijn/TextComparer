using System;
using System.Collections.Generic;
using System.IO;
using TextComparer;

namespace TextComparerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length < 4)
            {
                Console.WriteLine("Shows the difference of 2 strings with 2 html-pages");
                Console.WriteLine("Usage: TextComparerConsole string1 string2 HTMLfilePath1 HTMLfilePath2");
                return;
            }

            try
            {
                string text1 = args[0];
                string text2 = args[1];

                string htmlFilePath1 = args[2];
                string htmlFilePath2 = args[3];

                string[] textArray1 = UtilDiffExtra.WordsFromText(text1);
                string[] textArray2 = UtilDiffExtra.WordsFromText(text2);

                List<UtilDiff.commonOrDifferentThing> differenceList = UtilDiff.diff_comm(textArray1, textArray2);

                string htmlString1 = string.Empty;
                string htmlString2 = string.Empty;
                UtilDiffExtra.DiffCommonList2MarkedUpStrings(differenceList, ref htmlString1, ref htmlString2);

                WriteTextToFile(htmlString1, htmlFilePath1);
                WriteTextToFile(htmlString2, htmlFilePath2);
               
                
            }
            catch
            {

            }
        }

        private static void WriteTextToFile(string text, string filePath)
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.Write(text);
            }
        }

    }
}
