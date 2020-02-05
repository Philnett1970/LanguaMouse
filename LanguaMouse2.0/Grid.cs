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

namespace LanguaMouse2._0
{
    public partial class Grid : Form
    {
        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }


        public Grid()
        {
            InitializeComponent();
            DynamicGenerateTable(9, 9);
        }

        private void Grid_Load(object sender, EventArgs e)
        {

        }

        public void DynamicGenerateTable(int columnCount, int rowCount)
        {
            tableLayoutPanel1.Controls.Clear();
            //Clear out the existing row and column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            //Assign table no of rows and column
            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;


            for (int i = 0; i < columnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                TableLayoutColumnStyleCollection Cstyles = tableLayoutPanel1.ColumnStyles;
                foreach (ColumnStyle Cstyle in Cstyles)
                {
                    if (Cstyle.SizeType == SizeType.Percent)
                    {

                        // Set the column width to 50 pixels.
                        // style.SizeType = SizeType.Absolute;
                        Cstyle.Width = 25;
                    }
                }

                for (int j = 0; j < rowCount; j++)
                {
                    if (i == 0)
                    {
                        //defining the height of cell
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent));
                        TableLayoutRowStyleCollection Rstyles = tableLayoutPanel1.RowStyles;
                        foreach (RowStyle Rstyle in Rstyles)
                        {


                            if (Rstyle.SizeType == SizeType.Percent)
                            {
                                // Set the column width to 50 pixels.
                                // style.SizeType = SizeType.Absolute;
                                Rstyle.Height = 25;


                            }
                        }
                    }



                }
            }


            int num = rowCount * columnCount + 1;
            for (int c = 1; c < num; c++)
            {
                Label label = new Label();
                label.Name = "MyLabel" + c.ToString();
                label.Text = c.ToString();
                label.Dock = DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Click += new EventHandler(labelClick);
                tableLayoutPanel1.Controls.Add(label);

            }



        }



        public void labelClick(object sender, EventArgs e)
        {
            //attempt to cast the sender as a label
            Label lbl = sender as Label;

            //if the cast was successful (i.e. not null)
            if (lbl != null)
            {
                Cursor.Position = new Point(lbl.Location.X + lbl.Width / 2, lbl.Location.Y + lbl.Height / 2);
                this.Visible = false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
