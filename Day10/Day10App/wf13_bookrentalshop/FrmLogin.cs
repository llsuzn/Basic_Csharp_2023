using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmLogin : Form
    {
        private bool IsLogined = false;     //  로그인 성공했는지 여부
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            IsLogined = LoginProcess();     // 로그인을 성공해야만 true가 됨

            if (IsLogined) this.Close();
            else return;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            Environment.Exit(0);    // 가장 완벽하게 프로그램을 종료
        }
        // 아이디에서 엔터치면 비밀번호로
        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }
        //비밀번호에서 엔터치면 로그인
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnLogin_Click(sender, e);  // 버튼 클릭 이벤트 핸들러 호출
            }
        }
        /// <summary>
        /// DB userTbl에서 정보확인 로그인처리
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool LoginProcess()
        {
            // Validation check
            if(string.IsNullOrEmpty(TxtUserId.Text))
            {
                MessageBox.Show("유저아이디를 입력하세요","오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("비밀번호를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string strUserId = "";
            string strPassword = "";

            try
            {
                // string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=815301";
                // DB처리
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    conn.Open();

                    #region <DB쿼리를 위한 구성>
                    string selQuery = @"SELECT  userId
                                        	  , password
                                           FROM usertbl
                                          WHERE userID = @userID
                                            AND password = @password";
                    MySqlCommand selcmd = new MySqlCommand(selQuery, conn);
                    // @userID, @password 파라미터 할당
                    MySqlParameter prmUserID = new MySqlParameter("@userID", TxtUserId.Text);
                    MySqlParameter prmPassword = new MySqlParameter("@password", TxtPassword.Text);
                    selcmd.Parameters.Add(prmUserID);
                    selcmd.Parameters.Add(prmPassword);
                    #endregion

                    MySqlDataReader reader = selcmd.ExecuteReader();    //실행한 다음에 userId, password
                    if(reader.Read())
                    {
                        strUserId = reader["userId"] != null ? reader["userId"].ToString() : "-";
                        strPassword = reader["password"] != null ? reader["password"].ToString() : "-";
                        Commons.LoginID = strUserId; //프로그램 전체에서 사용

                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"로그인 정보가 없습니다.","오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Commons.LoginID = string.Empty; // 비상용

                        return false;
                    }

                } // conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show($"비정상적인 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }

        // 이게 없으면 X버튼이나 Alt+F4 로 종료했을때 메인폼이 나타남
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(IsLogined !=true)    //로그인 안되었을때 창을 닫으면 프로그램 모두 종료
            {
                Environment.Exit(0 );
            }
        }

    }
}
