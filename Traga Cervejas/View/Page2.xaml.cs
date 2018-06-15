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
//using Traga_Cervejas;

namespace Traga_Cervejas
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        //public MainWindow mainwindowproperty { get; set; }
        public ViewModel vmproperty { get; set; }
        public Page2()
        {
            InitializeComponent();
            vmproperty = (ViewModel)Resources["testevm"];
            vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            vmproperty.jogoproperty = new Jogo("edgar");
            //DataContext = new Jogo("edgar");

            

            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;
        }


        //Resolução do FOCUS na GRID.
        private void theGrid_Loaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();

        } //focus Grid - ficar no page2.cs ??

        private void image_KeyDown(object sender, KeyEventArgs e)
        {
            vmproperty.jogoproperty.image_KeyDown(sender, e);
        }

        private void image_KeyUp(object sender, KeyEventArgs e)
        {
            vmproperty.jogoproperty.image_KeyUp(sender, e);
        }
    }
}
