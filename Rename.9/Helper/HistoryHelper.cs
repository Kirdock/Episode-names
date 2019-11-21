using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode_Names.Helper
{
    class HistoryHelper
    {
        private int Counter = 0;
        private readonly List<List<HistoryEntry>> History = new List<List<HistoryEntry>>();

        internal struct HistoryEntry
        {
            internal string OldValue, NewValue;
            internal HistoryEntry(string oldValue, string newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
        }

        internal void Add(List<HistoryEntry> entry)
        {
            while(Counter < History.Count)
            {
                History.RemoveAt(History.Count - 1);
            }
            History.Add(entry);
            Counter++;
        }

        internal bool Back(out List<HistoryEntry> result)
        {
            bool status;
            if(status = (Counter > 0))
            {
                Counter--;
                result = ReverseHistory(GetEntry());
            }
            else
            {
                result = null;
            }
            return status;
        }

        private List<HistoryEntry> ReverseHistory(List<HistoryEntry> history)
        {
            List<HistoryEntry> result = new List<HistoryEntry>();
            for(int i = history.Count-1; i >= 0; i--)
            {
                result.Add(new HistoryEntry(history[i].NewValue, history[i].OldValue));
            }

            return result;
        }

        internal bool Forward(out List<HistoryEntry> result)
        {
            bool status;
            if (status = (Counter < History.Count))
            {
                result = GetEntry();
                Counter++;
            }
            else
            {
                result = null;
            }
            return status;
        }

        private List<HistoryEntry> GetEntry()
        {
            return History[Counter];
        }
    }
}
