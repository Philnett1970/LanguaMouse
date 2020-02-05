using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguaMouse2._0.Properties;

namespace LanguaMouse2._0
{
    public partial class Form3 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public Form3()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Settings.Default.fontColor;
           
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;

            g = e.Graphics;

            Pen myPen = new Pen(Color.White);
            Pen bPen = new Pen(Color.Red);
            bPen.Width = 3;
            myPen.Width = 10;
            //  g.DrawLine(myPen, 30, 30, 45, 65);

            g.DrawLine(myPen, 0, 0, this.Width, 0);
            g.DrawLine(myPen, 0, 0, 0, this.Height);
            g.DrawLine(myPen, this.Width - 3, this.Height, this.Width, 0);
            g.DrawLine(myPen, 0, this.Height, this.Width, this.Height);
        }
    }
}
