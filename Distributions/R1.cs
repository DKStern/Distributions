using System.Collections.Generic;

namespace Distributions
{
    public class R1
    {
        const int a = 29;
        const int b = 31;
        const int c = 3988;
        public SortedDictionary<int, int> Dic = new SortedDictionary<int, int>();
        public List<int> list = new List<int>();

        //uniform distribution (R1)
        public void SolveR1(int count, int start)
        {
            if (count > 0 && start > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    double num = (a * start + b) % c;
                    list.Add((int)num);
                    try
                    {
                        Dic[(int)num]++;
                    }
                    catch
                    {
                        Dic.Add((int)num, 1);
                    }
                    start = (int)num;
                }
            }
            else
                return;
        }
    }
}
