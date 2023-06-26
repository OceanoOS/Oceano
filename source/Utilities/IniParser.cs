using System;
using System.Collections.Generic;
using System.IO;

namespace Oceano.Utilities
{
    public class IniParser
    {
        private readonly Dictionary<string, Dictionary<string, string>> sections;

        public IniParser()
        {
            sections = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
        }

        public void Parse(string filePath)
        {
            string currentSection = null;
            sections.Clear();

            foreach (var line in File.ReadLines(filePath))
            {
                var trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine[1..^1];
                    sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }
                else if (!string.IsNullOrWhiteSpace(trimmedLine) && !trimmedLine.StartsWith(";"))
                {
                    var separatorIndex = trimmedLine.IndexOf('=');
                    if (separatorIndex >= 0)
                    {
                        var key = trimmedLine[..separatorIndex].Trim();
                        var value = trimmedLine[(separatorIndex + 1)..].Trim();
                        sections[currentSection][key] = value;
                    }
                }
            }
        }

        public string GetValue(string section, string key, string defaultValue = "")
        {
            if (sections.TryGetValue(section, out var sectionData) && sectionData.TryGetValue(key, out var value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}