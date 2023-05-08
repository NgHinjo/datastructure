using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_v._00._1
{
    public partial class DFS : Form {
        //for timer
        bool sidebarExpand;

        public DFS() {
            InitializeComponent();
            setclear();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveFileDialog sd = new SaveFileDialog(); //initialize the save dialog
            sd.Filter = "Text Documents (*.txt)|*.txt";

            if (sd.ShowDialog() == DialogResult.OK) {
                StreamWriter sw = new StreamWriter(sd.FileName, true);
                String nodes = "";

                for (int i = 0; i < countnodes; i++) {
                    nodes = i + "-" + vertices[i];
                    for (int j = 0; j < countnodes; j++) {
                        if (matrix[i, j] != 0) {
                            nodes = nodes + "\t" + j + "-" + vertices[j];
                        }
                    }
                    sw.WriteLine(nodes);
                }
                MessageBox.Show("File Saved!");
                sw.Close();
            }
        }

        //side bar slide in/out
        private void Sidebar_tick(object sender, EventArgs e) {
            //set the minimum and maximum size of sidebar panel

            if (sidebarExpand) {
                //if sidebar is expand, minimize!
                Sidebar.Width -= 10;
                if (Sidebar.Width == Sidebar.MinimumSize.Width) {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }


            }
            else {
                Sidebar.Width += 10;
                if (Sidebar.Width == Sidebar.MaximumSize.Width) {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void Menubutton_Click(object sender, EventArgs e) {
            sidebarTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e) {
            Application.Restart();
        }

        private void lblclose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) {
            MessageBox.Show("#速度与激情9#\r\n早上好中国\r\n现在我有冰激淋 我很喜欢冰激淋\r\n但是《速度与激情9》比冰激淋……\r\n\r\n🍦");
        }

        private void button4_Click(object sender, EventArgs e) {
            MessageBox.Show("BFS Traversal Final Project by Nichol Angelo I. Degamo");
        }

        //Global Variables
        bool stopcreate;
        int[,] matrix; //serve as the adjacent matrix
        int countnodes; //serve as counter
        String[] vertices; //nodes
        Graphics graph;
        int row = 0, col = 0;

        //create methods
        private void setAdjacentMatrixToZero(int nodeCount) {
            for (int x = 0; x < nodeCount; x++) {
                for (int y = 0; y < nodeCount; y++) {
                    if (dataGridView1.Rows[x].Cells[y].Value == null) {
                        dataGridView1.Rows[x].Cells[y].Value = 0;
                    }
                }
            }
        }
        private void setAdjacentMatrixToOne(int edge1, int edge2) {
            for (int x = 0; x < countnodes; x++) {
                for (int y = 0; y < countnodes; y++) {
                    if (edge1 == x && edge2 == y) {
                        dataGridView1.Rows[edge1].Cells[edge2].Value = 1;
                        dataGridView1.Rows[edge2].Cells[edge1].Value = 1;
                    }
                }
            }
        }

        public void setclear() {
            graph = picGraph.CreateGraphics();
            stopcreate = false;
            matrix = new int[50, 50];
            vertices = new string[50];
            countnodes = 0;
        }

        private void btnCreateNode_Click(object sender, EventArgs e) {
            lblStopped.Visible = false;
            lblcreatetext.Visible = true;
            stopcreate = false;
        }

        private void btnAdjacentNode_Click(object sender, EventArgs e) {

            try {
                int edge1 = Convert.ToInt32(cmbEdge1.Text);
                int edge2 = Convert.ToInt32(cmbEdge2.Text);
                //setting or defining the adjacent of two nodes !!
                if (stopcreate == true && (edge1 < countnodes && edge2 < countnodes)) {

                    //splitting the coordinates of x and y of the edge !!

                    string[] c1 = vertices[edge1].Split('-');
                    string[] c2 = vertices[edge2].Split('-');

                    int xcoordinate1 = Convert.ToInt32(c1[0]);  //X coordinate of edge 1
                    int ycoordinate1 = Convert.ToInt32(c1[1]);  //X coordinate of edge 1

                    int xcoordinate2 = Convert.ToInt32(c2[0]);  //X coordinate of edge 2
                    int ycoordinate2 = Convert.ToInt32(c2[1]);  //X coordinate of edge 2

                    //draw a line!
                    graph.DrawLine(new Pen(Brushes.White, 2), (xcoordinate1 + 12), (ycoordinate1 + 12),
                        (xcoordinate2 + 12), (float)(ycoordinate2 + 12));

                    double x = (double)(xcoordinate2 - xcoordinate1);
                    double y = (double)(ycoordinate2 - ycoordinate1);
                    double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                    int a = (int)(xcoordinate1 + xcoordinate2) / 2;
                    int b = ((int)(ycoordinate1 + ycoordinate2) / 2) - 5;

                    graph.DrawString(Math.Round(d, 2).ToString(), new Font("Arial", 9), Brushes.Maroon, a, b);

                    matrix[edge1, edge2] = Convert.ToInt32(d);
                    matrix[edge2, edge1] = Convert.ToInt32(d);

                    setAdjacentMatrixToOne(edge1, edge2);
                }
                else if (edge1 >= countnodes || edge2 >= countnodes) {
                    MessageBox.Show("Error!");
                }
            }
            catch (Exception x) {
                MessageBox.Show("Error!");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog od = new OpenFileDialog(); //initialize
            od.Filter = "Text Document(*.txt)|*.txt"; //file extension
            od.ValidateNames = true; //validation

            if (od.ShowDialog() == DialogResult.OK) {
                setclear();
                cmbEdge1.Items.Clear();
                cmbEdge2.Items.Clear();
                cmbSource.Items.Clear();
                cmbDestination.Items.Clear();
                lblpath.Text = "The Traversal Path is : ";
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                Graphics g = picGraph.CreateGraphics();
                g.Clear(Color.Silver);

                try {
                    String line = "";
                    StreamReader sr = new StreamReader(od.FileName);

                    while (sr.Peek() != -1) {

                        countnodes++;

                        dataGridView1.Columns.Add("", (countnodes - 1).ToString());
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[countnodes - 1].HeaderCell.Value = (countnodes - 1).ToString();
                        dataGridView1.AutoResizeRows();


                        line = sr.ReadLine();
                        String[] adjacent = line.Split('\t');
                        String[] nodes = adjacent[0].Split('-');
                        int node1 = Convert.ToInt32(nodes[0]);
                        int x1 = Convert.ToInt32(nodes[1]);
                        int y1 = Convert.ToInt32(nodes[2]);
                        vertices[node1] = x1 + "-" + y1;

                        Rectangle rect = new Rectangle(x1, y1, 25, 25);
                        g.FillEllipse(Brushes.HotPink, rect);
                        g.DrawString(node1.ToString(), new Font("Arial", 7), Brushes.White, x1 + 8, y1 + 8);

                        for (int i = 1; i < adjacent.Length; i++) {
                            nodes = adjacent[i].Split('-');
                            int node2 = Convert.ToInt32(nodes[0]);
                            int x2 = Convert.ToInt32(nodes[1]);
                            int y2 = Convert.ToInt32(nodes[2]);

                            vertices[node2] = x2 + "-" + y2;

                            rect = new Rectangle(x2, y2, 25, 25);
                            g.FillEllipse(Brushes.HotPink, rect);
                            g.DrawString(node2.ToString(), new Font("Arial", 7), Brushes.White, x2 + 8, y2 + 8);
                            g.DrawLine(new Pen(Brushes.White, 2), (float)(x1 + 12), (float)(y1 + 12), (float)(x2 + 12), (float)(y2 + 12));

                            //calculate Distance
                            double x = (double)(x2 - x1);
                            double y = (double)(y2 - y1);
                            double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                            int a = (int)(x1 + x2) / 2;
                            int queue = ((int)(y1 + y2) / 2) - 5;
                            g.DrawString(Math.Round(d, 2).ToString(), new Font("Arial", 9), Brushes.Maroon, a, queue);

                            //adjacenct matrix 
                            matrix[node1, node2] = Convert.ToInt32(d);
                            matrix[node2, node1] = Convert.ToInt32(d);

                            setAdjacentMatrixToOne(node1, node2);
                        }
                        setAdjacentMatrixToZero(countnodes);

                    }

                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void picGraph_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && stopcreate != true) {
                //when you click the mouse at the leftside
                Rectangle rect = new Rectangle(e.X, e.Y, 25, 25);

                //define the location of x and y coordinate
                graph.FillEllipse(Brushes.HotPink, rect);

                vertices[countnodes] = e.X + "-" + e.Y;

                //the number will appear based on the nodes created
                graph.DrawString(countnodes.ToString(), new Font("Arial", 7), Brushes.White, e.X + 8, e.Y + 8);

                cmbEdge1.Items.Add(countnodes);
                cmbEdge2.Items.Add(countnodes);

                cmbSource.Items.Add(countnodes);
                cmbDestination.Items.Add(countnodes);
                //the number and color of the nodes
                countnodes++;

                //increment another node to draw in the datagridview
                dataGridView1.Columns.Add("", (countnodes - 1).ToString());
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[countnodes - 1].HeaderCell.Value = (countnodes - 1).ToString();
                dataGridView1.AutoResizeRows();

                setAdjacentMatrixToZero(countnodes);
            }
            else {
                //right click the node will stop creating
                lblStopped.Visible = true;
                lblcreatetext.Visible = false;
                stopcreate = true;
            }
        }

        private void btnTraverse_Click(object sender, EventArgs e) {
            DFSTraversal();        

        }

        private void lblClear_Click(object sender, EventArgs e) {
            // clears the pic graph
            picGraph.Image = null;
            groupGIF.Visible = true;

            lblcreatetext.Visible = true;
            lblStopped.Visible = false;

            // clears the gridview
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // clears the combo boxes 
            cmbEdge1.Items.Clear();
            cmbEdge1.ResetText();
            cmbEdge1.DropDownHeight = 106;
            cmbEdge2.Items.Clear();
            cmbEdge2.ResetText();
            cmbEdge2.DropDownHeight = 106;
            cmbSource.Items.Clear();
            cmbSource.ResetText();
            cmbSource.DropDownHeight = 106;
            cmbDestination.Items.Clear();
            cmbDestination.ResetText();
            cmbDestination.DropDownHeight = 106;

            countnodes = 0;

            lblpath.Text = "Traversal Path ";

            setclear();
        }

        //DBFS psuedocode

        /*  DFS(graph G, Node v, set visited)
         *  
         *      add v to visited set
         *      neighbors = G[v]
         *      
         *      while neighbor is not empty:
         *      
         *      w = neighbors.pop()
         *      
         *      if w not in visited
         *      
         *          DFS(G,W,visited)
         * 
         */

        public void DFSTraversal() {
            try {
                //setting nodes as source and destination in the textbox
                int source = Convert.ToInt32(cmbSource.Text);
                int destination = Convert.ToInt32(cmbDestination.Text);

                Stack<int> stack = new Stack<int>(); //stack = create a new stack
                HashSet<int> visited = new HashSet<int>(); //visited = create a new set

                stack.Push(source); //push(source, stack)
                visited.Add(source);

                while (stack.Count > 0) //while stack is not empty:
                {
                    int current = stack.Pop(); //current = pop(stack)

                    for (int i = 0; i < countnodes; i++) //for neighbor in graph[current]:
                    {
                        if (matrix[current, i] != 0 && !visited.Contains(i)) //if neighbor is not 0 and not visited:
                        {
                            visited.Add(i); //add neighbor to visited
                            stack.Push(i); //push(neighbor, stack)
                        }
                    }

                    lblpath.Text += " " + current + " ";

                    if (destination == current) {
                        groupGIF.Visible = false;
                        break;
                    }
                }
            }
            catch {
                MessageBox.Show("Error!");
            }
        }


    }

}
