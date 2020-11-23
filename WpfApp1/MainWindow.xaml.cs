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

        public MainWindow()
        {

            InitializeComponent();
            var db = new vkonstantinovEntities(); // Подключение к БД

            var sm = Core.DB.StroyMaterial.ToList();
            this.DataContext = this;

            SettingPage.Click += SettingPage_Click; // Путь создание кнопки
            Back.Click += Back_Click;
            Go.Click += Go_Click;   
            
            
           _myElements = sm;

            MainFrame.Navigate(new MainPage());

        }

        private List<StroyMaterial> _myElements = new List<StroyMaterial>();

        public List<StroyMaterial> MyElements
        {
            get { return _myElements; }
            set { _myElements = value; }
        }

        private float _myNumberValue = 100;
        public float MyNumber
        {
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

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward)
            {
                MainFrame.GoForward();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) 
            {
                MainFrame.GoBack();
            }
        }


        private void SettingPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingPage());
        }

        private void SettingPageButton(object sender, RoutedEventArgs e)
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

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as String);
            var appPage = new ApplicationPage(item);
            
            MainFrame.Navigate(appPage);
                //new ApplicationPage(
                   // (sender as ListView).SelectedItem as string));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddStroyMaterial(new StroyMaterial()) );
        }

        private void MainListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as StroyMaterial);
            Core.DB.StroyMaterial.Remove(item);
            Core.DB.SaveChanges();
            MessageBox.Show(item.Title + " deleted");
        }

        private void StroyMaterialTableButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StroyMaterialPage(MyElements));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //var item = SMDataGrid.SelectedItem as StroyMaterial;
            //Core.DB.StroyMaterial.Remove(item);
            //Core.DB.SaveChanges();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //var item = SMDataGrid.SelectedItem as StroyMaterial;
            //this.NavigationService.Navigate(new AddStroyMaterial(item));
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
