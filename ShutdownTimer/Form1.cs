using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ShutdownTimer
{
    public partial class Form1 : Form
    {

        private bool isShutdownScheduled = false;
        private int timeRemaining = 0; // 남은 시간 (초 단위)

        // 타이머 선언
        private System.Windows.Forms.Timer countdownTimer;

        public Form1()
        {
            InitializeComponent();
            // 타이머 초기화
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1초마다 타이머 실행
            countdownTimer.Tick += CountdownTimer_Tick; // 타이머 틱 이벤트 핸들러

/*
            this.label1 = new Label();
            this.txtTimeInput = new TextBox();
            this.btnSetShutdown = new Button();
            this.btnCancelShutdown = new Button();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "예약 시간 (분):";

            // txtTimeInput
            this.txtTimeInput.Location = new System.Drawing.Point(120, 18);
            this.txtTimeInput.Size = new System.Drawing.Size(100, 23);

            // btnSetShutdown (종료 예약 버튼)
            this.btnSetShutdown.Location = new System.Drawing.Point(20, 60);
            this.btnSetShutdown.Size = new System.Drawing.Size(90, 30);
            this.btnSetShutdown.Text = "종료 예약";
            this.btnSetShutdown.Click += new EventHandler(this.btnSetShutdown_Click);

            // btnCancelShutdown (예약 취소 버튼)
            this.btnCancelShutdown.Location = new System.Drawing.Point(130, 60);
            this.btnCancelShutdown.Size = new System.Drawing.Size(90, 30);
            this.btnCancelShutdown.Text = "예약 취소";
            this.btnCancelShutdown.Click += new EventHandler(this.btnCancelShutdown_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(250, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimeInput);
            this.Controls.Add(this.btnSetShutdown);
            this.Controls.Add(this.btnCancelShutdown);
            this.Text = "Shutdown Timer";
 */
        }

        // 타이머 틱 이벤트 핸들러
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (isShutdownScheduled)
            {
                timeRemaining--; // 1초씩 감소
                int minutesRemaining = timeRemaining / 60; // 남은 시간(분)
                int secondsRemaining = timeRemaining % 60; // 남은 시간(초)

                // 레이블 업데이트
                labelTimeRemaining.Text = $"남은 시간: {minutesRemaining}분 {secondsRemaining}초";

                // 종료 예약이 완료되면 타이머 중지
                if (timeRemaining <= 0)
                {
                    countdownTimer.Stop();  // 타이머 중지
                    isShutdownScheduled = false;  // 예약 취소
                    labelTimeRemaining.Text = "종료 예약이 완료되었습니다."; // 레이블에 상태 표시
                }
            }
        }

        private void btnSetShutdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtTimeInput.Text, out int minutes) && minutes > 0)
                {
                    int seconds = minutes * 60; // 분 -> 초 변환
                    string command = $"shutdown -s -t {seconds}"; // 종료 예약 명령어 실행
                    txtTimeInput.Text = "";
                    this.ActiveControl = null;

                    Process.Start("cmd.exe", "/C " + command);
                    isShutdownScheduled = true;  // 예약된 상태로 변경
                    timeRemaining = seconds;  // 남은 시간 설정

                    // 타이머 시작
                    countdownTimer.Start();

                    MessageBox.Show($"Windows가 {minutes}분 후에 종료됩니다ㅋㅋ!!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 남은 시간 표시 레이블 업데이트
                    // labelTimeRemaining.Text = $"남은 시간: {minutes}분";
                }
                else
                {
                    MessageBox.Show("유효한 시간을 입력하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예상치 못한 오류 발생: " + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelShutdown_Click(object sender, EventArgs e)
        {
            // 타이머 객체 생성 (5000ms = 5초)
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C shutdown -a",
                    RedirectStandardError = true,  // 오류 메시지를 읽기 위해 설정
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string errorMessage = process.StandardError.ReadToEnd(); // 오류 메시지 읽기
                    process.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        MessageBox.Show("예약된 종료가 없습니다!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // 타이머 객체 생성 (5000ms = 5초 후)
                        System.Timers.Timer initTimer = new System.Timers.Timer(3000);
                        initTimer.Elapsed += (s, args) => LabelTimeRemainingInit(s, e); // 타이머가 만료되었을 때 호출될 메서드 설정
                        initTimer.Start();

                        countdownTimer.Stop(); // 타이머 중지
                        isShutdownScheduled = false;  // 예약 취소 상태로 변경
                        labelTimeRemaining.Text = "종료 예약이 취소되었습니다."; // 레이블에 상태 표시
                        MessageBox.Show("Windows 종료 예약이 취소되었습니다ㅋㅋ!!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예상치 못한 오류 발생: " + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // label init
        private void LabelTimeRemainingInit(object sender, EventArgs e)
        {
            if (labelTimeRemaining.InvokeRequired) // UI 스레드가 아닌 경우
            {
                // Invoke를 사용하여 UI 스레드에서 실행하도록 큐에 작업 추가
                labelTimeRemaining.Invoke(new Action(() =>
                {
                    labelTimeRemaining.Text = ""; // 레이블을 비웁니다
                }));
            }
            else
            {
                // 이미 UI 스레드에서 실행되고 있으면 바로 실행
                labelTimeRemaining.Text = ""; // 레이블을 비웁니다
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTimeInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
