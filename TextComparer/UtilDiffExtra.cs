using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace TextComparer
{
    public class UtilDiffExtra
    {

        public static void DiffCommonList2MarkedUpStrings(List<UtilDiff.commonOrDifferentThing> listDiffCommon, ref string markedUpString1, ref string markedUpString2)
        {
            StringBuilder sbMarkedUp1 = new StringBuilder();
            StringBuilder sbMarkedUp2 = new StringBuilder();

            foreach (UtilDiff.commonOrDifferentThing commonORdifferent in listDiffCommon)
            {
                if ((commonORdifferent.common != null) && (commonORdifferent.common.Count > 0))
                {
                    string rawstring = StringList2String(commonORdifferent.common);
                    string bufMarkedUpString = PutStringInFont(rawstring, "green");
                    sbMarkedUp1.Append(bufMarkedUpString);
                    sbMarkedUp2.Append(bufMarkedUpString);
                }
                else
                {
                    if ((commonORdifferent.file1 != null) && (commonORdifferent.file1.Count > 0))
                    {
                        string rawstring = StringList2String(commonORdifferent.file1);
                        string bufMarkedUpString = PutStringInFont(rawstring, "red");
                        sbMarkedUp1.Append(bufMarkedUpString);
                    }

                    if ((commonORdifferent.file2 != null) && (commonORdifferent.file2.Count > 0))
                    {
                        string rawstring = StringList2String(commonORdifferent.file2);
                        string bufMarkedUpString = PutStringInFont(rawstring, "red");
                        sbMarkedUp2.Append(bufMarkedUpString);
                    }
                }

            }

            markedUpString1 = sbMarkedUp1.ToString();
            markedUpString2 = sbMarkedUp2.ToString();
        }

        public static string[] WordsFromText(string inputString)
        {
            string[] wordsArray = inputString.Split(" ".ToCharArray());
            List<string> listOut = wordsArray.ToList<string>();
            listOut.RemoveAll(string.IsNullOrWhiteSpace);
            return listOut.ToArray();
        }


        private static string StringList2String(List<string> listStrings)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string stringetje in listStrings)
            {
                sb.Append(stringetje);
                // sb.Append("&nbsp;");
                sb.Append(" ");
            }
            return sb.ToString();
        }

        private static string PutStringInFont(string stringetje, string colorName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<FONT COLOR=\"");
            sb.Append(colorName);
            sb.Append("\"");
            sb.Append(">");
            sb.Append(stringetje);
            sb.Append("</FONT>");
            return sb.ToString();
        }

        public static string ReplaceNewLines(string code)
        {
            code = code.Replace(System.Environment.NewLine, "<BR/>");
            return code;
        }

    }
}