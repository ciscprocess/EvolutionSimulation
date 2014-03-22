namespace LogicIO
{
    partial class FormControl
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
            this.listGens = new System.Windows.Forms.ListBox();
            this.grpOutputs = new System.Windows.Forms.GroupBox();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.grpDesOuput = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnMutate = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.mutateBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // listGens
            // 
            this.listGens.FormattingEnabled = true;
            this.listGens.Location = new System.Drawing.Point(11, 104);
            this.listGens.Name = "listGens";
            this.listGens.Size = new System.Drawing.Size(679, 186);
            this.listGens.TabIndex = 0;
            // 
            // grpOutputs
            // 
            this.grpOutputs.Location = new System.Drawing.Point(12, 57);
            this.grpOutputs.Name = "grpOutputs";
            this.grpOutputs.Size = new System.Drawing.Size(679, 41);
            this.grpOutputs.TabIndex = 1;
            this.grpOutputs.TabStop = false;
            this.grpOutputs.Text = "Best Output";
            // 
            // grpInputs
            // 
            this.grpInputs.Location = new System.Drawing.Point(12, 297);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(678, 44);
            this.grpInputs.TabIndex = 2;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "Inputs";
            // 
            // grpDesOuput
            // 
            this.grpDesOuput.Location = new System.Drawing.Point(12, 12);
            this.grpDesOuput.Name = "grpDesOuput";
            this.grpDesOuput.Size = new System.Drawing.Size(679, 44);
            this.grpDesOuput.TabIndex = 3;
            this.grpDesOuput.TabStop = false;
            this.grpDesOuput.Text = "Desired Output";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(697, 104);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Brain";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnMutate
            // 
            this.btnMutate.Location = new System.Drawing.Point(697, 134);
            this.btnMutate.Name = "btnMutate";
            this.btnMutate.Size = new System.Drawing.Size(150, 23);
            this.btnMutate.TabIndex = 5;
            this.btnMutate.Text = "Begin Mutating";
            this.btnMutate.UseVisualStyleBackColor = true;
            this.btnMutate.Click += new System.EventHandler(this.btnMutate_Click);
            // 
            // btnScore
            // 
            this.btnScore.Location = new System.Drawing.Point(697, 33);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(149, 23);
            this.btnScore.TabIndex = 6;
            this.btnScore.Text = "Score It";
            this.btnScore.UseVisualStyleBackColor = true;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            // 
            // mutateBar
            // 
            this.mutateBar.Location = new System.Drawing.Point(13, 363);
            this.mutateBar.Name = "mutateBar";
            this.mutateBar.Size = new System.Drawing.Size(834, 23);
            this.mutateBar.TabIndex = 7;
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 398);
            this.Controls.Add(this.mutateBar);
            this.Controls.Add(this.btnScore);
            this.Controls.Add(this.btnMutate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpDesOuput);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.grpOutputs);
            this.Controls.Add(this.listGens);
            this.Name = "FormControl";
            this.Text = "ControlPanel";
            this.ResumeLayout(false);

        }

        #endregion



        private System.Windows.Forms.ListBox listGens;
        private System.Windows.Forms.GroupBox grpOutputs;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.GroupBox grpDesOuput;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnMutate;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.ProgressBar mutateBar;
    }
}

