using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BubbleSort
{
    public partial class Form1 : Form
    {
        BubbleSort b; 
        List<float> a = new List<float>();
        TimeSpan timespan;
        List<List<float>> lists = new List<List<float>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawIt()
        {
            Graphics graphics = CreateGraphics();
            Rectangle rectangle = new Rectangle(10, 580, 50, 100);
            graphics.DrawRectangle(Pens.Red, rectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = b.returnList();

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }

            DrawIt();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            b.Sort();
            watch.Stop();
            timespan = watch.Elapsed;
            Console.WriteLine(timespan.TotalSeconds);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] aux = numbersBox.Text.Split(",".ToCharArray());

            Random rand = new Random();

            for (int i = 0; i < aux.Length; i++)
            {
                for (int j = 0; j < Convert.ToInt64(aux[i]); j++)
                {
                    a.Add(i + rand.Next(1,4) * 2 + rand.Next(1,5));
                }
            }

            b = new BubbleSort(a);
        }
    }
}
