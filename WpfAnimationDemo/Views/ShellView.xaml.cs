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
using System.Windows.Shapes;

namespace WpfAnimationDemo.Views
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void WebBrowser_TouchDown(object sender, TouchEventArgs e)
        {
        }

        private void WebBrowser_TouchMove(object sender, TouchEventArgs e)
        {

        }
    }
}
