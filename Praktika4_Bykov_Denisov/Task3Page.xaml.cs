using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Praktika4_Bykov_Denisov
{
    public partial class Task3Page : Page
    {
        public PlotModel PlotModel { get; set; }

        public Task3Page()
        {
            InitializeComponent();
            InitializePlot();
            DataContext = this;
        }

        private void InitializePlot()
        {

            PlotModel = new PlotModel
            {
                Title = "График функции y = (10⁻²·b·c)/x + cos(√(a³·x))",
                TitleFontSize = 14,
                TitleFontWeight = OxyPlot.FontWeights.Normal,
                PlotAreaBorderColor = OxyColor.FromRgb(200, 200, 200),
                PlotAreaBorderThickness = new OxyThickness(1),
                Background = OxyColors.White
            };

            // Ось X
            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "x",
                TitleFontSize = 12,
                TicklineColor = OxyColor.FromRgb(150, 150, 150),
                AxislineColor = OxyColor.FromRgb(100, 100, 100),
                AxislineThickness = 1,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColor.FromRgb(230, 230, 230),
                MinorGridlineStyle = LineStyle.Dot,
                MinorGridlineColor = OxyColor.FromRgb(240, 240, 240)
            });

            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "y",
                TitleFontSize = 12,
                TicklineColor = OxyColor.FromRgb(150, 150, 150),
                AxislineColor = OxyColor.FromRgb(100, 100, 100),
                AxislineThickness = 1,
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = OxyColor.FromRgb(230, 230, 230),
                MinorGridlineStyle = LineStyle.Dot,
                MinorGridlineColor = OxyColor.FromRgb(240, 240, 240)
            });

            var series = new LineSeries
            {
                Title = "y(x)",
                Color = OxyColor.FromRgb(0, 122, 204),
                StrokeThickness = 2,
                MarkerType = MarkerType.None,
                LineStyle = LineStyle.Solid,
                CanTrackerInterpolatePoints = false
            };

            PlotModel.Series.Add(series);
        }

        private void UpdateGraph(double x0, double xk, double dx, double a, double b, double c)
        {

            var series = (LineSeries)PlotModel.Series[0];
            series.Points.Clear();

            // Определяем направление и количество точек
            int steps = (int)(Math.Abs((xk - x0) / dx)) + 1;
            double currentX = x0;

            for (int i = 0; i < steps; i++)
            {
                // Проверка деления на ноль
                if (Math.Abs(currentX) < 1e-10)
                {
                    currentX += dx;
                    continue;
                }

                // Проверка подкоренного выражения
                double underSqrt = Math.Pow(a, 3) * currentX;
                if (underSqrt < 0)
                {
                    currentX += dx;
                    continue;
                }

                // Вычисление y
                double term1 = (0.01 * b * c) / currentX;
                double term2 = Math.Cos(Math.Sqrt(underSqrt));
                double y = term1 + term2;

                // Проверка на корректность
                if (!double.IsInfinity(y) && !double.IsNaN(y))
                {
                    series.Points.Add(new DataPoint(currentX, y));
                }

                currentX += dx;

                // Защита от бесконечного цикла
                if (i > 1000) break;
            }

            // Обновляем график
            PlotView.InvalidatePlot(true);
        }

        private double CalculateY(double x, double a, double b, double c)
        {
            if (Math.Abs(x) < 1e-10) return double.NaN;

            double underSqrt = Math.Pow(a, 3) * x;
            if (underSqrt < 0) return double.NaN;

            return (0.01 * b * c) / x + Math.Cos(Math.Sqrt(underSqrt));
        }

        private void Button_Calculate3(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка на пустые поля
                if (string.IsNullOrWhiteSpace(Task3_x0.Text) ||
                    string.IsNullOrWhiteSpace(Task3_xk.Text) ||
                    string.IsNullOrWhiteSpace(Task3_dx.Text) ||
                    string.IsNullOrWhiteSpace(Task3_a.Text) ||
                    string.IsNullOrWhiteSpace(Task3_b.Text) ||
                    string.IsNullOrWhiteSpace(Task3_c.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Парсинг значений
                double x0 = double.Parse(Task3_x0.Text.Replace('.', ','));
                double xk = double.Parse(Task3_xk.Text.Replace('.', ','));
                double dx = double.Parse(Task3_dx.Text.Replace('.', ','));
                double a = double.Parse(Task3_a.Text.Replace('.', ','));
                double b = double.Parse(Task3_b.Text.Replace('.', ','));
                double c = double.Parse(Task3_c.Text.Replace('.', ','));

                // Проверка направления цикла
                if (dx == 0)
                {
                    MessageBox.Show("Шаг dx не может быть равен 0!", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if ((xk - x0) / dx <= 0)
                {
                    MessageBox.Show("Неверное направление цикла! При таком шаге мы не дойдем до конечного значения.",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Вычисления для текстового вывода
                StringBuilder results = new StringBuilder();
                results.AppendLine("x\t\t\ty");
                results.AppendLine("----------------------------------------");

                int count = 0;
                int steps = (int)(Math.Abs((xk - x0) / dx)) + 1;
                double currentX = x0;

                for (int i = 0; i < steps; i++)
                {
                    string status = "";
                    double y = 0;

                    // Проверка деления на ноль
                    if (Math.Abs(currentX) < 1e-10)
                    {
                        status = "деление на 0";
                    }
                    else
                    {
                        // Проверка подкоренного выражения
                        double underSqrt = Math.Pow(a, 3) * currentX;
                        if (underSqrt < 0)
                        {
                            status = "корень из отр.";
                        }
                        else
                        {
                            y = (0.01 * b * c) / currentX + Math.Cos(Math.Sqrt(underSqrt));
                            status = y.ToString("F4");
                            count++;
                        }
                    }

                    results.AppendLine($"{currentX,8:F2}\t\t{status}");
                    currentX += dx;
                }

                results.AppendLine($"----------------------------------------");
                results.AppendLine($"Всего точек: {steps}");
                results.AppendLine($"Успешно вычислено: {count}");

                // Вывод результатов
                Task3_Results.Text = results.ToString();

                // Обновление графика
                UpdateGraph(x0, xk, dx, a, b, c);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа! (используйте точку или запятую)",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Clear3(object sender, RoutedEventArgs e)
        {
            // Очищаем результаты
            Task3_Results.Clear();

            // Очищаем график
            var series = (LineSeries)PlotModel.Series[0];
            series.Points.Clear();
            PlotView.InvalidatePlot(true);
        }
    }
}