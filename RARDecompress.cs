using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecompressTool
{
    /// <summary>
    /// RAR类型文件解压类
    /// </summary>
    public class RARDecompress
    {
        private Unrar unrar;
        private int decompressPrecent;
        private string decompressFile;
        private bool isDeleteSourceFile;


        public void AttachHandlers(Unrar unrar)
        {
            unrar.ExtractionProgress += new ExtractionProgressHandler(unrar_ExtractionProgress);
            unrar.MissingVolume += new MissingVolumeHandler(unrar_MissingVolume);
            unrar.PasswordRequired += new PasswordRequiredHandler(unrar_PasswordRequired);
        }

        /// <summary>
        /// 指示文件的解压进度，用来更新
        /// </summary>
        public int DecompressPrecent
        {
            get { return decompressPrecent; }
            set { decompressPrecent = value; }
        }

        /// <summary>
        /// 正在解压的文件名称
        /// </summary>
        public string DecompressFile
        {
            get { return decompressFile; }
            set { decompressFile = value; }
        }

        /// <summary>
        /// 是否删除源文件（解压文件）
        /// </summary>
        public bool IsDeleteSourceFile
        {
            get { return isDeleteSourceFile; }
            set { isDeleteSourceFile = value; }
        }

        public void unrar_ExtractionProgress(object sender, ExtractionProgressEventArgs e)
        {
            decompressFile = e.FileName;
            decompressPrecent = (int)e.PercentComplete;
        }

        public void unrar_MissingVolume(object sender, MissingVolumeEventArgs e)
        {
            FrmTextInput dialog = new FrmTextInput();
            dialog.Value = e.VolumeName;
            dialog.Prompt = string.Format("信息丢失，继续或取消.");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                e.VolumeName = dialog.Value;
                e.ContinueOperation = true;
            }
            else
                e.ContinueOperation = false;
        }

        private void unrar_PasswordRequired(object sender, PasswordRequiredEventArgs e)
        {
            FrmTextInput dialog = new FrmTextInput();
            dialog.Prompt = string.Format("请输入密码");
            dialog.PasswordChar = '*';
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                e.Password = dialog.Value;
                e.ContinueOperation = true;
            }
            else
                e.ContinueOperation = false;
        }

    }

}
