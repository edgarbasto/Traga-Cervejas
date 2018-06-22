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

namespace Traga_Cervejas
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {

        public MainWindow main { get; set; }

        public ViewModel vmproperty { get; set; }

        public Page3()
        {
            InitializeComponent();
            main = (MainWindow)Application.Current.MainWindow;
            this.DataContext = main.vmproperty;

            //vmproperty = (ViewModel)Resources["testevm"];
            //vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = vmproperty;
            
            
            
        }

        //private void dgrid_Sorting(object sender, DataGridSortingEventArgs e)
        //{
        //    dgrid.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("pontos", System.ComponentModel.ListSortDirection.Descending));

        //}

        private void dgrid_Loaded(object sender, RoutedEventArgs e)
        {
            //dgrid.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("pontos", System.ComponentModel.ListSortDirection.Descending));

            dgrid.ColumnFromDisplayIndex(2).SortDirection = System.ComponentModel.ListSortDirection.Ascending;


        }
    } //fim pagina
} //fim namespace
