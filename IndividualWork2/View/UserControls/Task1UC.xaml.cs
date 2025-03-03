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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IndividualWork3.Core;

namespace IndividualWork3.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task1UC.xaml
    /// </summary>
    public partial class Task1UC : UserControl
    {
        public Task1UC()
        {
            InitializeComponent();
        }

        private void BtnAnswerA_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Tba.Text) ||
               string.IsNullOrEmpty(Tbb.Text) || int.TryParse(Tbc.Text, out int number)) {
                MessageBox.Show("Ошибка ввода данных",
                                "Задание №1",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                int a, b;

                a = Convert.ToInt32(Tba.Text);
                b = Convert.ToInt32(Tbb.Text);

                Task1Class task1 = new Task1Class(a, b);

                SpAns.Visibility = Visibility.Visible;

                TbAnswer.Text = $"a) {task1.ExpA()}";
            }
            Tba.Text = string.Empty;
            Tbb.Text = string.Empty;
            Tbc.Text = string.Empty;
        }

        private void BtnAnswerB_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Tba.Text) ||
                string.IsNullOrEmpty(Tbb.Text) || string.IsNullOrEmpty(Tbc.Text))
            {
                MessageBox.Show("Ошибка ввода данных",
                                "Задание №1",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                int a, b, c;

                a = Convert.ToInt32(Tba.Text);
                b = Convert.ToInt32(Tbb.Text);
                c = Convert.ToInt32(Tbc.Text);

                Task1Class task1 = new Task1Class(a, b);

                SpAns.Visibility = Visibility.Visible;

                TbAnswer.Text = $"б) {task1.ExpB(c)}";
            }
            Tba.Text = string.Empty;
            Tbb.Text = string.Empty;
            Tbc.Text = string.Empty;
        }
    }
}
