using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChart_Kastenhofer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ChartEntry> chartEntries = new List<ChartEntry>();

            var categories = Console.ReadLine().Split('\t');

            var groupingColIdx = Array.IndexOf(categories, args[0]);
            var numericColIdx = Array.IndexOf(categories, args[1]);
            var entryCount = Convert.ToInt32(args[2]);  


            //Read from inputfile
            while (true)
            {
                var currentLine = Console.ReadLine();
                if (string.IsNullOrEmpty(currentLine))
                    break;

                var lineSplitted = currentLine.Split('\t');

                chartEntries.Add(new ChartEntry(lineSplitted[groupingColIdx], Convert.ToInt32(lineSplitted[numericColIdx])));
            }

            //Write output

            var groupedEntries = chartEntries.GroupBy(entry => entry.EntryTitle)
                                 .Select(entry => new ChartEntry(entry.Key, entry.Sum(e => e.EntryCount)))
                                 .OrderByDescending(entry => entry.EntryCount)
                                 .ToList();

            int highestAttackCount = groupedEntries.Max(entry => entry.EntryCount);
            var count = 0;
            foreach (var entry in groupedEntries)
            {

                var percentage = (int) ((double) entry.EntryCount / highestAttackCount * 100);
                
                Console.Write($"{entry.EntryTitle,-40} |");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ GetBarForPercentage(percentage)}");
                Console.ForegroundColor = ConsoleColor.Gray;

                if (count == entryCount)
                {
                    break;
                }
                count++;
            }
        }

        static String GetBarForPercentage(int percentage)
        {
            return new string('█', percentage) + new string(' ', (100 - percentage));
        }
    }
}
