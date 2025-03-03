using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualWork3.Core
{
    public class Task4Class
    {
        public int Count(double[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] > arr[0])
                    ++count;
            }
            return count;
        }
    }
}
