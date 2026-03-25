using System.Windows.Controls;

namespace Praktika4_Bykov_Denisov
{
    public partial class TaskListPage : Page
    {
        public TaskListPage()
        {
            InitializeComponent();
        }

        private void Button_OpenPage1(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task1Page());
        }

        private void Button_OpenPage2(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task2Page());
        }

        private void Button_OpenPage3(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task3Page());
        }
    }
}