using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualWork3.Core
{
    public class Task2Class
    {
        private double _t;
        private double _l;

        public Task2Class(double t, double l)
        {
            _t = t;
            _l = l;
        }

        public double print()
        {
            return 3 * Math.Pow(_t, 2) + 3 * Math.Pow(_l, 5) + 4.9;
        }
    }
}
