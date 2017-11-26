using System;
using System.Collections.Generic;

namespace Distributions
{
    public class R2
    {
        const int a = 29;
        const int b = 31;
        const double c = 3988;
        public SortedDictionary<int, int> Dic = new SortedDictionary<int, int>();
        public List<int> list = new List<int>();

        ////Для нормальных величин
        private double nn(ref int x)
        {
            double num = (a * x + b) % c;
            x = (int)num;
            return num / c;
        }

        //uniform distribution (R2)
        public void SolveR2(int count, int start, int finish)
        {
            if (count > 0 && start > 0 && finish > 0)
            {
                int x = DateTime.Now.Millisecond;
                for (int i = 0; i < count; i++)
                {
                    double num = (a * nn(ref x) + b) % c;
                    double r = x / c;
                    r = start + (finish - start) * r;
                    list.Add((int)r);
                    try
                    {
                        Dic[(int)r]++;
                    }
                    catch
                    {
                        Dic.Add((int)r, 1);
                    }
                }
            }
            else
                return;
        }
    }
}
