namespace DecompressTool
{
    partial class FrmDecompress
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.tbxTarget = new System.Windows.Forms.TextBox();
            this.btnSource = new System.Windows.Forms.Button();
            this.btnTarget = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FileList = new System.Windows.Forms.ListView();
            this.clmRARFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModifyTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DcompressState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDecompress = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.IsContainSubfolder = new System.Windows.Forms.CheckBox();
            this.IsCreateRARFolder = new System.Windows.Forms.CheckBox();
            this.cbxDelSourceFile = new System.Windows.Forms.CheckBox();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "源文件夹:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件解压到：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxSource
            // 
            this.tbxSource.Location = new System.Drawing.Point(124, 16);
            this.tbxSource.Name = "tbxSource";
            this.tbxSource.Size = new System.Drawing.Size(546, 21);
            this.tbxSource.TabIndex = 3;
            // 
            // tbxTarget
            // 
            this.tbxTarget.Location = new System.Drawing.Point(124, 72);
            this.tbxTarget.Name = "tbxTarget";
            this.tbxTarget.Size = new System.Drawing.Size(546, 21);
            this.tbxTarget.TabIndex = 4;
            // 
            // btnSource
            // 
            this.btnSource.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSource.Location = new System.Drawing.Point(676, 14);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(58, 23);
            this.btnSource.TabIndex = 6;
            this.btnSource.Tag = "选择";
            this.btnSource.Text = "选择";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnTarget
            // 
            this.btnTarget.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTarget.Location = new System.Drawing.Point(676, 69);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(58, 23);
            this.btnTarget.TabIndex = 8;
            this.btnTarget.Tag = "选择";
            this.btnTarget.Text = "选择";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(21, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "解压文件列表：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FileList);
            this.panel1.Location = new System.Drawing.Point(24, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 288);
            this.panel1.TabIndex = 13;
            // 
            // FileList
            // 
            this.FileList.CheckBoxes = true;
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRARFileName,
            this.ModifyTime,
            this.DcompressState});
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.Location = new System.Drawing.Point(0, 0);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(710, 288);
            this.FileList.TabIndex = 0;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            // 
            // clmRARFileName
            // 
            this.clmRARFileName.Text = "文件名";
            this.clmRARFileName.Width = 446;
            // 
            // ModifyTime
            // 
            this.ModifyTime.Text = "修改时间";
            this.ModifyTime.Width = 162;
            // 
            // DcompressState
            // 
            this.DcompressState.Text = "解压状态";
            // 
            // btnDecompress
            // 
            this.btnDecompress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDecompress.Location = new System.Drawing.Point(16, 480);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(75, 23);
            this.btnDecompress.TabIndex = 14;
            this.btnDecompress.Text = "开始解压";
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(97, 485);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(637, 11);
            this.progressBar1.TabIndex = 15;
            // 
            // IsContainSubfolder
            // 
            this.IsContainSubfolder.AutoSize = true;
            this.IsContainSubfolder.Checked = true;
            this.IsContainSubfolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsContainSubfolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsContainSubfolder.Location = new System.Drawing.Point(124, 46);
            this.IsContainSubfolder.Name = "IsContainSubfolder";
            this.IsContainSubfolder.Size = new System.Drawing.Size(110, 18);
            this.IsContainSubfolder.TabIndex = 16;
            this.IsContainSubfolder.Text = "包含子文件夹";
            this.IsContainSubfolder.UseVisualStyleBackColor = true;
            this.IsContainSubfolder.CheckedChanged += new System.EventHandler(this.IsContainSubfolder_CheckedChanged);
            // 
            // IsCreateRARFolder
            // 
            this.IsCreateRARFolder.AccessibleDescription = "";
            this.IsCreateRARFolder.AutoSize = true;
            this.IsCreateRARFolder.Checked = true;
            this.IsCreateRARFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsCreateRARFolder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsCreateRARFolder.Location = new System.Drawing.Point(124, 104);
            this.IsCreateRARFolder.Name = "IsCreateRARFolder";
            this.IsCreateRARFolder.Size = new System.Drawing.Size(159, 18);
            this.IsCreateRARFolder.TabIndex = 17;
            this.IsCreateRARFolder.Text = "按RAR文件创建文件夹";
            this.IsCreateRARFolder.UseVisualStyleBackColor = true;
            this.IsCreateRARFolder.CheckedChanged += new System.EventHandler(this.IsCreateRARFolder_CheckedChanged);
            // 
            // cbxDelSourceFile
            // 
            this.cbxDelSourceFile.AutoSize = true;
            this.cbxDelSourceFile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDelSourceFile.Location = new System.Drawing.Point(24, 134);
            this.cbxDelSourceFile.Name = "cbxDelSourceFile";
            this.cbxDelSourceFile.Size = new System.Drawing.Size(194, 18);
            this.cbxDelSourceFile.TabIndex = 18;
            this.cbxDelSourceFile.Text = "是否删除解压成功的源文件";
            this.cbxDelSourceFile.UseVisualStyleBackColor = true;
            this.cbxDelSourceFile.CheckedChanged += new System.EventHandler(this.IsDelRARFile_CheckedChanged);
            // 
            // FrmDecompress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 512);
            this.Controls.Add(this.cbxDelSourceFile);
            this.Controls.Add(this.IsCreateRARFolder);
            this.Controls.Add(this.IsContainSubfolder);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.tbxTarget);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDecompress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量解压小工具";
            this.Load += new System.EventHandler(this.FrmDecompress_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.TextBox tbxTarget;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.ColumnHeader clmRARFileName;
        private System.Windows.Forms.ColumnHeader DcompressState;
        private System.Windows.Forms.Button btnDecompress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox IsContainSubfolder;
        private System.Windows.Forms.CheckBox IsCreateRARFolder;
        private System.Windows.Forms.ColumnHeader ModifyTime;
        private System.Windows.Forms.CheckBox cbxDelSourceFile;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}

