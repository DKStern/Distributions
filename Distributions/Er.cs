using System;
using System.Collections.Generic;

namespace Distributions
{
    public class Er
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

        //Erlang's distribution (Er)
        public void SolveEr(int count, double moda, int countOfNormal)
        {
            if (count > 0 && moda > 0 && countOfNormal > 0)
            {
                double h;
                int x = DateTime.Now.Millisecond;
                for (int k = 0; k < count; k++)
                {
                    h = 1.0;
                    for (int i = 1; i <= countOfNormal; i++)
                        h *= nn(ref x);

                    h = -moda * Math.Log(h);
                    list.Add((int)h);
                    try
                    {
                        Dic[(int)h]++;
                    }
                    catch
                    {
                        Dic.Add((int)h, 1);
                    }
                }
            }
            else
                return;
        }
    }
}
