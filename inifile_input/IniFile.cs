using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inifile_input
{
    public class IniFile
    {
        private Dictionary<string, Dictionary<string, string>> data;

        public IniFile()
        {
            data = new Dictionary<string, Dictionary<string, string>>();
        }

        public void Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            string currentSection = null;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    if (!data.ContainsKey(currentSection))
                        data[currentSection] = new Dictionary<string, string>();
                }
                else if (!string.IsNullOrEmpty(trimmedLine))
                {
                    int equalsIndex = trimmedLine.IndexOf("=");
                    if (equalsIndex >= 0)
                    {
                        string key = trimmedLine.Substring(0, equalsIndex).Trim();
                        string value = trimmedLine.Substring(equalsIndex + 1).Trim();
                        if (!string.IsNullOrEmpty(key))
                            data[currentSection][key] = value;
                    }
                }
            }
        }

        public string GetValue(string section, string key)
        {
            if (data.ContainsKey(section) && data[section].ContainsKey(key))
                return data[section][key];

            return null;
        }
    }
}
