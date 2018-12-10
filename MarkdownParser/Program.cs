using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarkdownParser
{
    class Program
    {
        private static string mdFileName = "ReleaseHistory.md";
        private static Regex versionExp = new Regex(@"##\s?\b\d{1,3}\.\d{1,3}\.\d{1,3}\b");

        static void Main(string[] args)
        {
            GetReleaseHistory();
        }

        static void GetReleaseHistory()
        {
            string line;
            Dictionary<string, string> vrnHistory = new Dictionary<string, string>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file = null;
            try
            {
                file = new System.IO.StreamReader(mdFileName);
                var key = string.Empty;
                var value = string.Empty;

                while ((line = file.ReadLine()) != null)
                {
                    Match m = versionExp.Match(line);
                    if (m.Success)
                    {
                        key = line;
                        value = string.Empty;
                        vrnHistory.Add(key, value);
                    }
                    else
                    {
                        vrnHistory[key] = value += line;
                    }
                }
            }

            finally
            {
                file?.Close();
            }
        }
    }
}
