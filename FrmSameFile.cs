using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DecompressTool
{
    public partial class FrmSameFile : Form
    {
        private string dirName; 
        private string[] fileList;
        private string reNameDir;//文件夹重命名结果
        private SameNameFileProcessMode processMode = SameNameFileProcessMode.Skip;
        
        public FrmSameFile()
        {
            InitializeComponent();
            
        } 

        public string DirName
        {
            get { return dirName; }
            set { dirName = value; }
        }

        public string ReNameDir
        {
            get { return reNameDir; }
            set { reNameDir = value; }
        }

        public SameNameFileProcessMode ProcessMode
        {
            set { processMode = value; }
            get { return processMode; }
        }

        //替换
        private void btnReplace_Click(object sender, EventArgs e)
        {
            processMode = SameNameFileProcessMode.Replace;
            this.Close();
        }

        private void btnreName_Click(object sender, EventArgs e)
        {            
            processMode = SameNameFileProcessMode.ReName;
            //弹出重命名对话框
            FrmReName frmreName = new FrmReName();
            frmreName.DirName = dirName;
            frmreName.ShowDialog();
            if (frmreName.ReNameMode == ReNameMode.OK)
            {
                reNameDir = frmreName.ReNamedir;
                this.Close();
            }
              
        }
        private void btnSkip_Click(object sender, EventArgs e)
        {
            processMode = SameNameFileProcessMode.Skip;
            this.Close();
        }

        private void FrmSameFile_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(dirName))
            {
                fileList = Directory.GetFiles(dirName);
                listFile.Items.AddRange(fileList);
            }
        }

    }

    public enum SameNameFileProcessMode
    {
        Replace=0,
        ReName=1,
        Skip=2
    }
}
