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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Charts;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            labelData();
            this.PieChart();
        }
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();

        public void labelData()
        {
            txt_totV.Text = vehicle.getTotalVehicleCount().ToString();
            txt_available.Text = vehicle.getAvaialableVehicleCount().ToString();
            txt_customers.Text = customer.getCustomerCount().ToString();
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
            SolidColorBrush brush1 = new SolidColorBrush();
            brush1.Color = Color.FromRgb(34, 19, 119);
            SolidColorBrush brush2 = new SolidColorBrush();
            brush2.Color = Color.FromRgb(136, 170, 255);
            SolidColorBrush brush3 = new SolidColorBrush();
            brush3.Color = Color.FromRgb(0, 51, 238);
            SolidColorBrush brush4 = new SolidColorBrush();
            brush4.Color = Color.FromRgb(68, 34, 238);
            SolidColorBrush brush5 = new SolidColorBrush();
            brush5.Color = Color.FromRgb(34, 119, 170);
            piechart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "SEDANS",
                Values = new ChartValues<double> {vehicle.getSedans()},
               // PushOut = 15,            
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush4
            },
            new PieSeries
            {
                Title = "HATCHBACKS",
                Values = new ChartValues<double> {vehicle.getHatchback()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush2

            },
            new PieSeries
            {
                Title = "SUVS",
                Values = new ChartValues<double> {vehicle.getSUV()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush3
            },
            new PieSeries
            {
                Title = "VAN",
                Values = new ChartValues<double> {vehicle.getVan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush1
            }
            ,
            new PieSeries
            {
                Title = "MINI-VAN",
                Values = new ChartValues<double> {vehicle.getMinivan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush5
            }
        };
        }
    }
}
