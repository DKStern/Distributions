using System;
using System.Collections.Generic;

namespace Distributions
{
    public class N
    {
        const int a = 29;
        const int b = 31;
        const double c = 3988;
        public SortedDictionary<int, int> Dic = new SortedDictionary<int, int>();
        public List<int> list = new List<int>();


        //Для нормальных величин
        private double nn(ref int x)
        {
            double num = (a * x + b) % c;
            x = (int)num;
            return num / c;
        }

        //Normal distribution (N)
        public void SolveN(int count, double M, double D)
        {
            if (count > 0 && M > 0 && D > 0)
            {
                int x = DateTime.Now.Millisecond;
                for (int i = 0; i < count; i++)
                {
                    double help_1 = Math.Sin(2.0 * Math.PI * nn(ref x)) * Math.Sqrt(-2.0 * Math.Log(nn(ref x)));
                    double help_2 = M + D * help_1;

                    list.Add((int)help_2);
                    try
                    {
                        Dic[(int)help_2]++;
                    }
                    catch
                    {
                        Dic.Add((int)help_2, 1);
                    }
                }
            }
            else
                return;
        }
    }
}
