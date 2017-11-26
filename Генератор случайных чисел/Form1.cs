using System;
using System.Windows.Forms;
using Distributions;

namespace Генератор_случайных_чисел
{
    public partial class Generator : Form
    {
        public Generator()
        {
            InitializeComponent();
        }

        //Решение R1
        private void R1()
        {
            int f;
            if (Int32.TryParse(R1CountBox.Text, out f) && ((Int32.TryParse(R1StartBox.Text, out f) && f>0) || R1Check.Checked))
            {
                R1Box.Items.Clear();
                chartR1.Series["Числа"].Points.Clear();
                chartR1.Series["График"].Points.Clear();
                double x;
                if (R1Check.Checked)
                {
                    x = DateTime.Now.Millisecond;
                    R1StartBox.Text = Convert.ToString(x);
                }
                else
                    x = Convert.ToInt32(R1StartBox.Text);
                int n = Convert.ToInt32(R1CountBox.Text);
                if (n > 0 && x > 0)
                {
                    R1 r1 = new R1();
                    r1.SolveR1(n, (int)x);

                    for (int i=0;i<r1.list.Count;i++)
                    {
                        R1Box.Items.Add(r1.list[i]);
                    }
                    foreach (var i in r1.Dic)
                    {
                        chartR1.Series["График"].Points.AddXY(i.Key,i.Value);
                        chartR1.Series["Числа"].Points.AddXY(i.Key, i.Value);
                    }
                }
            }
        }


        //Решение R2
        private void R2()
        {
            int q, w, e;
            if (Int32.TryParse(R2CountBox.Text, out q) && Int32.TryParse(ABox.Text, out w) && Int32.TryParse(BBox.Text, out e) && q > 0 && w > 0 && e > 0 && e > w)
            {
                R2Box.Items.Clear();
                chartR2.Series["Числа"].Points.Clear();
                chartR2.Series["График"].Points.Clear();

                int A = Convert.ToInt32(ABox.Text), B = Convert.ToInt32(BBox.Text); ;
                int n = Convert.ToInt32(R2CountBox.Text);
                R2 r2 = new R2();
                r2.SolveR2(n, A, B);

                for (int i = 0; i < r2.list.Count; i++)
                {
                    R2Box.Items.Add(r2.list[i]);
                }
                foreach (var i in r2.Dic)
                {
                    chartR2.Series["График"].Points.AddXY(i.Key, i.Value);
                    chartR2.Series["Числа"].Points.AddXY(i.Key, i.Value);
                }
            }
        }

        //Решение Tri
        private void Tri()
        {
            int q, w, e, r;
            if (Int32.TryParse(TriCountBox.Text, out q) && Int32.TryParse(TriMax.Text, out w) && Int32.TryParse(TriMin.Text, out e) && Int32.TryParse(TriModa.Text, out r) && q > 0)
            {
                TriBox.Items.Clear();
                chartTri.Series["Числа"].Points.Clear();
                chartTri.Series["График"].Points.Clear();

                int x = DateTime.Now.Millisecond;
                int n = Convert.ToInt32(TriCountBox.Text);
                double min = Convert.ToInt32(TriMin.Text), max = Convert.ToInt32(TriMax.Text), moda = Convert.ToInt32(TriModa.Text);

                if (moda >= max || moda <= min)
                {
                    moda = Math.Round((min + max) / 2.0);
                    TriModa.Text = Convert.ToString(moda);
                }

                Tri tri = new Tri();
                tri.SolveTri(n, min, max, moda);

                for (int i = 0; i < tri.list.Count; i++)
                {
                    TriBox.Items.Add(tri.list[i]);
                }
                foreach (var i in tri.Dic)
                {
                    chartTri.Series["График"].Points.AddXY(i.Key, i.Value);
                    chartTri.Series["Числа"].Points.AddXY(i.Key, i.Value);
                }
            }
        }

