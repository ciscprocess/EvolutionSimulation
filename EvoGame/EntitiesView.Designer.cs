namespace EvoGame
{
    partial class EntitiesView
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
            this.components = new System.ComponentModel.Container();
            this.aiData = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentBrainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aIEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.brainStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewBrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.aiData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIEntityBindingSource)).BeginInit();
            this.brainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // aiData
            // 
            this.aiData.AutoGenerateColumns = false;
            this.aiData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aiData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.parentBrainDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.generationDataGridViewTextBoxColumn});
            this.aiData.DataSource = this.aIEntityBindingSource;
            this.aiData.Location = new System.Drawing.Point(13, 13);
            this.aiData.Name = "aiData";
            this.aiData.Size = new System.Drawing.Size(544, 434);
            this.aiData.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // parentBrainDataGridViewTextBoxColumn
            // 
            this.parentBrainDataGridViewTextBoxColumn.DataPropertyName = "ParentBrain";
            this.parentBrainDataGridViewTextBoxColumn.HeaderText = "ParentBrain";
            this.parentBrainDataGridViewTextBoxColumn.Name = "parentBrainDataGridViewTextBoxColumn";
            this.parentBrainDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generationDataGridViewTextBoxColumn
            // 
            this.generationDataGridViewTextBoxColumn.DataPropertyName = "Generation";
            this.generationDataGridViewTextBoxColumn.HeaderText = "Generation";
            this.generationDataGridViewTextBoxColumn.Name = "generationDataGridViewTextBoxColumn";
            this.generationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aIEntityBindingSource
            // 
            this.aIEntityBindingSource.DataSource = typeof(EvoGame.AIEntity);
            // 
            // brainStrip
            // 
            this.brainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewBrainToolStripMenuItem});
            this.brainStrip.Name = "brainStrip";
            this.brainStrip.Size = new System.Drawing.Size(130, 26);
            // 
            // viewBrainToolStripMenuItem
            // 
            this.viewBrainToolStripMenuItem.Name = "viewBrainToolStripMenuItem";
            this.viewBrainToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.viewBrainToolStripMenuItem.Text = "View Brain";
            // 
            // EntitiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 459);
            this.Controls.Add(this.aiData);
            this.Name = "EntitiesView";
            this.Text = "EntitiesView";
            ((System.ComponentModel.ISupportInitialize)(this.aiData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIEntityBindingSource)).EndInit();
            this.brainStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView aiData;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentBrainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource aIEntityBindingSource;
        private System.Windows.Forms.ContextMenuStrip brainStrip;
        private System.Windows.Forms.ToolStripMenuItem viewBrainToolStripMenuItem;


    }
}