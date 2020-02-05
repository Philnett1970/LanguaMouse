using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguaMouse2._0.Properties;

namespace LanguaMouse2._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Opacity = .3;
            this.TopMost = true;
            this.BackColor = Settings.Default.highlightColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Size = new System.Drawing.Size(85, 85);

            // Makes the form circular:
            System.Drawing.Drawing2D.GraphicsPath GP = new System.Drawing.Drawing2D.GraphicsPath();
            GP.AddEllipse(this.ClientRectangle);

            this.Region = new Region(GP);
        }

        const int WS_EX_TRANSPARENT = 0x20;

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen linePen = new Pen(Settings.Default.lineColor);
            linePen.Width = 3;
            Graphics grphx = this.CreateGraphics();
            grphx.Clear(this.BackColor);


            for (int i = 1; i < 5; i++)
            {
                //Draw verticle line
                grphx.DrawLine(linePen, (this.ClientSize.Width / 2 + 3) * i, 0, (this.ClientSize.Width / 2 + 3) * i, this.ClientSize.Height);

                //Draw horizontal line
                grphx.DrawLine(linePen, 0, (this.ClientSize.Height / 2 + 3) * i, this.ClientSize.Width, (this.ClientSize.Height / 2 + 3) * i);
            }
            linePen.Dispose();

            //Continues the paint of other elements and controls
            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            pt.Offset(-1 * this.Width / 2, -1 * this.Height / 2);

            this.Location = pt;
        }
    }
}
