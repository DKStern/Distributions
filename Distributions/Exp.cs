using System;
using System.Collections.Generic;

namespace Distributions
{
    public class Exp
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

        //Exp distribution (Exp)
        public void SolveExp(int count, double M)
        {
            if (count > 0 && M > 0)
            {
                int x = DateTime.Now.Millisecond;
                for (int i = 0; i < count; i++)
                {
                    double chis = -Math.Log(nn(ref x)) * M;

                    list.Add((int)chis);
                    try
                    {
                        Dic[(int)chis]++;
                    }
                    catch
                    {
                        Dic.Add((int)chis, 1);
                    }
                }
            }
            else
                return;
        }
    }
}
