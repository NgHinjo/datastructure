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
                int edge1 = Convert.ToInt32(txtedge1.Text);
                int edge2 = Convert.ToInt32(txtedge2.Text);

                //split the coordinates of x and y of the edge
                String[] c1 = vertices[edge1].Split('-');
                String[] c2 = vertices[edge2].Split('-');

                //cast it to integer and store it to another variable

                int xcoordinate1 = Convert.ToInt32(c1[0]); //x coordinate of edge1
                int ycoordinate1 = Convert.ToInt32(c1[1]); //y coordinate of edge1

                int xcoordinate2 = Convert.ToInt32(c2[0]); //x coordinate of edge2
                int ycoordinate2 = Convert.ToInt32(c2[1]); //y coordinate of edge2

                //after retrieving the x and y coordinate, we will draw a line
                graph.DrawLine(new Pen(Brushes.Green, 3), (xcoordinate1+12), (ycoordinate1+12), (xcoordinate2+12),(float)(ycoordinate2+12));

                //calculate distance 
                double x = (double)(xcoordinate2 - xcoordinate1);
                double y = (double)(ycoordinate2 - ycoordinate1);
                double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                int a = (int)(xcoordinate1 + xcoordinate2) / 2;
                int b = ((int)(ycoordinate1 + ycoordinate2) / 2) -5;

                graph.DrawString(Math.Round(d, 2).ToString(), new Font("Arial", 12), Brushes.Maroon, a, b);

                //adjacency matrix(undirected graph = no arrow)
                matrix[edge1, edge2] = Convert.ToInt32(d); //same distance
                matrix[edge2, edge1] = Convert.ToInt32(d);

                //if it is adjacent display 1 otherwise 0

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

                vertices[countnodes] = e.X + "-" + e.Y;               
        
                //the number will appear based on the nodes created
                graph.DrawString(countnodes.ToString(), new Font("Arial", 12), Brushes.White, e.X + 12, e.Y + 12);
                
                //the number and color of the nodes
                countnodes++;

                //increment another node to draw in the datagridview
                dataGridView1.Columns.Add("", (countnodes - 1).ToString());
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[countnodes -1].HeaderCell.Value = (countnodes - 1).ToString();
                dataGridView1.AutoResizeRows();

            }
            else 
            {   
                //right click the node will stop creating
                stopcreate = true;
            }
        }

        /**public void Matrix()
        {
                 
        }**/


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setclear();
        }
    }
}
