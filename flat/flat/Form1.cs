using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


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
        int row = 0;  

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Documents (*.txt)|*.txt";

            if (sd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sd.FileName, true);
                String nodes = "";
                for (int i = 0; i < countnodes; i++)
                {
                    nodes = i + "-" + vertices[i];
                    for (int j = 0; j < countnodes; j++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            nodes = nodes + "\t" + j + "-" + vertices[j];
                        }
                    }
                    sw.WriteLine(nodes);
                }
                MessageBox.Show("File Saved!");
                sw.Close();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Text Documents (*.txt)|*.txt";
            od.ValidateNames = true;

            if (od.ShowDialog() == DialogResult.OK) 
            {
                setclear();
                txtEdge1.Clear();
                txtEdge2.Clear();
                txtSource.Clear();
                txtDestination.Clear();
                lblDisabled.Text = "";
                lblEnabled.Text = "";       
                dataGridView1.Rows.Clear(); 
                dataGridView1.Columns.Clear();
                Graphics g = picGraph.CreateGraphics();
                g.Clear(Color.Silver);

                try
                {
                    String line = "";
                    StreamReader sr = new StreamReader(od.FileName);

                    do
                    {
                        line = sr.ReadLine();
                        String[] adjacent = line.Split('\t');
                        String[] nodes = adjacent[0].Split('-');
                        int node1 = Convert.ToInt32(nodes[0]);
                        int x1 = Convert.ToInt32(nodes[1]);
                        int y1 = Convert.ToInt32(nodes[2]);
                        vertices[node1] = x1 + "-" + y1;


                        Rectangle rect = new Rectangle(x1, y1, 25, 25);
                        g.FillEllipse(Brushes.Black, rect);
                        g.DrawString(node1.ToString(), new Font("Arial", 7), Brushes.White, x1 + 8, y1 + 8);

                        for (int i = 1; i < adjacent.Length; i++)
                        {
                            nodes = adjacent[i].Split('-');
                            int node2 = Convert.ToInt32(nodes[0]);
                            int x2 = Convert.ToInt32(nodes[1]);
                            int y2 = Convert.ToInt32(nodes[2]);
                            vertices[node2] = x2 + "-" + y2;

                            
                            //draw line
                            rect = new Rectangle(x2, y2, 25, 25);
                            g.FillEllipse(Brushes.Black, rect);
                            g.DrawString(node2.ToString(), new Font("Arial", 7), Brushes.White, x2 + 8, y2 + 8);
                            g.DrawLine(new Pen(Brushes.Fuchsia, 2), (float)(x1 + 12), (float)(y1 + 12),
                                     (float)(x2 + 12), (float)(y2 + 12));

                            //calculate distance
                            double x = (double)(x2 - x1);
                            double y = (double)(y2 - y1);
                            double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                            int a = (int)(x1 + x2) / 2;
                            int b = ((int)(y1 + y2) / 2) - 5;

                            g.DrawString(Math.Round(d, 2).ToString(), new Font("Arial", 9), Brushes.Maroon, a, b);

                            matrix[node1, node2] = Convert.ToInt32(d);
                            matrix[node2, node1] = Convert.ToInt32(d);
                        }

                        countnodes++;
                        dataGridView1.Columns.Add("", (countnodes - 1).ToString());
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[countnodes - 1].HeaderCell.Value = (countnodes - 1).ToString();
                        dataGridView1.AutoResizeRows();

                        

                    }
                    while (sr.Peek() != 1);
                }
                catch
                {
                    MessageBox.Show("Invalid File!");
                }
            }
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
