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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IndividualWork3.Core;

namespace IndividualWork3.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task2UC.xaml
    /// </summary>
    public partial class Task2UC : UserControl
    {
        public Task2UC()
        {
            InitializeComponent();
        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Tbl.Text) ||
               string.IsNullOrEmpty(Tbt.Text))
            {
                MessageBox.Show("Ошибка ввода",
                                "Задание №2",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                double t, l;

                t = Convert.ToDouble(Tbt.Text);
                l = Convert.ToDouble(Tbl.Text);

                Task2Class task2 = new Task2Class(t, l);

                TbR.Text = $"R = {task2.print()}";
            }
            Tbl.Text = string.Empty;
            Tbt.Text = string.Empty;
        }
    }
}
