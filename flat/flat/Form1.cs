using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace flat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setclear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAdjacentMenu.Checked)
                groupAdjacent.Visible = true;
            else 
            {
                groupAdjacent.Visible = false;
            }
        }

        private void rbtnTraversalMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTraversalMenu.Checked)
                groupTraversal.Visible = true;
            else 
            { 
                groupTraversal.Visible = false; 
            }

        }

        //global variables
        bool stopcreate;
        int[,] matrix; //serve as the adjacent matrix
        int countnodes; //serve as counter
        String[] vertices; //nodes
        Graphics graph;
        int row = 0, col = 0;  

        private void button1_Click(object sender, EventArgs e)
        {
            lblDisabled.Visible = false;
            lblEnabled.Visible = true;
            stopcreate = false;

        }

        private void btnAdjacent_Click(object sender, EventArgs e)
        {
            if (stopcreate == true) 
            {   
                //setting or defining the adjacent of two nodes !!

                int edge1 = Convert.ToInt32(txtEdge1.Text);
                int edge2 = Convert.ToInt32(txtEdge2.Text);

                //splitting the coordinates of x and y of the edge !!

                string[] c1 = vertices[edge1].Split('-');
                string[] c2 = vertices[edge2].Split('-');

                int xcoordinate1 = Convert.ToInt32(c1[0]);  //X coordinate of edge 1
                int ycoordinate1 = Convert.ToInt32(c1[1]);  //X coordinate of edge 1

                int xcoordinate2 = Convert.ToInt32(c2[0]);  //X coordinate of edge 2
                int ycoordinate2 = Convert.ToInt32(c2[1]);  //X coordinate of edge 2

                //draw a line!
                graph.DrawLine(new Pen(Brushes.Fuchsia, 2), (xcoordinate1 + 12), (ycoordinate1 + 12), 
                    (xcoordinate2 + 12), (float)(ycoordinate2 + 12));

                double x = (double)(xcoordinate2 - xcoordinate1);
                double y = (double)(ycoordinate2 - ycoordinate1);
                double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                int a = (int)(xcoordinate1 + xcoordinate2) / 2;
                int b = ((int)(ycoordinate1 + ycoordinate2) / 2) - 5;

                graph.DrawString(Math.Round(d, 2).ToString(), new Font("Arial", 9), Brushes.Maroon, a, b);

                matrix[edge1, edge2] = Convert.ToInt32(d);
                matrix[edge2, edge1] = Convert.ToInt32(d);

                MatrixGraph(int.Parse(txtEdge1.Text), int.Parse(txtEdge2.Text));

            }
        }

        private void picGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && stopcreate != true)
            {
                //when you click the mouse at the leftside
                Rectangle rect = new Rectangle(e.X, e.Y, 25, 25);

                //define the location of x and y coordinate
                graph.FillEllipse(Brushes.Black, rect);

                vertices[countnodes] = e.X + "-" + e.Y;

                //the number will appear based on the nodes created
                graph.DrawString(countnodes.ToString(), new Font("Arial", 7), Brushes.White, e.X + 8, e.Y + 8);

                //the number and color of the nodes
                countnodes++;

                //increment another node to draw in the datagridview
                dataGridView1.Columns.Add("", (countnodes - 1).ToString());
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[countnodes - 1].HeaderCell.Value = (countnodes - 1).ToString();
                dataGridView1.AutoResizeRows();
                row++;

                for (int i = 0; i < row; i++)
                {
                    dataGridView1.Rows[i].Cells[row - 1].Value = "0";
                    dataGridView1.Rows[row - 1].Cells[i].Value = "0";
                }


            }
            else
            {
                //right click the node will stop creating
                lblDisabled.Visible = true;
                lblEnabled.Visible = false;
                stopcreate = true;
            }
        }

        //create methods
        public void MatrixGraph(int row, int col) 
        {
            dataGridView1.Rows[row].Cells[col].Value = "1";
            dataGridView1.Rows[col].Cells[row].Value = "1";
        }

        public void setclear() 
        {
            graph = picGraph.CreateGraphics();
            stopcreate = false;
            matrix = new int[50, 50];
            vertices = new string[50];
            countnodes = 0;
        }

        //BFS psuedocode

        /*  BFS(graph, start):
         *  
         *      queue = create a new queue 
         *      visited = create a new set
         *      
         *      enqueue (source, destinateion)
         *      
         *      add start to visited 
         *      
         *      while queue is not empty:
         *      
         *          current = dequeue(queue)
         *          for neighbor in graph[current]:
         *              if neighbor not in visited:
         *                     add neighbor to visited
         *                     enqueue(queue, neighbor)
         * 
         */

        public void BFSTraversal() 
        {
            //setting nodes as source and destination in the textbox
            int source = Convert.ToInt32(txtSource.Text);
            int destination = Convert.ToInt32(txtDestination.Text);
        }
        
    }
}
