using System;
using System.Windows;
using System.Windows.Controls;

namespace Praktika4_Bykov_Denisov
{
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }

        private void Button_Calculate1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Task1_x.Text) ||
                    string.IsNullOrWhiteSpace(Task1_y.Text) ||
                    string.IsNullOrWhiteSpace(Task1_z.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double x = double.Parse(Task1_x.Text);
                double y = double.Parse(Task1_y.Text);
                double z = double.Parse(Task1_z.Text);

                // Формула: t = (2cos(x-π/6))/(0.5+sin²y) * (1 + z²/(3-z²/5))
                double numerator = 2 * Math.Cos(x - Math.PI / 6);
                double denominator = 0.5 + Math.Pow(Math.Sin(y), 2);
                double firstPart = numerator / denominator;

                double secondPart = 1 + (z * z) / (3 - (z * z / 5));

                double result = firstPart * secondPart;

                Task1_Result.Text = result.ToString("F4");
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

        private void Button_Clear1(object sender, RoutedEventArgs e)
        {
            Task1_x.Clear();
            Task1_y.Clear();
            Task1_z.Clear();
            Task1_Result.Clear();
        }
    }
}