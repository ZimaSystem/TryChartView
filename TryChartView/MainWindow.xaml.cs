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
using Telerik.Windows.Controls.ChartView;

namespace TryChartView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DataModel> lst= new List<DataModel>();
        public MainWindow()
        {
            InitializeComponent();

        }

        int count = 0;
        public void sampleData()
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {

                lst.Add(
                    new DataModel { Name = count.ToString(), Value = rnd.NextDouble() * (100 - 0) + 0 }
                );
                count++;
            }
            //lst = new List<DataModel>() {
            //    new DataModel { Name ="a" , Value=5},
            //    new DataModel { Name ="b" , Value=10},
            //    new DataModel { Name ="c" , Value=15},
            //    new DataModel { Name ="d" , Value=20},
            //    new DataModel { Name ="e" , Value=25},
            //    new DataModel { Name ="f" , Value=30}
            //};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sampleData();
            LineSeries ls = new LineSeries() { ShowLabels = false, Name = "aaaaa" };
            myChart.Series.Add(ls);
            ls.CategoryBinding = new PropertyNameDataPointBinding("Name");
            ls.ValueBinding = new GenericDataPointBinding<DataModel, double>()
            {
                ValueSelector = val => val.Value
            };

            ls.ItemsSource = lst;
        }
    }
}
