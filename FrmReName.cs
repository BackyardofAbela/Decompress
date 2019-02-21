using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecompressTool
{
    public partial class FrmReName : Form
    {
        private string dirName;
        private string reNamedir;
        private ReNameMode renameMode;

        public FrmReName()
        {
            InitializeComponent();
        }

        public ReNameMode ReNameMode
        {
            get { return renameMode; }
            set { renameMode = value; }
        }

        public string DirName
        {
            get { return dirName; }
            set { dirName = value; }
        }

        public string ReNamedir
        {
            get { return reNamedir; }
            set { reNamedir = value; }
        }

        private void FrmReName_Load(object sender, EventArgs e)
        {
            this.tBxOrigionDir.Text = dirName;
            this.tBxModifyDir.Text = dirName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string rename = this.tBxModifyDir.Text;
            if (dirName.Equals(rename))
            {
                rename = rename + "_new";
            }
            reNamedir = rename;
            renameMode = ReNameMode.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            renameMode = ReNameMode.Cancel;
            this.Close();
        }
    }

    public enum ReNameMode
    {
        OK,//对文件夹进行重命名
        Cancel //取消对文件夹的重命名
    }
}
