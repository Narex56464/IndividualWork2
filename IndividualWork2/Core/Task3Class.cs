using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualWork3.Core
{
    public class Task3Class
    {
        private double _p;
        private double _y;

        public Task3Class(double p, double y)
        {
            _p = p;
            _y = y;
        }

        public double print()
        {
            return Math.Log10(Math.Pow(_p, 2) + Math.Pow(_y, 3)) + Math.Exp(_p);
        }
    }
}
