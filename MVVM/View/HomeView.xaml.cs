using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Charts;
using System.Data;


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
        Booking book = new Booking();
        DataTable dt = new DataTable();

        public void labelData()
        {
            txt_totV.Text = vehicle.getTotalVehicleCount().ToString();
            txt_available.Text = vehicle.getAvaialableVehicleCount().ToString();
            txt_customers.Text = customer.getCustomerCount().ToString();
            dt = book.viewReturn();
            dg_return.ItemsSource = dt.DefaultView;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
            SolidColorBrush brush1 = new SolidColorBrush();
            brush1.Color = Color.FromRgb(101, 31, 255);
            SolidColorBrush brush2 = new SolidColorBrush();
            brush2.Color = Color.FromRgb(109, 42, 255);
            SolidColorBrush brush3 = new SolidColorBrush();
            brush3.Color = Color.FromRgb(124, 64, 255);
            SolidColorBrush brush4 = new SolidColorBrush();
            brush4.Color = Color.FromRgb(155, 109, 255);
            SolidColorBrush brush5 = new SolidColorBrush();
            brush5.Color = Color.FromRgb(185, 154, 255);
            SolidColorBrush brush6 = new SolidColorBrush();
            brush6.Color = Color.FromRgb(216, 199, 255);
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
                Title = "MINI-VAN",
                Values = new ChartValues<double> {vehicle.getMinivan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush4,
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
                Title = "PICKUP",
                Values = new ChartValues<double> {vehicle.getPickup()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush6,
                StrokeThickness=0
            }
        };
        }
    }
}
