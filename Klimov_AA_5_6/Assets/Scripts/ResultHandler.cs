using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Car
{
    public static class ResultHandler
    {
        public static void WriteResult(string name, string result)
        {
            using StreamWriter writer = new StreamWriter(Application.dataPath + "/results.txt", true);
            writer.WriteLine(name + " : " + result);
        }

        public static void FillResultLines(TextMeshProUGUI[] lines)
        {
            SortResults();
            using StreamReader reader = new StreamReader(Application.dataPath + "/results.txt");
            string line;
            int count = 0;
            while ((line = reader.ReadLine()) != null && lines.Length > count)
            {
                lines[count].text = line;
                count++;
            }
        }

        private static void SortResults()
        {
            string[] lines = File.ReadAllLines(Application.dataPath + "/results.txt");
            var separatedLines = lines.Select(line => line.Split(':')).ToList();
            separatedLines = separatedLines.OrderBy(line => Convert.ToInt32(line[1]) * 60 + Convert.ToInt32(line[2]) * 60 + Convert.ToInt32(line[3])).ToList();
            var sortedLines = separatedLines.Select(line => string.Join(":", line));
            File.WriteAllLines(Application.dataPath + "/results.txt", sortedLines);

        }
    }
}
