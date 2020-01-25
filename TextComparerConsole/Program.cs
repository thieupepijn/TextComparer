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
                Console.WriteLine("Example: TextComparerConsole \"Cow Pig Chicken\" \"Cow Horse Chicken\" D:\\diff1.html D:\\diff2.html");  
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

                WriteTextToHtmlFile(htmlString1, htmlFilePath1);
                WriteTextToHtmlFile(htmlString2, htmlFilePath2);
               
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void WriteTextToHtmlFile(string text, string filePath)
        {
            string extension = Path.GetExtension(filePath);

            if (!String.Equals(extension, ".html", StringComparison.OrdinalIgnoreCase))
            {
                string message = string.Format("{0} does not have the extension .html", filePath);
                throw new Exception(message);
            }

            try
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.Write(text);
                }
            }
            catch
            {
                string message = string.Format("Problem writing to {0}", filePath);
                throw new Exception(message);
            }
        }
    }

   

}
