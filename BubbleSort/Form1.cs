using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            float[] a = {3,7,2,1,5};

            InitializeComponent();
            BubbleSort b = new BubbleSort(a);
            b.Sort();
        }
    }
}
