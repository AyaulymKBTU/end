using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace end
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ToolTip toolTip1;
        private void Form1_Load(object sender, EventArgs e)
        {
             toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            foreach (Control c in this.Controls)
            { toolTip1.SetToolTip(c, c.BackColor.R+" "+ c.BackColor.G +" "+ c.BackColor.B); }
            
        }
        static GraphicsPath gp = new GraphicsPath();
        class circle : UserControl
        {
            public circle(Color color,int x,int y)
            { this.BackColor = color;
                gp.AddEllipse(x,y,10,10);
                this.Region = new Region(gp);
                gp = new GraphicsPath();
               

            }
            
        }
        int r1 = 255;
        int g1 = 0, b1 = 0;
        int r2 = 0, g2 = 255, b2 = 0;
        int r3 = 0, g3 = 0, b3 = 255;

        private void button3_Click(object sender, EventArgs e)
        {
            r2 = 255;g2 = 255;
            b2 = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r1 = 255;g1 = 0;b1 = 0;
        }

        int x = 0;
        int y = 0;
        
        public int getInterval(int first, int second )
        {
            if(first>second)
            return (first - second) / 15 * (-1);
            else
                 return (second-first) / 15 ;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();


            // gr.FillRectangle(brush,x,y,10,10);
           
            int delr12= getInterval(r1, r2);
            int delr13 =getInterval(r1, r3);
            int delr23= getInterval(r2, r3);
            int delg12= getInterval(g1, g2);
            int delg13= getInterval(g1, g3);
            int delg23= getInterval(g2, g3);
            int delb12 = getInterval(b1, b2);
            int delb13= getInterval(b1, b3);
            int delb23= getInterval(b2, b3);
            int r = r1;
            int g = g1;
            int b = b1;
            for (int i = 0; i < 15; i++)
            {
                this.Controls.Add(new circle(Color.FromArgb(r, g, b), x, y));

                x += 10;
                y += 10;
                r += delr13;
                g += delg13;
                b += delb13;
               
            }
            
            x = 0;y = 0;
            r = r1;
            g = g1;
            b = b1;
            for (int i = 0; i < 15; i++)
            {
                this.Controls.Add(new circle(Color.FromArgb(r, g, b), x, y));
                y += 10;
                r += delr12;
                g += delg12;
                b += delb12;
               
            }
            y = 140;x = 0;r = r2;g = g2;b = b2;
            for (int i = 0; i < 15; i++)
            {

                this.Controls.Add(new circle(Color.FromArgb(r, g, b), x, y));
                x += 10;
                r += delr23;
                g += delg23;
                b += delb23;
            }
            y = 140;x = 0;
            int m = 14;
            int red, green, blue;
            int a, bb, ccc;
            for (int j = 14; j >0; j--)
            {
                y -= 10; x = 0; r = r1+(j+1)*delr12; g = g1+ (j+1)*delg12; b = b1+ (j+1)*delb12;
                a = r;bb = g;ccc = b;
                red = r1 +(j+1)*delr13; green = g1 + (j +1) * delg13; blue = b1 +(j+1) * delb13;
                for (int i = 0; i < m; i++)
                {

                    this.Controls.Add(new circle(Color.FromArgb(r, g, b), x, y));
                    x += 10;
                    r += getInterval(a,red);
                    g += getInterval(bb,green);
                    b += getInterval(ccc,blue);
                }
                
                m--;
            }
            foreach (Control c in this.Controls)
            { toolTip1.SetToolTip(c, c.BackColor.R + " " + c.BackColor.G + " " + c.BackColor.B ); }
        }
    }
}
