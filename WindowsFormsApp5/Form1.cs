using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public abstract class Element

        {

            protected int xpos;
            protected int ypos;
            protected int direction;
            protected int size;
            public Element(int x, int y, int d, int s)
            {
                xpos = x; ypos = y;
                if (d == 0) direction = 0;
                else direction = 1;
                size = s;
            }
            public abstract void draw(Graphics G, Pen p);

        }


        public class Line : Element

        {
            public Line(int x, int y, int d, int s)

            : base(x, y, d, s)

            { }

            public override void draw(Graphics G, Pen p)
            {
                if (direction == 1)
                {
                    G.DrawLine(p, xpos, ypos, xpos + size, ypos);
                }
                else
                {
                    G.DrawLine(p, xpos, ypos, xpos, ypos + size);
                }
            }
        }
        public class Lamp : Element
        {
            public Lamp(int x, int y, int d, int s) : base(x, y, d, s) { }

            public override void draw(Graphics G, Pen p)
            {
                float difference = Convert.ToSingle(Math.Sqrt(2 *

                Math.Pow(size / 2, 2)) / 2);

                if (direction == 1)
                {
                    int x = xpos, y = ypos - size / 2;
                    G.DrawEllipse(p, x, y, size, size);
                    int x0 = x + size / 2;
                    G.DrawLine(p, x0 - difference, ypos - difference,
                    x0 + difference, ypos + difference);
                    G.DrawLine(p, x0 - difference, ypos + difference,
                    x0 + difference, ypos - difference);

                }
                else
                {
                    int x = xpos - size / 2, y = ypos;
                    G.DrawEllipse(p, x, y, size, size);
                    int y0 = y + size / 2;
                    G.DrawLine(p, xpos - difference, y0 - difference,

                    xpos + difference, y0 + difference);

                    G.DrawLine(p, xpos - difference, y0 + difference,

                    xpos + difference, y0 - difference);

                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                Graphics G = CreateGraphics();
                Pen black = new Pen(Color.Black);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                int X0 = 100, Y0 = 100;
                Element[] el = new Element[20];
                el[0] = new Line(X0, Y0, 0, 80); //Left line to switch                
                el[1] = new Line(X0, Y0 + 80, 0, 35); //Between Switch
                el[2] = new Line(X0, Y0 + 115, 0, 115); //After switch to down LeftLine
                el[3] = new Line(X0, Y0 + 230, 1, 50); //Left to right line to Lamp1
                el[4] = new Lamp(X0 + 50, Y0 + 230, 1, 60); // Lamp1
                el[5] = new Line(X0 + 110, Y0 + 230, 1, 100); //Lamp1 to Lamp2
                el[6] = new Lamp(X0 + 210, Y0 + 230, 1, 60); //Lamp2
                el[7] = new Line(X0 + 270, Y0 + 230, 1, 50); //Lamp2 to right line
                el[8] = new Line(X0 + 320, Y0, 0, 230); //Right line
                el[9] = new Line(X0, Y0, 170, 130); //UpperCase Right to Left
                el[10] = new Line(X0 + 130, Y0 - 40, 0, 80); //First Long Key
                el[11] = new Line(X0 + 140, Y0 - 20, 0, 40); //First Short Key
                el[12] = new Line(X0 + 139, Y0 - 20, 0, 40); //First Short Key
                el[13] = new Line(X0 + 140, Y0, 70, 40); //Line Between Two Key
                el[14] = new Line(X0 + 180, Y0 - 40, 0, 80); //Second Long Key
                el[15] = new Line(X0 + 190, Y0 - 20, 0, 40); //Second Short Key
                el[16] = new Line(X0 + 189, Y0 - 20, 0, 40); //Second Short Key
                el[17] = new Line(X0 + 190, Y0, 80, 130); //After Second Key to Right
                el[18] = new Line(X0 - 1, Y0 + 80, 0, 5); //First Key
                el[19] = new Line(X0 - 1, Y0 + Y0 + 15, 0, 5); //Second Key

                for (int i = 0; i < 20; i++)
                    el[i].draw(G, black);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
                

            
        }
    }
}
