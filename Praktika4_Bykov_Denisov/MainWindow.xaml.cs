using System.Windows;
using System.Windows.Input;

namespace Praktika4_Bykov_Denisov
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TaskListPage());
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?",
                                       "Подтверждение",
                                       MessageBoxButton.YesNo,
                                       MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_OpenPage1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Task1Page());
        }

        private void Button_OpenPage2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Task2Page());
        }

        private void Button_OpenPage3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Task3Page());
        }

        private void Button_GoBack(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
            else
                MainFrame.Navigate(new TaskListPage());
        }
    }
}