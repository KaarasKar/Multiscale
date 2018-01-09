namespace MultiscaleModelling1
{
    partial class MultiscaleModelling
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
            this.VisualizationPictureBox = new System.Windows.Forms.PictureBox();
            this.b_Start = new System.Windows.Forms.Button();
            this.b_Clear = new System.Windows.Forms.Button();
            this.b_Random = new System.Windows.Forms.Button();
            this.tb_SquareDiameter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_After_simulation = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_CountSquare = new System.Windows.Forms.TextBox();
            this.b_Circular = new System.Windows.Forms.Button();
            this.b_Square = new System.Windows.Forms.Button();
            this.tb_probability = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.b_Substructure = new System.Windows.Forms.Button();
            this.b_Dualphase = new System.Windows.Forms.Button();
            this.b_MC = new System.Windows.Forms.Button();
            this.tb_MC_steps = new System.Windows.Forms.TextBox();
            this.tb_SRX_steps = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_Ganywhere = new System.Windows.Forms.CheckBox();
            this.tb_Inc_nucleation = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_SRX_method = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_toggle_energy = new System.Windows.Forms.CheckBox();
            this.b_energy = new System.Windows.Forms.Button();
            this.cb_HGenous = new System.Windows.Forms.CheckBox();
            this.tb_SRX_energy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.b_SRXMC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Nucleation = new System.Windows.Forms.TextBox();
            this.cb_Neighbourhood = new System.Windows.Forms.ComboBox();
            this.cb_Periodic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_SRXnucleation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toBMP = new System.Windows.Forms.ToolStripMenuItem();
            this.fromBMP = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Boundariess = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizationPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VisualizationPictureBox
            // 
            this.VisualizationPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.VisualizationPictureBox.Location = new System.Drawing.Point(12, 48);
            this.VisualizationPictureBox.Name = "VisualizationPictureBox";
            this.VisualizationPictureBox.Size = new System.Drawing.Size(500, 500);
            this.VisualizationPictureBox.TabIndex = 0;
            this.VisualizationPictureBox.TabStop = false;
            // 
            // b_Start
            // 
            this.b_Start.Location = new System.Drawing.Point(536, 509);
            this.b_Start.Name = "b_Start";
            this.b_Start.Size = new System.Drawing.Size(110, 23);
            this.b_Start.TabIndex = 1;
            this.b_Start.Text = "Start";
            this.b_Start.UseVisualStyleBackColor = true;
            this.b_Start.Click += new System.EventHandler(this.Click_Start);
            // 
            // b_Clear
            // 
            this.b_Clear.Location = new System.Drawing.Point(536, 535);
            this.b_Clear.Name = "b_Clear";
            this.b_Clear.Size = new System.Drawing.Size(110, 23);
            this.b_Clear.TabIndex = 8;
            this.b_Clear.Text = "Clear";
            this.b_Clear.UseVisualStyleBackColor = true;
            this.b_Clear.Click += new System.EventHandler(this.Click_Clear);
            // 
            // b_Random
            // 
            this.b_Random.Location = new System.Drawing.Point(536, 564);
            this.b_Random.Name = "b_Random";
            this.b_Random.Size = new System.Drawing.Size(110, 23);
            this.b_Random.TabIndex = 9;
            this.b_Random.Text = "Random";
            this.b_Random.UseVisualStyleBackColor = true;
            this.b_Random.Click += new System.EventHandler(this.Click_Random);
            // 
            // tb_SquareDiameter
            // 
            this.tb_SquareDiameter.Location = new System.Drawing.Point(533, 158);
            this.tb_SquareDiameter.Name = "tb_SquareDiameter";
            this.tb_SquareDiameter.Size = new System.Drawing.Size(61, 20);
            this.tb_SquareDiameter.TabIndex = 17;
            this.tb_SquareDiameter.Text = "1";
            this.tb_SquareDiameter.TextChanged += new System.EventHandler(this.tb_SquareDiameter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "diameter";
            // 
            // cb_After_simulation
            // 
            this.cb_After_simulation.AutoSize = true;
            this.cb_After_simulation.Location = new System.Drawing.Point(533, 242);
            this.cb_After_simulation.Name = "cb_After_simulation";
            this.cb_After_simulation.Size = new System.Drawing.Size(97, 17);
            this.cb_After_simulation.TabIndex = 23;
            this.cb_After_simulation.Text = "After simulation";
            this.cb_After_simulation.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(593, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "number";
            // 
            // tb_CountSquare
            // 
            this.tb_CountSquare.Location = new System.Drawing.Point(596, 158);
            this.tb_CountSquare.Name = "tb_CountSquare";
            this.tb_CountSquare.Size = new System.Drawing.Size(61, 20);
            this.tb_CountSquare.TabIndex = 27;
            this.tb_CountSquare.Text = "10";
            // 
            // b_Circular
            // 
            this.b_Circular.Location = new System.Drawing.Point(533, 213);
            this.b_Circular.Name = "b_Circular";
            this.b_Circular.Size = new System.Drawing.Size(124, 23);
            this.b_Circular.TabIndex = 26;
            this.b_Circular.Text = "Circular inclusion";
            this.b_Circular.UseVisualStyleBackColor = true;
            this.b_Circular.Click += new System.EventHandler(this.Click_Circular);
            // 
            // b_Square
            // 
            this.b_Square.Location = new System.Drawing.Point(533, 184);
            this.b_Square.Name = "b_Square";
            this.b_Square.Size = new System.Drawing.Size(124, 23);
            this.b_Square.TabIndex = 26;
            this.b_Square.Text = "Square inclusion";
            this.b_Square.UseVisualStyleBackColor = true;
            this.b_Square.Click += new System.EventHandler(this.Click_Square);
            // 
            // tb_probability
            // 
            this.tb_probability.Location = new System.Drawing.Point(606, 272);
            this.tb_probability.Name = "tb_probability";
            this.tb_probability.Size = new System.Drawing.Size(23, 20);
            this.tb_probability.TabIndex = 1;
            this.tb_probability.Text = "90";
            this.tb_probability.TextChanged += new System.EventHandler(this.tb_probability_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(528, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Probability (%)";
            // 
            // b_Substructure
            // 
            this.b_Substructure.Location = new System.Drawing.Point(529, 302);
            this.b_Substructure.Name = "b_Substructure";
            this.b_Substructure.Size = new System.Drawing.Size(125, 23);
            this.b_Substructure.TabIndex = 27;
            this.b_Substructure.Text = "Substructure";
            this.b_Substructure.UseVisualStyleBackColor = true;
            this.b_Substructure.Click += new System.EventHandler(this.Click_Substructure);
            // 
            // b_Dualphase
            // 
            this.b_Dualphase.Location = new System.Drawing.Point(529, 331);
            this.b_Dualphase.Name = "b_Dualphase";
            this.b_Dualphase.Size = new System.Drawing.Size(125, 23);
            this.b_Dualphase.TabIndex = 28;
            this.b_Dualphase.Text = "Dualphase ";
            this.b_Dualphase.UseVisualStyleBackColor = true;
            this.b_Dualphase.Click += new System.EventHandler(this.Click_Dualphase);
            // 
            // b_MC
            // 
            this.b_MC.Location = new System.Drawing.Point(677, 67);
            this.b_MC.Name = "b_MC";
            this.b_MC.Size = new System.Drawing.Size(86, 23);
            this.b_MC.TabIndex = 2;
            this.b_MC.Text = "MC Start";
            this.b_MC.UseVisualStyleBackColor = true;
            this.b_MC.Click += new System.EventHandler(this.Click_MonteCarlo);
            // 
            // tb_MC_steps
            // 
            this.tb_MC_steps.Location = new System.Drawing.Point(771, 69);
            this.tb_MC_steps.Name = "tb_MC_steps";
            this.tb_MC_steps.Size = new System.Drawing.Size(30, 20);
            this.tb_MC_steps.TabIndex = 1;
            this.tb_MC_steps.Text = "10";
            // 
            // tb_SRX_steps
            // 
            this.tb_SRX_steps.Location = new System.Drawing.Point(681, 417);
            this.tb_SRX_steps.Name = "tb_SRX_steps";
            this.tb_SRX_steps.Size = new System.Drawing.Size(100, 20);
            this.tb_SRX_steps.TabIndex = 12;
            this.tb_SRX_steps.Text = "10";
            this.tb_SRX_steps.TextChanged += new System.EventHandler(this.tb_SRX_steps_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(681, 400);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "SRXMC steps no";
            // 
            // cb_Ganywhere
            // 
            this.cb_Ganywhere.AutoSize = true;
            this.cb_Ganywhere.Location = new System.Drawing.Point(679, 370);
            this.cb_Ganywhere.Name = "cb_Ganywhere";
            this.cb_Ganywhere.Size = new System.Drawing.Size(109, 17);
            this.cb_Ganywhere.TabIndex = 10;
            this.cb_Ganywhere.Text = "Grain boundaries ";
            this.cb_Ganywhere.UseVisualStyleBackColor = true;
            // 
            // tb_Inc_nucleation
            // 
            this.tb_Inc_nucleation.Location = new System.Drawing.Point(681, 333);
            this.tb_Inc_nucleation.Name = "tb_Inc_nucleation";
            this.tb_Inc_nucleation.Size = new System.Drawing.Size(100, 20);
            this.tb_Inc_nucleation.TabIndex = 9;
            this.tb_Inc_nucleation.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(678, 316);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Number of increase";
            // 
            // cb_SRX_method
            // 
            this.cb_SRX_method.FormattingEnabled = true;
            this.cb_SRX_method.Items.AddRange(new object[] {
            "Constant",
            "Increasing",
            "Decreasing",
            "Begining"});
            this.cb_SRX_method.Location = new System.Drawing.Point(681, 286);
            this.cb_SRX_method.Name = "cb_SRX_method";
            this.cb_SRX_method.Size = new System.Drawing.Size(100, 21);
            this.cb_SRX_method.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(678, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Nucleation method";
            // 
            // cb_toggle_energy
            // 
            this.cb_toggle_energy.AutoSize = true;
            this.cb_toggle_energy.Location = new System.Drawing.Point(679, 214);
            this.cb_toggle_energy.Name = "cb_toggle_energy";
            this.cb_toggle_energy.Size = new System.Drawing.Size(89, 17);
            this.cb_toggle_energy.TabIndex = 5;
            this.cb_toggle_energy.Text = "Show Energy";
            this.cb_toggle_energy.UseVisualStyleBackColor = true;
            this.cb_toggle_energy.CheckedChanged += new System.EventHandler(this.cb_toggle_energy_CheckedChanged);
            // 
            // b_energy
            // 
            this.b_energy.Location = new System.Drawing.Point(679, 241);
            this.b_energy.Name = "b_energy";
            this.b_energy.Size = new System.Drawing.Size(100, 23);
            this.b_energy.TabIndex = 4;
            this.b_energy.Text = "Distribute Energy";
            this.b_energy.UseVisualStyleBackColor = true;
            this.b_energy.Click += new System.EventHandler(this.Click_Energy);
            // 
            // cb_HGenous
            // 
            this.cb_HGenous.AutoSize = true;
            this.cb_HGenous.Location = new System.Drawing.Point(679, 188);
            this.cb_HGenous.Name = "cb_HGenous";
            this.cb_HGenous.Size = new System.Drawing.Size(92, 17);
            this.cb_HGenous.TabIndex = 3;
            this.cb_HGenous.Text = "Homogenous ";
            this.cb_HGenous.UseVisualStyleBackColor = true;
            // 
            // tb_SRX_energy
            // 
            this.tb_SRX_energy.Location = new System.Drawing.Point(679, 161);
            this.tb_SRX_energy.Name = "tb_SRX_energy";
            this.tb_SRX_energy.Size = new System.Drawing.Size(53, 20);
            this.tb_SRX_energy.TabIndex = 2;
            this.tb_SRX_energy.Text = "5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(676, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Energy to distribute";
            // 
            // b_SRXMC
            // 
            this.b_SRXMC.Location = new System.Drawing.Point(679, 475);
            this.b_SRXMC.Name = "b_SRXMC";
            this.b_SRXMC.Size = new System.Drawing.Size(124, 23);
            this.b_SRXMC.TabIndex = 0;
            this.b_SRXMC.Text = "Start SRX";
            this.b_SRXMC.UseVisualStyleBackColor = true;
            this.b_SRXMC.Click += new System.EventHandler(this.Click_SRXMC);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nucleation";
            // 
            // tb_Nucleation
            // 
            this.tb_Nucleation.Location = new System.Drawing.Point(623, 115);
            this.tb_Nucleation.Name = "tb_Nucleation";
            this.tb_Nucleation.Size = new System.Drawing.Size(31, 20);
            this.tb_Nucleation.TabIndex = 13;
            this.tb_Nucleation.Text = "10";
            // 
            // cb_Neighbourhood
            // 
            this.cb_Neighbourhood.FormattingEnabled = true;
            this.cb_Neighbourhood.Items.AddRange(new object[] {
            "Von Neumann",
            "Moore",
            "Hexagonal random",
            "Pentagonal random",
            "Moore Extension"});
            this.cb_Neighbourhood.Location = new System.Drawing.Point(532, 67);
            this.cb_Neighbourhood.Name = "cb_Neighbourhood";
            this.cb_Neighbourhood.Size = new System.Drawing.Size(121, 21);
            this.cb_Neighbourhood.TabIndex = 4;
            // 
            // cb_Periodic
            // 
            this.cb_Periodic.AutoSize = true;
            this.cb_Periodic.Location = new System.Drawing.Point(533, 95);
            this.cb_Periodic.Name = "cb_Periodic";
            this.cb_Periodic.Size = new System.Drawing.Size(67, 17);
            this.cb_Periodic.TabIndex = 3;
            this.cb_Periodic.Text = "Periodic ";
            this.cb_Periodic.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Neighbourhood";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_SRXnucleation
            // 
            this.tb_SRXnucleation.Location = new System.Drawing.Point(750, 449);
            this.tb_SRXnucleation.Name = "tb_SRXnucleation";
            this.tb_SRXnucleation.Size = new System.Drawing.Size(31, 20);
            this.tb_SRXnucleation.TabIndex = 31;
            this.tb_SRXnucleation.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(681, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "SRX Nucl";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toBMP,
            this.fromBMP,
            this.exportToTxtToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.programToolStripMenuItem.Text = "File ";
            // 
            // toBMP
            // 
            this.toBMP.Name = "toBMP";
            this.toBMP.Size = new System.Drawing.Size(167, 22);
            this.toBMP.Text = "Export to BMP";
            this.toBMP.Click += new System.EventHandler(this.toBMP_Click);
            // 
            // fromBMP
            // 
            this.fromBMP.Name = "fromBMP";
            this.fromBMP.Size = new System.Drawing.Size(167, 22);
            this.fromBMP.Text = "Import from BMP";
            this.fromBMP.Click += new System.EventHandler(this.fromBMP_Click);
            // 
            // exportToTxtToolStripMenuItem
            // 
            this.exportToTxtToolStripMenuItem.Name = "exportToTxtToolStripMenuItem";
            this.exportToTxtToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exportToTxtToolStripMenuItem.Text = "Export to txt";
            this.exportToTxtToolStripMenuItem.Click += new System.EventHandler(this.exportToTxtToolStripMenuItem_Click);
            // 
            // Boundariess
            // 
            this.Boundariess.AutoSize = true;
            this.Boundariess.Location = new System.Drawing.Point(536, 360);
            this.Boundariess.Name = "Boundariess";
            this.Boundariess.Size = new System.Drawing.Size(79, 17);
            this.Boundariess.TabIndex = 34;
            this.Boundariess.Text = "Boundaries";
            this.Boundariess.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Only boundaries";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "MC start beg";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MultiscaleModelling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Boundariess);
            this.Controls.Add(this.tb_SRXnucleation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.b_SRXMC);
            this.Controls.Add(this.tb_SRX_steps);
            this.Controls.Add(this.tb_MC_steps);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.b_MC);
            this.Controls.Add(this.cb_Ganywhere);
            this.Controls.Add(this.tb_Inc_nucleation);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_probability);
            this.Controls.Add(this.cb_SRX_method);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Periodic);
            this.Controls.Add(this.b_energy);
            this.Controls.Add(this.cb_toggle_energy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_HGenous);
            this.Controls.Add(this.tb_CountSquare);
            this.Controls.Add(this.tb_SRX_energy);
            this.Controls.Add(this.tb_Nucleation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.b_Circular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Square);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_After_simulation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_SquareDiameter);
            this.Controls.Add(this.b_Dualphase);
            this.Controls.Add(this.cb_Neighbourhood);
            this.Controls.Add(this.b_Substructure);
            this.Controls.Add(this.b_Random);
            this.Controls.Add(this.b_Clear);
            this.Controls.Add(this.b_Start);
            this.Controls.Add(this.VisualizationPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MultiscaleModelling";
            this.Text = "Grain Growth";
            this.Load += new System.EventHandler(this.MultiscaleModelling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VisualizationPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox VisualizationPictureBox;
        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.Button b_Clear;
        private System.Windows.Forms.Button b_Random;
        private System.Windows.Forms.TextBox tb_SquareDiameter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_After_simulation;
        private System.Windows.Forms.Button b_Circular;
        private System.Windows.Forms.Button b_Square;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_CountSquare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_probability;
        private System.Windows.Forms.Button b_Substructure;
        private System.Windows.Forms.Button b_Dualphase;
        private System.Windows.Forms.TextBox tb_MC_steps;
        private System.Windows.Forms.Button b_MC;
        private System.Windows.Forms.Button b_SRXMC;
        private System.Windows.Forms.ComboBox cb_SRX_method;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cb_toggle_energy;
        private System.Windows.Forms.Button b_energy;
        private System.Windows.Forms.CheckBox cb_HGenous;
        private System.Windows.Forms.TextBox tb_SRX_energy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Inc_nucleation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_SRX_steps;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cb_Ganywhere;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Nucleation;
        private System.Windows.Forms.ComboBox cb_Neighbourhood;
        private System.Windows.Forms.CheckBox cb_Periodic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SRXnucleation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toBMP;
        private System.Windows.Forms.ToolStripMenuItem fromBMP;
        private System.Windows.Forms.ToolStripMenuItem exportToTxtToolStripMenuItem;
        private System.Windows.Forms.CheckBox Boundariess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

