using System;
using System.Windows;
using System.Windows.Controls;

namespace Praktika4_Bykov_Denisov
{
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }

        private double GetF(double x)
        {
            if (FuncSh.IsChecked == true)
                return Math.Sinh(x);
            else if (FuncX2.IsChecked == true)
                return x * x;
            else
                return Math.Exp(x);
        }

        private void Button_Calculate2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Task2_x.Text) ||
                    string.IsNullOrWhiteSpace(Task2_y.Text) ||
                    string.IsNullOrWhiteSpace(Task2_z.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double x = double.Parse(Task2_x.Text);
                double y = double.Parse(Task2_y.Text);
                double z = double.Parse(Task2_z.Text);

                double fx = GetF(x);
                double result;

                if (x * y > 0)
                    result = Math.Pow(fx + y, 2) - Math.Sqrt(fx * y);
                else if (x * y < 0)
                    result = Math.Pow(fx + y, 2) + Math.Sqrt(Math.Abs(fx * y));
                else
                    result = Math.Pow(fx + y, 2) + 1;

                Task2_Result.Text = result.ToString("F4");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Clear2(object sender, RoutedEventArgs e)
        {
            Task2_x.Clear();
            Task2_y.Clear();
            Task2_z.Clear();
            Task2_Result.Clear();
            FuncSh.IsChecked = true;
        }
    }
}