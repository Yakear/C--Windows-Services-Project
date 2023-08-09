namespace WindowsServiceInstaller
{
    partial class MainPageForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageForm));
            groupBox3 = new GroupBox();
            checkBox2 = new CheckBox();
            textBox5 = new TextBox();
            label14 = new Label();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label9 = new Label();
            groupBox2 = new GroupBox();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox2);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Location = new Point(167, 74);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1251, 605);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.Location = new Point(6, -1);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(129, 19);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "Show filter settings";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // textBox5
            // 
            textBox5.Cursor = Cursors.IBeam;
            textBox5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(4, 19);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Write a filter text to filt 'Name', 'DisplayName', 'Description' columns.";
            textBox5.Size = new Size(423, 25);
            textBox5.TabIndex = 0;
            textBox5.KeyDown += txtMesaj_KeyPress;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(1050, 18);
            label14.Name = "label14";
            label14.Size = new Size(0, 19);
            label14.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 22;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(173, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1239, 549);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Scroll += dataGridView1_OnScroll;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.LightGray;
            button4.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = Properties.Resources.refresh;
            button4.Location = new Point(87, 17);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(18, 18);
            button4.TabIndex = 11;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1433, 31);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(linkLabel2);
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(label9);
            groupBox1.Location = new Point(-2, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(172, 649);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 177);
            label13.MaximumSize = new Size(170, 0);
            label13.Name = "label13";
            label13.Size = new Size(88, 20);
            label13.TabIndex = 7;
            label13.Text = "Description:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(6, 23);
            label12.MaximumSize = new Size(165, 0);
            label12.Name = "label12";
            label12.Size = new Size(165, 40);
            label12.TabIndex = 6;
            label12.Text = "Select a service to get information about it.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(43, 123);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 4;
            label10.Text = "the service.";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(6, 123);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(40, 20);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Stop";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(6, 94);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(40, 20);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Start";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(41, 94);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 0;
            label9.Text = "the service.";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(button8);
            groupBox2.Controls.Add(button7);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button4);
            groupBox2.Location = new Point(167, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1251, 43);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatAppearance.MouseDownBackColor = Color.LightGray;
            button9.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Image = Properties.Resources.search_folder;
            button9.Location = new Point(112, 16);
            button9.Name = "button9";
            button9.Size = new Size(18, 18);
            button9.TabIndex = 12;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatAppearance.MouseDownBackColor = Color.LightGray;
            button8.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Image = Properties.Resources.delete;
            button8.Location = new Point(61, 17);
            button8.Name = "button8";
            button8.Size = new Size(18, 18);
            button8.TabIndex = 2;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.MouseDownBackColor = Color.LightGray;
            button7.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Image = Properties.Resources.add_folder;
            button7.Location = new Point(35, 16);
            button7.Name = "button7";
            button7.RightToLeft = RightToLeft.No;
            button7.Size = new Size(18, 18);
            button7.TabIndex = 1;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = Color.LightGray;
            button6.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources.add;
            button6.Location = new Point(9, 16);
            button6.Name = "button6";
            button6.Size = new Size(18, 18);
            button6.TabIndex = 0;
            button6.UseMnemonic = false;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // MainPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1424, 683);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "MainPageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Windows Service Installer";
            Load += Form1_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private Button button4;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button9;
        private TextBox textBox5;
        private CheckBox checkBox2;
        private Label label10;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label label9;
        private Label label13;
        private Label label12;
        private Label label14;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
    }
}