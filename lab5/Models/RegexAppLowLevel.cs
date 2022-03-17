using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using lab5.Models;

namespace MyRegex
{

    // \b\w+es\b
    class RegexAppLowLevel
    {
        public static string LoadFromFile(string? filename)
        {
            string fileContent = "";

            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        fileContent += s;
                    }
                }
            }
            else throw new MyRegexException("Файл не найден");
            return fileContent;
        }

        public static void SaveFromFile(string? filename, string? content)
        {
            string fileContent = "";

            if (File.Exists(filename))
            {
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(content);
                }
            }
            else throw new MyRegexException("Файл не найден");
        }
        public static string OutputDataByTemplate(string? str, string pattern)
        {
            if (pattern == null)
                pattern = "";
            if (str == null)
                str = "";
            Regex regex = new Regex(pattern);
            string NewRegexByLine = "";
            foreach (Match c in regex.Matches(str))
            {
                GroupCollection groups = c.Groups;
                NewRegexByLine += groups[0].Value + "\n";
            }
            return NewRegexByLine;
        }
    }
}
