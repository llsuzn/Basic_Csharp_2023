using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
        Random rnd = new Random();        //45까지 하나 고를수 있는 랜덤 만들어짐

        public FrmMain()
        {
            InitializeComponent();
            // 생성자는 되도록 설정부분을 넣지않을것
            // Form_Load() 이벤트 핸들러에 작성할 것
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList();   //내 OS 폰트 이름 가져오기
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }
            //글자크기 최솟값, 최댓값 지정
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;
            //텍스트박스 초기화
            TxtResult.Text = "Hello WinForm!!";

            NudFontSize.Value = 9; // 글자체 크기를 9로 지정
        }

        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 279;  // 디폴트 : 나눔고딕 지정
            }

            FontStyle style = FontStyle.Regular; // 기본
            if (ChkBold.Checked == true)
            {
                style |= FontStyle.Bold;
            }
            if (ChkItalic.Checked == true)
            {
                style |= FontStyle.Italic;
            }
            decimal fontSize = NudFontSize.Value;
            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize, style);

        }

        void ChangeIndent()
        {

            if (RdoNormal.Checked)
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (RdoIndent.Checked)
            {
                TxtResult.Text = "   " + TxtResult.Text;
            }
        }

        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }


        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.AliceBlue,
                StartPosition = FormStartPosition.CenterParent,
            };
            frm.ShowDialog();   //모달방식으로 자식창 띄우기 (자식창 실행 시 부모창 접근 X)
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen,     // Modaless는 CenterParent 안먹힘
                BackColor = Color.GreenYellow
            };
            frm.Show(); //모달리스 방식으로 자식창 띄우기 (자식창과 부모창 모두 동시에 접근 가능)
        }

        // 기본적으로 MessageBox는 모달
        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TxtResult.Text);        // 기본
            //MessageBox.Show(TxtResult.Text, caption: "메시지 창^00^"); // 캡션 사용방법
            
            //MessageBox.Show(TxtResult.Text, "메시지 창^00^",MessageBoxButtons.AbortRetryIgnore);  // 버튼추가
            //MessageBox.Show(TxtResult.Text, "메시지 창^00^", MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Information);  //아이콘추가
            
            MessageBox.Show(TxtResult.Text, "메시지 창^00^", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                           ,MessageBoxDefaultButton.Button2); // 디폴트버튼 설정
            
            //MessageBox.Show(TxtResult.Text, "메시지 창^00^", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information
            //               , MessageBoxDefaultButton.Button2,MessageBoxOptions.RtlReading); // 문자 정렬 방식(왼쪽으로 함)
            

        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(45).ToString());      //rnd는 위에서 만들었음
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if(TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(45, 100).ToString());
                TrvDummy.SelectedNode.Expand();         //트리노드 하위 펼쳐주기 ... 반대 .Expand() <=> .Collapse()
                TreeToList();
            }
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();     //리스트뷰, 트리뷰 등 뷰에 들어있는 모든 아이템을 제거하는 초기화 메소드
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(new ListViewItem(new[] { item.Text, item.FullPath.ToString() }));

            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node);       //재귀호출
            }
        }

        private void RdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            
            ChangeIndent();
        }

        private void RdoIndent_CheckedChanged_1(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cream.png");
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if(PcbDummy.SizeMode == PictureBoxSizeMode.Normal)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Normal;
            }
        }


    }
}
