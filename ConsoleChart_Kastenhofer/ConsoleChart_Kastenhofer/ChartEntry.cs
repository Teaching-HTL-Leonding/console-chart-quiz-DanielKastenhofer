using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChart_Kastenhofer
{
    class ChartEntry
    {

        public ChartEntry(string entryTitle, int entryCount)
        {
            EntryTitle = entryTitle;
            EntryCount = entryCount;
        }

        public string EntryTitle { get; }

        public int EntryCount { get; }
    }
}
