using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS203
{
    public partial class Form1 : Form
    {
           //global variables
        bool stopcreate;
        int[,] matrix; //serve as the adjacent matrix
        int countnodes; //serve as counter
        String[] vertices; //nodes
        Graphics graph;

        public Form1()
        {
            InitializeComponent();
            setclear();
        }

        //create method
        public void setclear() 
        {
            // set the initialization of variable to clear
            graph = picGraph.CreateGraphics();
            stopcreate= false;
            matrix = new int[50, 50];
            vertices = new string[50];
            countnodes = 0;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdjacentNode_Click(object sender, EventArgs e)
        {
            if (stopcreate == true) 
            {
                //set or define the adjacent of two nodes
            }
        }

        private void btnCreateNode_Click(object sender, EventArgs e)
        {
            stopcreate = false;
        }

        private void picGraph_Click(object sender, EventArgs e)
        {

        }

        private void picGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && stopcreate != true)
            {
                //when you click the mouse at the leftside
                Rectangle rect = new Rectangle(e.X, e.Y, 35, 35);

                //define the location of x and y coordinate
                graph.FillEllipse(Brushes.Black, rect);

                //the number and color of the nodes
                countnodes++;

                //the number will appear based on the nodes created
                graph.DrawString(countnodes.ToString(), new Font("Arial", 12), Brushes.White, e.X + 12, e.Y + 12);

            }
            else 
            {   
                //right click the node will stop creating
                stopcreate = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setclear();
        }
    }
}
