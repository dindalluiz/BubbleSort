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
        List<int> a = new List<int>();
        TimeSpan timespan;
        int alo;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Start();
            timer.Tick += new EventHandler(this.Update);

            Paint += new PaintEventHandler(this.DrawIt);
        }

        public void Update(object sender, EventArgs e)
        {
            Invalidate();
            alo++;
        }

        private void DrawIt(object sender, PaintEventArgs p)
        {
            Rectangle rectangle = new Rectangle(10, 200, 600, 300);
            p.Graphics.DrawRectangle(Pens.Red, rectangle);

            for (int i = 0; i < a.Count; i++)
            {
                Rectangle recAux = new Rectangle(10 + (i * 20), 500 - a[i], 20, a[i]);
                p.Graphics.DrawRectangle(Pens.Blue, recAux);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(a.Count > 0) a = b.returnList();

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
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
            Random rand = new Random();

            for (int j = 0; j < Convert.ToInt64(numbersBox.Text); j++)
            {
                a.Add(j + rand.Next(300));
            }

            b = new BubbleSort(a);
        }
    }
}
