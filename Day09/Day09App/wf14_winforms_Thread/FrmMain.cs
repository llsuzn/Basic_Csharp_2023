using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf14_winforms_Thread
{
    public partial class FrmMain : Form
    {
        int number = 0;
        int percent = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = false;   // 시작버튼은 종료시까지 누르지 못 함
            BtnCancel.Enabled = true;

            number = int.Parse(TxtNumber.Text);

            percent = 0;
            PgbCalculate.Value = percent;
            Worker.RunWorkerAsync(number);      // 비동기로 진행
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Worker.CancelAsync();       // 비동기로 취소하라고 요청
            BtnCancel.Enabled = false;
            BtnStart.Enabled=true;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 백그라운드로 일 진행 ==> Thread.Start()와 같음

            BackgroundWorker worker = sender as BackgroundWorker;   // 인자값으로 BackgroundWorker 생성... 얕은복사라 Worker랑 주소 참조

            e.Result = Fibonacci((int)e.Argument, worker, e);   // 피보나치 계산 메소드
        }

        private long Fibonacci(int arg, BackgroundWorker worker, DoWorkEventArgs e)
        {
            // arg는  0~91 사이... 91보다 크면 long 오버플로우 발생
            if (arg < 0 || arg > 91) 
            {
                throw new Exception("오류 0~91사이 입력");
            }
            long result = 0;
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                if (arg < 2)
                {
                    result = 1;
                }
                else
                {
                    // arg만 계산에 필요한 매개변수. worker, e 는 중간에 취소할 때 필요한 Background 복사본
                    result = Fibonacci(arg - 1,worker, e) + Fibonacci(arg - 2,worker, e);
                }

                // 진행상황을 프로그래스바에 표시
                int persentComplete = (int)(arg / number * 100);
                if(persentComplete > percent)
                {
                    percent = persentComplete;
                    worker.ReportProgress(persentComplete);     // ProgressChanged 이벤트 발생
                }
            }
            return result;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 백그라운드 스레드 진행중 프로그래스 표시
            PgbCalculate.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 백그라운드 스레드 테스크 종료한 뒤 처리
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if(e.Cancelled)
            {
                LblResult.Text = "취소됨";
            }
            else
            {
                LblResult.Text = e.Result.ToString();
            }

            TxtNumber.Text = 0.ToString();
            BtnStart.Enabled = true;
            BtnCancel.Enabled = false;

        }
    }
}
