using System;

namespace Functions.Base
{
    public class TestImplementationBase
    {
        readonly Random _rnd = new Random();
        private int _listItemHelper = 0;
        
        protected int DoComplicatedProcessing(int i)
        {
            if (i < 0) throw new ArgumentException("Argument cannot be negative");
            return 10 / i;
        }

        protected void Log(string msg, Exception ea)
        {
            //Do nothing
        }

        protected void Log(string v)
        {
            //do nothing
        }

        protected string GetNextList1Item()
        {
            return GetNextListItem();
        }

        protected string GetNextList2Item()
        {
            return GetNextListItem();
        }

        protected string GetNextList3Item()
        {
            return GetNextListItem();
        }

        private string GetNextListItem()
        {
            int arg;
            int next = _rnd.Next(2);
            if (next == 0)
            {
                arg = _listItemHelper;
            }
            else
            {
                _listItemHelper++;
                arg = _listItemHelper;
            }
            return string.Format("{0}", arg);
        }
    }
}