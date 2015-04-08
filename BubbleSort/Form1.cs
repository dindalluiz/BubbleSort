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

        List<Static> statics = new List<Static>();

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
        }

        public void Update(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Draw()
        {
            for (int i = 0; i < statics.Count;i++)
            {
                chart1.Series[0].Points.AddXY(statics[i].elements, statics[i].timespan.TotalSeconds);
            }
        }

        TimeSpan bubble()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            b = new BubbleSort(a);
            b.Sort();
            watch.Stop();
            return watch.Elapsed;
        }

        void randomList()
        {
            Random rand = new Random();
            for (int i = 0; i < a.Count;i++)
            {
                a[i] = i + rand.Next(300);
            }
        }

        void addElements()
        {
            Random rand = new Random();

            for (int j = 0; j < Convert.ToInt64(numbersBox.Text); j++)
            {
                a.Add(j + rand.Next(300));
            }
        }

        private void generateGraf_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox1.Text);i++)
            {
                addElements();
                statics.Add(new Static(bubble(), a.Count));
                randomList();
            }

            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            statics.Clear();
            a.Clear();
            chart1.Series[0].Points.Clear();
        }
    }
}
