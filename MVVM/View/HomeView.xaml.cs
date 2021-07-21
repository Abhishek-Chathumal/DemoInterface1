using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;
using System.Windows.Media;

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
            brush1.Color = Color.FromRgb(74, 20, 140);
            SolidColorBrush brush2 = new SolidColorBrush();
            brush2.Color = Color.FromRgb(123, 31, 162);
            SolidColorBrush brush3 = new SolidColorBrush();
            brush3.Color = Color.FromRgb(159, 36, 176);
            SolidColorBrush brush4 = new SolidColorBrush();
            brush4.Color = Color.FromRgb(186, 104, 200);
            SolidColorBrush brush5 = new SolidColorBrush();
            brush5.Color = Color.FromRgb(225, 190, 231);
            SolidColorBrush brushStroke = new SolidColorBrush();
            brush5.Color = Color.FromRgb(25, 25, 25);
            piechart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "SEDANS",
                Values = new ChartValues<double> {vehicle.getSedans()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush1,
                StrokeThickness=0
            },
            new PieSeries
            {
                Title = "HATCHBACKS",
                Values = new ChartValues<double> {vehicle.getHatchback()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush2,
                StrokeThickness=0

            },
            new PieSeries
            {
                Title = "SUVS",
                Values = new ChartValues<double> {vehicle.getSUV()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush3,
                StrokeThickness=0
            },
            new PieSeries
            {
                Title = "VAN",
                Values = new ChartValues<double> {vehicle.getVan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush5,
                StrokeThickness=0
            }
            ,
            new PieSeries
            {
                Title = "MINI-VAN",
                Values = new ChartValues<double> {vehicle.getMinivan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush4,
                StrokeThickness=0
            }
        };
        }
    }
}
