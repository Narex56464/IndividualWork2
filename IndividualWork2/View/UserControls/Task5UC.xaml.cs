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
    /// Логика взаимодействия для Task5UC.xaml
    /// </summary>
    public partial class Task5UC : UserControl
    {
        public Task5UC()
        {
            InitializeComponent();
        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Tbn.Text))
            {
                MessageBox.Show("Ошибка ввода",
                                "Задание №5",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                int n;

                n = Convert.ToInt32(Tbn.Text);

                Task5Class task5 = new Task5Class();

                TbAnswer.Text = $"Факториал N = {task5.Calculate(n)}";
            }
            Tbn.Text = string.Empty;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
