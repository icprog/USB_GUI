using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace USB_GUI {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow:Window {

        private ObservableDataSource<Point> volDataSource = new ObservableDataSource<Point>();
        private ObservableDataSource<Point> dataSource = new ObservableDataSource<Point>();
        private DispatcherTimer timer = new DispatcherTimer();
        private PerformanceCounter cpuPerformance = new PerformanceCounter();
        private int i = 0;
        public MainWindow() {
   
            InitializeComponent();
        }

        private void GenSinData() {
            double x = 0;
            double y = 0;
            for(;x < 360*5;x++) {
                y = Math.Sin(x * Math.PI/180);
                volDataSource.AppendAsync(base.Dispatcher,new Point(x*Math.PI / 180,y));
            }
        }

        private void AnimatiedPlot(object sender,EventArgs e) {
            cpuPerformance.CategoryName = "Processor";
            cpuPerformance.CounterName = "% Processor Time";
            cpuPerformance.InstanceName = "_Total";

            double x = i++;
            double y = cpuPerformance.NextValue();
            Point point = new Point(x,y);
            dataSource.AppendAsync(base.Dispatcher,point);
        }

        private void Window_Loaded(object sender,RoutedEventArgs e) {
            GenSinData();
            plotter.AddLineGraph(volDataSource,Colors.Green,2,"vol");
            //plotter.AddLineGraph(dataSource,Colors.Green,2,"Percentage");
           // timer.Interval = TimeSpan.FromSeconds(1);
            // timer.Tick += new EventHandler(AnimatiedPlot);
            //timer.IsEnabled = true;

            plotter.Viewport.FitToView();
        }

        /// <summary>
        /// 8通道开关量输入显示界面
        /// </summary>
        private void Mutl_channel_data_display() {

        }


        /// <summary>
        /// 8通道开关量输出控制界面
        /// </summary>
        private void Mutl_channel_data_control() {

        }


        /// <summary>
        /// 脉冲计数显示界面 
        /// </summary>
        private void Two_counter_data_dispaly() {

        }


        /// <summary>
        /// 模拟信号波形显示界面
        /// </summary>
        private void Two_adc_data_display() {

        }


        /// <summary>
        /// 各信号开关控制
        /// </summary>
        private void Option_signal_control() {

        }
    }
}
