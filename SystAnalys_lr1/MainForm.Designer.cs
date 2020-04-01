namespace Graphs
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            this.buttonAdj = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.RadioButton();
            this.drawEdgeButton = new System.Windows.Forms.RadioButton();
            this.drawVertexButton = new System.Windows.Forms.RadioButton();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.buttonUnattainable = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.Location = new System.Drawing.Point(733, 72);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(224, 355);
            this.listBoxMatrix.TabIndex = 6;
            // 
            // buttonAdj
            // 
            this.buttonAdj.Location = new System.Drawing.Point(733, 14);
            this.buttonAdj.Name = "buttonAdj";
            this.buttonAdj.Size = new System.Drawing.Size(101, 43);
            this.buttonAdj.TabIndex = 7;
            this.buttonAdj.Text = "Matrix";
            this.buttonAdj.UseVisualStyleBackColor = true;
            this.buttonAdj.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Location = new System.Drawing.Point(12, 215);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(98, 45);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.Text = "Clear graph";
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.AutoSize = true;
            this.selectButton.Location = new System.Drawing.Point(6, 14);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(55, 17);
            this.selectButton.TabIndex = 13;
            this.selectButton.TabStop = true;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.drawEdgeButton);
            this.groupBox1.Controls.Add(this.drawVertexButton);
            this.groupBox1.Controls.Add(this.selectButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 106);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.Location = new System.Drawing.Point(6, 80);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 17);
            this.deleteButton.TabIndex = 16;
            this.deleteButton.TabStop = true;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.AutoSize = true;
            this.drawEdgeButton.Location = new System.Drawing.Point(6, 60);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(50, 17);
            this.drawEdgeButton.TabIndex = 15;
            this.drawEdgeButton.TabStop = true;
            this.drawEdgeButton.Text = "Edge";
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.AutoSize = true;
            this.drawVertexButton.Location = new System.Drawing.Point(6, 37);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(55, 17);
            this.drawVertexButton.TabIndex = 14;
            this.drawVertexButton.TabStop = true;
            this.drawVertexButton.Text = "Vertex";
            this.drawVertexButton.UseVisualStyleBackColor = true;
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(116, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(611, 415);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // buttonUnattainable
            // 
            this.buttonUnattainable.Location = new System.Drawing.Point(856, 12);
            this.buttonUnattainable.Name = "buttonUnattainable";
            this.buttonUnattainable.Size = new System.Drawing.Size(101, 43);
            this.buttonUnattainable.TabIndex = 15;
            this.buttonUnattainable.Text = "Show unattainable";
            this.buttonUnattainable.UseVisualStyleBackColor = true;
            this.buttonUnattainable.Click += new System.EventHandler(this.buttonUnattainable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 444);
            this.Controls.Add(this.buttonUnattainable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAdj);
            this.Controls.Add(this.listBoxMatrix);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.sheet);
            this.Name = "MainForm";
            this.Text = "vscode.ru";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.ListBox listBoxMatrix;
        private System.Windows.Forms.Button buttonAdj;
        private System.Windows.Forms.RadioButton selectButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton deleteButton;
        private System.Windows.Forms.RadioButton drawEdgeButton;
        private System.Windows.Forms.RadioButton drawVertexButton;
        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button buttonUnattainable;
    }
}

