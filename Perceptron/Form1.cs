using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public struct Vector2d
    {
        public double x;
        public double y;
        public Vector2d(double x0,double x1)
        {
            x = x0;
            y = x1;
        }
    }
    public struct InputData
    {
        public int label;
        public Vector2d vector;

        public InputData(int x0, double x1, double x2)
        {
            label = x0;
            vector = new Vector2d(x1,x2);
        }
    }

    public partial class Form1 : Form
    {
        PerceptronMachine PM;
        List<InputData> Data;
        InputData d;
        Graphics g;
        Pen pen; 
        int ori;

        public Form1()
        {
            InitializeComponent();
            ori = 110;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data = new List<InputData> { };
            g = pictureBox1.CreateGraphics();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PM = new PerceptronMachine(Data);
            PM.train();
            listBox2.Items.Add("w1:" + PM.w.x + ",w2:" + PM.w.y);
            g.DrawLine(new Pen(Color.Black),Convert.ToSingle (ori+((-5)* PM.w.y/PM.w.x)*22) ,220,Convert.ToSingle (ori + ((5) * PM.w.y / PM.w.x) * 22),0);
        }




        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                pen = new Pen(Color.Blue);
            }
            else
            {
                pen = new Pen(Color.Red);
            }
            g.DrawEllipse(pen, e.X - 1, e.Y - 1, 3, 3);
            g.FillEllipse(new SolidBrush(pen.Color), e.X - 1, e.Y - 1, 3, 3);
            Data.Add(new InputData(Convert.ToInt32(comboBox1.SelectedItem),(((double)e.X - 110) / 22),((double)e.Y - 110) / 22));
            listBox1.Items.Add((((float)e.X - 110) / 22)+","+ (((float)e.Y - 110) / 22));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data.Clear();
            g.Clear(Color.Khaki);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.DrawEllipse(new Pen(Color.Khaki),Convert.ToSingle( Data[listBox1.SelectedIndex].vector.x*22+ori)-1, Convert.ToSingle(ori + (Data[listBox1.SelectedIndex].vector.y * 22)) - 1, 3, 3);
            g.FillEllipse(new SolidBrush(Color.Khaki), Convert.ToSingle(Data[listBox1.SelectedIndex].vector.x * 22 + ori) - 1, Convert.ToSingle(ori + (Data[listBox1.SelectedIndex].vector.y*22)) - 1, 3, 3);
            Data.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
