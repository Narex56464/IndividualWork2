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
    /// Логика взаимодействия для Task3UC.xaml
    /// </summary>
    public partial class Task3UC : UserControl
    {
        public Task3UC()
        {
            InitializeComponent();
        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Tbp.Text) ||
               string.IsNullOrEmpty(Tby.Text))
            {
                MessageBox.Show("Ошибка ввода",
                                "Задание №3",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                double p, y;

                p = Convert.ToDouble(Tbp.Text);
                y = Convert.ToDouble(Tby.Text);

                Task3Class task3 = new Task3Class(p, y);

                TbK.Text = $"K = {task3.print()}";
            }
            Tbp.Text = string.Empty;
            Tby.Text = string.Empty;
        }
    }
}
