using System;
using System.Windows;
using System.Windows.Threading;

namespace DigitalClock
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer alarmTimer = new DispatcherTimer();
        TimeSpan alarmTime;

        public MainWindow()
        {
            InitializeComponent();

            // 設定「時鐘」計時器
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            // 設定「鬧鐘」計時器
            alarmTimer.Interval = TimeSpan.FromSeconds(1);
            alarmTimer.Tick += AlarmTimer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            txtTime.Text = currentTime.ToString("HH:mm:ss");
            txtDate.Text = currentTime.ToString("yyyy-MM-dd");
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Hour == alarmTime.Hours && currentTime.Minute == alarmTime.Minutes)
            {
                // 觸發鬧鐘動作
                MessageBox.Show("鬧鐘時間到了！", "鬧鐘", MessageBoxButton.OK, MessageBoxImage.Information);
                alarmTimer.Stop();
                btnSetAlarm.IsEnabled = true;
            }
        }

        private void btnSetAlarm_Click(object sender, RoutedEventArgs e)
        {
            if (TimeSpan.TryParse(txtAlarmTime.Text, out alarmTime))
            {
                // 設定鬧鐘時間
                btnSetAlarm.IsEnabled = false;
                alarmTimer.Start();
                MessageBox.Show($"已設定鬧鐘時間為 {alarmTime.ToString("hh\\:mm")}", "鬧鐘", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("請輸入正確的時間格式 (HH:mm)", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
