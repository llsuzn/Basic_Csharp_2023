using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmBooks : Form
    {
        bool isNew = false;     // false(UPDATA) / true(INSERT)

        #region <생성자>
        public FrmBooks()
        {
            InitializeComponent();
        }
        #endregion

        #region <이벤트 핸들러>
        private void FrmGenre_Load(object sender, EventArgs e)
        {
            isNew = true; // 신규부터 시작
            RefreshData();
            LoadCboData();  //콤보박스에 들어갈 데이터 로드

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
        }


        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() != true) return;  // 입력검증
            SaveData();         //데이터 저장 / 수정
            RefreshData();  //데이터 재조회
            ClearInputs();  //입력창 클리어
        } 
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if(isNew == true)       //신규
            {
                MessageBox.Show("삭제할 데이터를 선택하세요", "오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // FK 제약조건으로 지울 수 없는 데이터인지 먼저 확인
            using (MySqlConnection conn = new MySqlConnection(Commons.ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string strChkQuery = "SELECT COUNT(*) FROM rentaltbl WHERE bookIdx = @bookIdx";
                MySqlCommand chkcmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);  
                chkcmd.Parameters.Add(prmBookIdx);

                var result = chkcmd.ExecuteScalar();

                if (result.ToString() != "0")
                {
                    MessageBox.Show("이미 대여중인 책입니다.","삭제",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
            }

            //삭제여부를 물을 때 아니오를 누르면 삭제진행 취소
            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            // Yes를 누르면 계속 진행
            DeleteData();   // 데이터 삭제 처리
            RefreshData();  // 지우고나서 재조회
            ClearInputs();  // 입력창 데이터 지우기
        }
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 그리드뷰 클릭시 발생하는 이벤트
            if(e.RowIndex > -1) // 아무것도 선택 안하면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex];
                // Debug.WriteLine(selData.ToString());
                Debug.WriteLine(selData.Cells[0].Value);
                Debug.WriteLine(selData.Cells[1].Value);
                TxtBookIdx.Text = selData.Cells[0].Value.ToString();
                TxtAuthor.Text = selData.Cells[1].Value.ToString();
                CboDivision.SelectedValue = selData.Cells[2].Value; // B001 == B001
                // selData.Cells[3] 사용 안 함
                TxtNames.Text = selData.Cells[4].Value.ToString();
                DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
                TxtISBN.Text = selData.Cells[6].Value.ToString();
                NudPrice.Text = selData.Cells[7].Value.ToString();

                isNew = false;      //수정
            }
        }
        private void DgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvResult.ClearSelection();     // 최초에 첫번째 열 첫번째 셀 선택된 것 해제
        }

        #endregion

        #region< 커스텀 메서드 >
        private void RefreshData()
        {
            // DB divtbl 데이터 조회 DgvResult 뿌림
            try
            {
                //string connectionString = "\"Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=815301";
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // 쿼리 작성
                    var selQuery = @"SELECT b.bookIdx,
                                            b.Author,
                                            b.Division,
                                            d.Names AS DivNames,
                                            b.Names,
                                            b.ReleaseDate,
                                            b.ISBN,
                                            b.Price
                                       FROM bookstbl AS b
                                      INNER JOIN divtbl AS d
                                         ON b.Division = d.Division
                                      ORDER BY b.bookIdx ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");      // bookstbl으로 DataSet 접근 가능

                    //방법1
                    DgvResult.DataSource = ds.Tables[0];


                    //방법2
                    /*DgvResult.DataSource = ds;
                    DgvResult.DataMember = "divtbl";*/


                    // 데이터 그리드뷰 컬럼 헤더 제목
                    DgvResult.Columns[0].HeaderText = "책번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책코드";
                    DgvResult.Columns[3].HeaderText = "책장르";
                    DgvResult.Columns[4].HeaderText = "책제목";
                    DgvResult.Columns[5].HeaderText = "출판일자";
                    DgvResult.Columns[6].HeaderText = "ISBN";
                    DgvResult.Columns[7].HeaderText = "책가격";


                    // 컬럼 높이 또는 보이기
                    DgvResult.Columns[0].Width = 55;
                    DgvResult.Columns[2].Visible = false; // 코드 영역 보일 필요 없음
                    DgvResult.Columns[5].Width = 80;
                    DgvResult.Columns[7].Width = 80;

                    // 컬럼 정렬
                    DgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DgvResult.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DgvResult.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RefreshData() 비정상적인 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;
            // 입력검증
            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                result = false;
                errorMsg += "※ 저자명을 입력하세요.\n";
            }
            if (CboDivision.SelectedIndex < 0)
            {
                result = false;
                errorMsg += "※ 장르를  선택하세요.\n";
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "※ 책제목을 입력하세요.\n";
            }
            if (DtpReleaseDate.Value == null)
            {
                result = false;
                errorMsg += "※ 출판일자를 선택하세요.\n";
            }
            if (result == false)
            {
                MessageBox.Show(errorMsg,"오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;
            }
        }
        private void ClearInputs()
        {
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtNames.Text = TxtISBN.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            TxtAuthor.Focus();
            isNew = true;   // 신규
        }
        private void SaveData() // isNew가 True ==> INSERT / false ==> UPDATE
        {
            // INSERT부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = "";

                    if (isNew)
                    {
                        query = @"INSERT INTO bookstbl
                                             (Author,
                                              Division,
                                              Names,
                                              ReleaseDate,
                                              ISBN,
                                              Price)
                                             VALUES
                                             (@Author,
                                              @Division,
                                              @Names,
                                              @ReleaseDate,
                                              @ISBN,
                                              @Price)";
                    }
                    else
                    {
                        query = @"UPDATE bookstbl
                                     SET Author = @Author,
                                         Division = @Division,
                                         Names = @Names,
	                                     ReleaseDate = @ReleaseDate,
	                                     ISBN = @ISBN,
	                                     Price= @Price
                                   WHERE bookIdx = @bookIdx";
                    }
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmAuthor = new MySqlParameter("@Author", TxtAuthor.Text);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", CboDivision.SelectedValue.ToString());
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    MySqlParameter prmReleaseDate = new MySqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    MySqlParameter prmISBN = new MySqlParameter("@ISBN", TxtISBN.Text);
                    MySqlParameter prmPrice = new MySqlParameter("@Price", NudPrice.Value);
                    
                    cmd.Parameters.Add(prmAuthor);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);
                    cmd.Parameters.Add(prmReleaseDate);
                    cmd.Parameters.Add(prmISBN);
                    cmd.Parameters.Add(prmPrice);

                    if (isNew == false)     // UPDATE 할 땐 bookIdx 파라미터를 추가
                    {
                        MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
                    }

                    var result = cmd.ExecuteNonQuery();    // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 저장성공
                        MessageBox.Show("저장성공!!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 저장실패
                        MessageBox.Show("저장실패!!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SaveData() 비정상적인 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }
        private void DeleteData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"DELETE FROM bookstbl
	                                   WHERE bookIdx = @bookIdx";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                    cmd.Parameters.Add(prmBookIdx);

                    var result = cmd.ExecuteNonQuery();    // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 저장성공
                        MessageBox.Show("삭제성공!!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 저장실패
                        MessageBox.Show("삭제실패!!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DeleteData() 비정상적인 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCboData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.ConnString))
                {
                    if(conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    var query = "SELECT Division, Names FROM divtbl";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString());   // (key)B001, (value)공포/스릴러
                    }
                    // 콤보박스에 할당
                    CboDivision.DataSource = new BindingSource(temp, null); //divtbl은 null로 써도 무방
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"LoadCboData() 비정상적인 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