        //Решение Эрланга 
        private void Er()
        {
            int f, g;
            if (Int32.TryParse(ErCountBox.Text, out g) && g > 0 && Int32.TryParse(ErModa.Text, out f) && f > 0)
            {
                ErBox.Items.Clear();
                chartEr.Series["Числа"].Points.Clear();
                chartEr.Series["График"].Points.Clear();

                int n = Convert.ToInt32(ErCountBox.Text);
                int count = (int)ErCountNormal.Value;
                double moda = Double.Parse(ErModa.Text);

                Er er = new Er();
                er.SolveEr(n, moda, count);

                for (int i = 0; i < er.list.Count; i++)
                {
                    ErBox.Items.Add(er.list[i]);
                }
                foreach (var i in er.Dic)
                {
                    chartEr.Series["График"].Points.AddXY(i.Key, i.Value);
                    chartEr.Series["Числа"].Points.AddXY(i.Key, i.Value);
                }
            }
        }

        //Решение Пуассона 
        private void Pu()
        {
            int f;
            double a;
            if (Int32.TryParse(PuCountBox.Text, out f) && f > 0 && Double.TryParse(PuL.Text, out a) && a > 0)
            {
                PuBox.Items.Clear();
                chartPu.Series["Числа"].Points.Clear();
                chartPu.Series["График"].Points.Clear();

                int n = Convert.ToInt32(PuCountBox.Text);
                double L = Convert.ToDouble(PuL.Text);

                Pu pu = new Pu();
                pu.SolvePu(n, L);

                for (int i = 0; i < pu.list.Count; i++)
                {
                    PuBox.Items.Add(pu.list[i]);
                }
                foreach (var i in pu.Dic)
                {
                    chartPu.Series["График"].Points.AddXY(i.Key, i.Value);
                    chartPu.Series["Числа"].Points.AddXY(i.Key, i.Value);
                }
            }
        }

        //Решение N
        private void N()
        {
            int f;
            if (Int32.TryParse(NCountBox.Text, out f) && f > 0 && Int32.TryParse(MBox.Text, out f) && f > 0 && Int32.TryParse(DBox.Text, out f) && f > 0)
            {
                NBox.Items.Clear();
                chartN.Series["Числа"].Points.Clear();
                chartN.Series["График"].Points.Clear();

                int n = Convert.ToInt32(NCountBox.Text);
                var M = Int32.Parse(MBox.Text);
                var D = Int32.Parse(DBox.Text);

                N normal = new N();
                normal.SolveN(n, M, D);

                for (int i = 0; i < normal.list.Count; i++)
                {
                    NBox.Items.Add(normal.list[i]);
                }
                foreach (var i in normal.Dic)
                {
                    chartN.Series["График"].Points.AddXY(i.Key, i.Value);
                    chartN.Series["Числа"].Points.AddXY(i.Key, i.Value);
                }
            }
        }

        //Решение Exp 
        private void Exp()
        {
            int f;
            if (Int32.TryParse(ExpCountBox.Text, out f) && f > 0 && Int32.TryParse(ExpM.Text, out f) && f > 0)
            {
                ExpBox.Items.Clear();
                chartExp.Series["Числа"].Points.Clear();
                chartExp.Series["График"].Points.Clear();

                int n = Convert.ToInt32(ExpCountBox.Text);
                var M = Int32.Parse(ExpM.Text);

                Exp exp = new Exp();
                exp.SolveExp(n, M);

                for (int i = 0; i < exp.list.Count; i++)
                {
                    ExpBox.Items.Add(exp.list[i]);
                }
                foreach (var i in exp.Dic)
                {
                    chartExp.Series["График"].Points.AddXY(i.Key, i.Value);
                    chartExp.Series["Числа"].Points.AddXY(i.Key, i.Value);
                }
            }
        }

        //Решаем
        private void Solve_Click(object sender, EventArgs e)
        {
            switch (Windows.SelectedIndex)
            {
                case 0:
                {
                    R1();
                    break;
                }
                case 1:
                {
                    R2();
                    break;
                }
                case 2:
                {
                    Tri();
                    break;
                }
                case 3:
                {
                    Er();
                    break;
                }
                case 4:
                {
                    Pu();
                    break;
                }
                case 5:
                {
                    N();
                    break;
                }
                case 6:
                {
                    Exp();
                    break;
                }
            }
        }
    }
}