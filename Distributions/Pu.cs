using System;
using System.Collections.Generic;

namespace Distributions
{
    public class Pu
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

        //Poisson distribution (Pu)
        public void SolvePu(int count, double L)
        {
            if (count > 0 && L>0)
            {
                int x = DateTime.Now.Millisecond;
                for (int i = 0; i < count; i++)
                {
                    int index = 0;
                    double help_1 = Math.Exp(-L);
                    double help_2 = nn(ref x);

                    while (help_2 > 0)
                    {
                        help_1 = help_1 * L / (index + 1);
                        ++index;
                        help_2 -= help_1;
                    }

                    list.Add((int)index);
                    try
                    {
                        Dic[(int)index]++;
                    }
                    catch
                    {
                        Dic.Add((int)index, 1);
                    }
                }
            }
            else
                return;
        }
    }
}
