using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synapse_X_Remake
{
    internal class TopMost
    {
        public static bool topMost;

        public TopMost(bool topMost)
        {
            Topmost = topMost;
        }

        private bool Topmost
        {
            set
            {
                topMost = value;
            }

            get
            {
                return topMost;
            }
        }
    }
}
