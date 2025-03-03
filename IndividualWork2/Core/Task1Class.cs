using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualWork3.Core
{
    public class Task1Class
    {
        private int A;
        private int B;

        public Task1Class(int a, int b)
        {
            A = a;
            B = b;
        }

        public bool ExpA()
        {
            return (A % 2 == 0 && B % 2 != 0) || (A % 2 != 0 && B % 2 == 0);
        }

        public bool ExpB(int C)
        {
            return (A % 3 == 0) && (B % 3 == 0) && (C % 3 == 0);
        }
    }
}
