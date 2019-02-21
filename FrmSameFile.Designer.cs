namespace DecompressTool
{
    partial class FrmSameFile
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
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnreName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listFile = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReplace
            // 
            this.btnReplace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReplace.Location = new System.Drawing.Point(35, 183);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 25);
            this.btnReplace.TabIndex = 0;
            this.btnReplace.Tag = "将原有解压文件替换";
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSkip.Location = new System.Drawing.Point(233, 183);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 25);
            this.btnSkip.TabIndex = 1;
            this.btnSkip.Text = "跳过";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnreName
            // 
            this.btnreName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnreName.Location = new System.Drawing.Point(134, 183);
            this.btnreName.Name = "btnreName";
            this.btnreName.Size = new System.Drawing.Size(75, 25);
            this.btnreName.TabIndex = 2;
            this.btnreName.Text = "重命名";
            this.btnreName.UseVisualStyleBackColor = true;
            this.btnreName.Click += new System.EventHandler(this.btnreName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "下列文件已存在:";
            // 
            // listFile
            // 
            this.listFile.FormattingEnabled = true;
            this.listFile.HorizontalScrollbar = true;
            this.listFile.ItemHeight = 12;
            this.listFile.Location = new System.Drawing.Point(16, 34);
            this.listFile.Name = "listFile";
            this.listFile.Size = new System.Drawing.Size(331, 112);
            this.listFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "请确认操作方式:";
            // 
            // FrmSameFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 213);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnreName);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnReplace);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSameFile";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "确认文件替换";
            this.Load += new System.EventHandler(this.FrmSameFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnreName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listFile;
        private System.Windows.Forms.Label label2;
    }
}