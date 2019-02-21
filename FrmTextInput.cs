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
    public partial class FrmTextInput : Form
    {
        public FrmTextInput()
        {
            InitializeComponent();
        }

        private string defaultValue=string.Empty;


		public string Value
		{
			get
			{
				return(InputValue.Text);
			}
			set
			{
				if(value!=InputValue.Text)
				{
					InputValue.Text=value;
					InputValue.SelectionStart=value.Length;
					InputValue.SelectionLength=0;
					defaultValue=value;
				}
			}
		}

		public string Prompt
		{
			get
			{
				return(this.Text);
			}
			set
			{
				this.Text=value;
			}
		}

		public char PasswordChar
		{
			get
			{
				return InputValue.PasswordChar;
			}
			set
			{
				InputValue.PasswordChar=value;
			}
		}

		public void SelectAll()
		{
			InputValue.SelectAll();
		}
    }
}
