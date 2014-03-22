namespace EvoGame
{
    partial class GameForm
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
            this.gfxPanel = new System.Windows.Forms.Panel();
            this.mainStrip = new System.Windows.Forms.StatusStrip();
            this.entCountLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.entCountVal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAvgGen = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtAvgGen = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeVal = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializeToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deserializeFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setInitialParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continueSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiteEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.grpEnvironment = new System.Windows.Forms.GroupBox();
            this.btnNuke = new System.Windows.Forms.Button();
            this.lblDayInt = new System.Windows.Forms.Label();
            this.numDayInt = new System.Windows.Forms.NumericUpDown();
            this.dlgDeserialize = new System.Windows.Forms.OpenFileDialog();
            this.dlgSerialize = new System.Windows.Forms.SaveFileDialog();
            this.lblSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.grpEnvironment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDayInt)).BeginInit();
            this.SuspendLayout();
            // 
            // gfxPanel
            // 
            this.gfxPanel.Location = new System.Drawing.Point(12, 27);
            this.gfxPanel.Name = "gfxPanel";
            this.gfxPanel.Size = new System.Drawing.Size(1100, 600);
            this.gfxPanel.TabIndex = 0;
            this.gfxPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gfxPanel_Paint);
            // 
            // mainStrip
            // 
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entCountLbl,
            this.entCountVal,
            this.lblAvgGen,
            this.txtAvgGen,
            this.lblSpeed,
            this.txtSpeed,
            this.stripSpacer,
            this.timeLbl,
            this.timeVal});
            this.mainStrip.Location = new System.Drawing.Point(0, 670);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(1130, 22);
            this.mainStrip.TabIndex = 3;
            this.mainStrip.Text = "statusStrip1";
            // 
            // entCountLbl
            // 
            this.entCountLbl.Name = "entCountLbl";
            this.entCountLbl.Size = new System.Drawing.Size(109, 17);
            this.entCountLbl.Text = "Number of Entities:";
            // 
            // entCountVal
            // 
            this.entCountVal.Name = "entCountVal";
            this.entCountVal.Size = new System.Drawing.Size(17, 17);
            this.entCountVal.Text = "--";
            // 
            // lblAvgGen
            // 
            this.lblAvgGen.Name = "lblAvgGen";
            this.lblAvgGen.Size = new System.Drawing.Size(55, 17);
            this.lblAvgGen.Text = "Avg Gen:";
            // 
            // txtAvgGen
            // 
            this.txtAvgGen.Name = "txtAvgGen";
            this.txtAvgGen.Size = new System.Drawing.Size(17, 17);
            this.txtAvgGen.Text = "--";
            // 
            // stripSpacer
            // 
            this.stripSpacer.Name = "stripSpacer";
            this.stripSpacer.Size = new System.Drawing.Size(707, 17);
            this.stripSpacer.Spring = true;
            // 
            // timeLbl
            // 
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(64, 17);
            this.timeLbl.Text = "Run Time: ";
            // 
            // timeVal
            // 
            this.timeVal.Name = "timeVal";
            this.timeVal.Size = new System.Drawing.Size(17, 17);
            this.timeVal.Text = "--";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1130, 24);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializeToFileToolStripMenuItem,
            this.deserializeFromFileToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // serializeToFileToolStripMenuItem
            // 
            this.serializeToFileToolStripMenuItem.Name = "serializeToFileToolStripMenuItem";
            this.serializeToFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.serializeToFileToolStripMenuItem.Text = "Serialize to File";
            this.serializeToFileToolStripMenuItem.Click += new System.EventHandler(this.serializeToFileToolStripMenuItem_Click);
            // 
            // deserializeFromFileToolStripMenuItem
            // 
            this.deserializeFromFileToolStripMenuItem.Name = "deserializeFromFileToolStripMenuItem";
            this.deserializeFromFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.deserializeFromFileToolStripMenuItem.Text = "Deserialize from File";
            this.deserializeFromFileToolStripMenuItem.Click += new System.EventHandler(this.deserializeFromFileToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setInitialParametersToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // setInitialParametersToolStripMenuItem
            // 
            this.setInitialParametersToolStripMenuItem.Name = "setInitialParametersToolStripMenuItem";
            this.setInitialParametersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.setInitialParametersToolStripMenuItem.Text = "Set Initial Parameters";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewSimulationToolStripMenuItem,
            this.pauseSimulationToolStripMenuItem,
            this.continueSimulationToolStripMenuItem,
            this.smiteEntityToolStripMenuItem,
            this.feedEntityToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // startNewSimulationToolStripMenuItem
            // 
            this.startNewSimulationToolStripMenuItem.Name = "startNewSimulationToolStripMenuItem";
            this.startNewSimulationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.startNewSimulationToolStripMenuItem.Text = "Start New Simulation";
            this.startNewSimulationToolStripMenuItem.Click += new System.EventHandler(this.startNewSimulationToolStripMenuItem_Click);
            // 
            // pauseSimulationToolStripMenuItem
            // 
            this.pauseSimulationToolStripMenuItem.Name = "pauseSimulationToolStripMenuItem";
            this.pauseSimulationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pauseSimulationToolStripMenuItem.Text = "Pause Simulation";
            this.pauseSimulationToolStripMenuItem.Click += new System.EventHandler(this.pauseSimulationToolStripMenuItem_Click);
            // 
            // continueSimulationToolStripMenuItem
            // 
            this.continueSimulationToolStripMenuItem.Name = "continueSimulationToolStripMenuItem";
            this.continueSimulationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.continueSimulationToolStripMenuItem.Text = "Continue Simulation";
            this.continueSimulationToolStripMenuItem.Click += new System.EventHandler(this.continueSimulationToolStripMenuItem_Click);
            // 
            // smiteEntityToolStripMenuItem
            // 
            this.smiteEntityToolStripMenuItem.Name = "smiteEntityToolStripMenuItem";
            this.smiteEntityToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.smiteEntityToolStripMenuItem.Text = "Smite Entity";
            this.smiteEntityToolStripMenuItem.Click += new System.EventHandler(this.smiteEntityToolStripMenuItem_Click);
            // 
            // feedEntityToolStripMenuItem
            // 
            this.feedEntityToolStripMenuItem.Name = "feedEntityToolStripMenuItem";
            this.feedEntityToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.feedEntityToolStripMenuItem.Text = "Feed Entity";
            this.feedEntityToolStripMenuItem.Click += new System.EventHandler(this.feedEntityToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entitiesToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.entitiesToolStripMenuItem.Text = "Entities";
            this.entitiesToolStripMenuItem.Click += new System.EventHandler(this.entitiesToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(12, 633);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1100, 34);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Environment";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 14);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // grpEnvironment
            // 
            this.grpEnvironment.Controls.Add(this.btnNuke);
            this.grpEnvironment.Controls.Add(this.lblDayInt);
            this.grpEnvironment.Controls.Add(this.numDayInt);
            this.grpEnvironment.Location = new System.Drawing.Point(12, 627);
            this.grpEnvironment.Name = "grpEnvironment";
            this.grpEnvironment.Size = new System.Drawing.Size(1100, 40);
            this.grpEnvironment.TabIndex = 5;
            this.grpEnvironment.TabStop = false;
            this.grpEnvironment.Text = "Environment";
            // 
            // btnNuke
            // 
            this.btnNuke.Location = new System.Drawing.Point(181, 14);
            this.btnNuke.Name = "btnNuke";
            this.btnNuke.Size = new System.Drawing.Size(75, 23);
            this.btnNuke.TabIndex = 2;
            this.btnNuke.Text = "Nuke";
            this.btnNuke.UseVisualStyleBackColor = true;
            this.btnNuke.Click += new System.EventHandler(this.btnNuke_Click);
            // 
            // lblDayInt
            // 
            this.lblDayInt.AutoSize = true;
            this.lblDayInt.Location = new System.Drawing.Point(6, 16);
            this.lblDayInt.Name = "lblDayInt";
            this.lblDayInt.Size = new System.Drawing.Size(67, 13);
            this.lblDayInt.TabIndex = 1;
            this.lblDayInt.Text = "Day Interval:";
            // 
            // numDayInt
            // 
            this.numDayInt.Location = new System.Drawing.Point(79, 14);
            this.numDayInt.Name = "numDayInt";
            this.numDayInt.Size = new System.Drawing.Size(65, 20);
            this.numDayInt.TabIndex = 0;
            this.numDayInt.ValueChanged += new System.EventHandler(this.numDayInt_ValueChanged);
            // 
            // dlgDeserialize
            // 
            this.dlgDeserialize.Filter = "EvoGame data Files|*.edt";
            // 
            // dlgSerialize
            // 
            this.dlgSerialize.Filter = "EvoGame data Files|*.edt";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(81, 17);
            this.lblSpeed.Text = "Performance: ";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(17, 17);
            this.txtSpeed.Text = "--";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 692);
            this.Controls.Add(this.grpEnvironment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainStrip);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.gfxPanel);
            this.MainMenuStrip = this.mainMenu;
            this.MaximumSize = new System.Drawing.Size(1146, 730);
            this.MinimumSize = new System.Drawing.Size(1146, 730);
            this.Name = "GameForm";
            this.Text = "EvoBonanza";
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.grpEnvironment.ResumeLayout(false);
            this.grpEnvironment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDayInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gfxPanel;
        private System.Windows.Forms.StatusStrip mainStrip;
        private System.Windows.Forms.ToolStripStatusLabel entCountLbl;
        private System.Windows.Forms.ToolStripStatusLabel entCountVal;
        private System.Windows.Forms.ToolStripStatusLabel stripSpacer;
        private System.Windows.Forms.ToolStripStatusLabel timeLbl;
        private System.Windows.Forms.ToolStripStatusLabel timeVal;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializeToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deserializeFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setInitialParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiteEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox grpEnvironment;
        private System.Windows.Forms.Label lblDayInt;
        private System.Windows.Forms.NumericUpDown numDayInt;
        private System.Windows.Forms.ToolStripMenuItem feedEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueSimulationToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgDeserialize;
        private System.Windows.Forms.SaveFileDialog dlgSerialize;
        private System.Windows.Forms.ToolStripStatusLabel lblAvgGen;
        private System.Windows.Forms.ToolStripStatusLabel txtAvgGen;
        private System.Windows.Forms.Button btnNuke;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblSpeed;
        private System.Windows.Forms.ToolStripStatusLabel txtSpeed;
    }
}

