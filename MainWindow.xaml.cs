using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading; // 要加入這段才能使用計時器

namespace DigitalClock
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> hours = new List<string>();            // 小時清單
        List<string> minutes = new List<string>();          // 分鐘清單 
        DispatcherTimer timer = new DispatcherTimer();      // 宣告一個「時鐘」計時器      

        public MainWindow()
        {
            InitializeComponent();

            // 建立小時的清單，數字範圍為00-23
            for (int i = 0; i <= 23; i++)
                hours.Add(string.Format("{0:00}", i));
            // 建立分鐘的清單，數字範圍為00-59
            for (int i = 0; i <= 59; i++)
                minutes.Add(string.Format("{0:00}", i));

            // 設定小時下拉選單的選單內容
            cmbHour.ItemsSource = hours;
            // 設定分鐘下拉選單的選單內容
            cmbMin.ItemsSource = minutes;

            // 設定「時鐘」計時器  
            timer.Interval = TimeSpan.FromSeconds(1);   // 這個計時器設定每一個刻度為1秒
            timer.Tick += new EventHandler(timer_tick); // 每一個時間刻度設定一個小程序timer_tick
            timer.Start(); // 啟動這個計時器
        }

        // timer_tick事件：每一秒執行一次
        private void timer_tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm:ss");    // 顯示時間
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");  // 顯示日期
            txtWeekDay.Text = DateTime.Now.ToString("dddd");     // 顯示星期幾
        }
    }
}