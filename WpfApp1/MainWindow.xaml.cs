using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private float _myNumberValue = 100;
        public float MyNumber {
            get
            {
                return _myNumberValue;
            }
            set
            {
                _myNumberValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyNumberValue"));
            }
        }


        private List<StroyMaterial> _myElements;
        public List<StroyMaterial> MyElements
        {
            get { return _myElements; }
            set { _myElements = value; }
        }

        public MainWindow()
        {

            InitializeComponent();
            _myElements.Add("Word");
            _myElements.Add("Excel");
            _myElements.Add("Powerpoint");
            _myElements.Add("Visio");

            this.DataContext = this;
            MainFrame.Navigate(new MainPage());

            var db = new Sklad();
            var sm = db.StroyMaterial.ToList();
            _myElements = sm;
        }
        private void SettingPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window1();
            w.ShowDialog();
        }

        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward)
                MainFrame.GoForward();
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Navigate(
                new ApplicationPage(
                    (sender as ListView).SelectedItem as string
             ));
        }
        

    }
}
