using System;
using System.Collections.Generic;

namespace Distributions
{
    public class Tri
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

        //triangular distribution (Tri)
        public void SolveTri(int count, double min, double max, double moda)
        {
            if (count > 0 && min > 0 && max > 0 && moda >0)
            {
                int x = DateTime.Now.Millisecond;
                for (int i = 0; i < count; i++)
                {   
                    var h = nn(ref x);
                    if (h >= (moda - min) / (max - min))
                        h = Math.Round(max - Math.Sqrt((max - moda) * (max - min) * (1 - h)));
                    else
                        h = Math.Round(min + Math.Sqrt((moda - min) * (max - min) * h));
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
