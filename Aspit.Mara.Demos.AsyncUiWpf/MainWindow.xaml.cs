/* Demonstrates the use of asynchronous programming, to keep the UI from being blocked.*/

using System.Threading.Tasks;
using System.Windows;

namespace Aspit.Mara.Demos.AsyncUiWpf
{
    public partial class MainWindow: Window
    {
        bool count;
        int i;

        public MainWindow()
        {
            InitializeComponent();
            count = false;
            i = 0;
        }

        async void button_Click(object sender, RoutedEventArgs e)
        {
            if(count = !count)
            {
                button.Content = "Stop";
                await Task.Run(() => Count());
            }
            else
            {
                button.Content = "Start";
            }
        }

        async Task Count()
        {
            while(count)
            {
                Dispatcher.Invoke(() => labelClock.Content = $"{i++}");
                await Task.Delay(1000);
            }
        }
    }
}