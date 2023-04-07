using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf05_login
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPW_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if(TxtID.Text == ""|TxtPW.Text == "")
            {
                    Progress.Text = "다시 입력하세요.";
            }
            else if(TxtID.Text =="abcd"&TxtPW.Text == "1234")
            {
                Progress.Text = "로그인 성공";
            }
            else
            {
                Progress.Text = "로그인 실패";
            }
        }

        private void Progress_Click(object sender, EventArgs e)
        {

        }
    }
}
