namespace CS203
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateNode = new System.Windows.Forms.Button();
            this.btnAdjacentNode = new System.Windows.Forms.Button();
            this.txtedge1 = new System.Windows.Forms.TextBox();
            this.txtedge2 = new System.Windows.Forms.TextBox();
            this.edge1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateNode
            // 
            this.btnCreateNode.Location = new System.Drawing.Point(28, 35);
            this.btnCreateNode.Name = "btnCreateNode";
            this.btnCreateNode.Size = new System.Drawing.Size(176, 33);
            this.btnCreateNode.TabIndex = 0;
            this.btnCreateNode.Text = "Create Node";
            this.btnCreateNode.UseVisualStyleBackColor = true;
            this.btnCreateNode.Click += new System.EventHandler(this.btnCreateNode_Click);
            // 
            // btnAdjacentNode
            // 
            this.btnAdjacentNode.Location = new System.Drawing.Point(28, 83);
            this.btnAdjacentNode.Name = "btnAdjacentNode";
            this.btnAdjacentNode.Size = new System.Drawing.Size(176, 41);
            this.btnAdjacentNode.TabIndex = 1;
            this.btnAdjacentNode.Text = "Adjacent Nodes";
            this.btnAdjacentNode.UseVisualStyleBackColor = true;
            this.btnAdjacentNode.Click += new System.EventHandler(this.btnAdjacentNode_Click);
            // 
            // txtedge1
            // 
            this.txtedge1.Location = new System.Drawing.Point(242, 46);
            this.txtedge1.Name = "txtedge1";
            this.txtedge1.Size = new System.Drawing.Size(144, 22);
            this.txtedge1.TabIndex = 2;
            // 
            // txtedge2
            // 
            this.txtedge2.Location = new System.Drawing.Point(242, 104);
            this.txtedge2.Name = "txtedge2";
            this.txtedge2.Size = new System.Drawing.Size(144, 22);
            this.txtedge2.TabIndex = 3;
            // 
            // edge1
            // 
            this.edge1.AutoSize = true;
            this.edge1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edge1.Location = new System.Drawing.Point(275, 18);
            this.edge1.Name = "edge1";
            this.edge1.Size = new System.Drawing.Size(80, 25);
            this.edge1.TabIndex = 4;
            this.edge1.Text = "Edge 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Edge 2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdjacentNode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreateNode);
            this.groupBox1.Controls.Add(this.txtedge2);
            this.groupBox1.Controls.Add(this.edge1);
            this.groupBox1.Controls.Add(this.txtedge1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 151);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph Details";
            // 
            // picGraph
            // 
            this.picGraph.Location = new System.Drawing.Point(12, 194);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(417, 230);
            this.picGraph.TabIndex = 7;
            this.picGraph.TabStop = false;
            this.picGraph.Click += new System.EventHandler(this.picGraph_Click);
            this.picGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseClick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "&Clear";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateNode;
        private System.Windows.Forms.Button btnAdjacentNode;
        private System.Windows.Forms.TextBox txtedge1;
        private System.Windows.Forms.TextBox txtedge2;
        private System.Windows.Forms.Label edge1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

