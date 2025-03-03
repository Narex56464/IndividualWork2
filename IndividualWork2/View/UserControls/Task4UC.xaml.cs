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
    /// Логика взаимодействия для Task4UC.xaml
    /// </summary>
    public partial class Task4UC : UserControl
    {
        public Task4UC()
        {
            InitializeComponent();
        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            TbFirstArray.Text = string.Empty;
            TbFindNumber.Text = string.Empty;
            double[] arr = { 5.6, 2.1, 3.9, 7.2, 4.9, 8.8, 43.2, 45.1, 6.4, 1.1, 12.4, 98.1, 1.1, 11.1, 35.2 };

            foreach (var item in arr)
            {
                TbFirstArray.Text += $"{item} ";
            }

            Task4Class task4 = new Task4Class();

            SpCountNumber.Visibility = Visibility.Visible;

            TbFindNumber.Text = $"{task4.Count(arr)}";
        }
    }
}
