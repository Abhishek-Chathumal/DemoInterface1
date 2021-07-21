using System.Windows.Controls;
﻿using System;
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
using System.Data;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for ViewVehiclesView.xaml
    /// </summary>
    public partial class ViewVehiclesView : UserControl
    {
        Vehicle vehicle = new Vehicle();
        DataTable dt = new DataTable();
        public ViewVehiclesView()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            dt = vehicle.viewVehicle();
            dg_vehicle.ItemsSource = dt.DefaultView;
            cmb_catagory.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_trans.SelectedIndex = -1;
            cmb_fuel.SelectedIndex = -1;
        }

        private void cmb_catagory_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleCategory(cmb_catagory.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
            cmb_make.SelectedIndex = -1;
            cmb_trans.SelectedIndex = -1;
            cmb_fuel.SelectedIndex = -1;
        }

        private void cmb_make_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleMake(cmb_make.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
            cmb_catagory.SelectedIndex = -1;
            cmb_trans.SelectedIndex = -1;
            cmb_fuel.SelectedIndex = -1;
        }

        private void cmb_trans_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleTrans(cmb_trans.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
            cmb_catagory.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_fuel.SelectedIndex = -1;
        }


        private void cmb_fuel_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleFuel(cmb_fuel.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
            cmb_catagory.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_trans.SelectedIndex = -1;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void btn_available_Click(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewAvaiableVehicle();
            dg_vehicle.ItemsSource = dt.DefaultView;
            cmb_catagory.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_trans.SelectedIndex = -1;
            cmb_fuel.SelectedIndex = -1;
        }
    }
}
