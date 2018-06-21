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
using System.Windows.Media.Animation;
//using Traga_Cervejas;

namespace Traga_Cervejas
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public MainWindow mainwindowproperty { get; set; }
        public Jogo jogoproperty { get; set; }
        public ViewModel vmproperty { get; set; }

        public Page2(/*Jogo j1*/)
        {
            InitializeComponent();

            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;


            vmproperty = (ViewModel)Resources["testevm"];
            vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            


            //jogoproperty = j1;

            //
            //vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //vmproperty.jogoproperty = new Jogo("edgar");
            //DataContext = new Jogo("edgar");



            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;
        }


        //Resolução do FOCUS na GRID.
        private void theGrid_Loaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();

        } //focus Grid - ficar no page2.cs ??

        #region movimento RINO

        private void image_KeyDown(object sender, KeyEventArgs e)
        {
            
            int moveSpeed = 15;

            if (e.Key == Key.Left)
            {



                if (rino.Margin.Left > 1)
                {
                    rino.Margin = new Thickness(rino.Margin.Left - moveSpeed, rino.Margin.Top, rino.Margin.Right + moveSpeed, rino.Margin.Bottom);
                }



            }

            if (e.Key == Key.Right)
            {
               

                if (rino.Margin.Right > -325)
                {
                    rino.Margin = new Thickness(rino.Margin.Left + moveSpeed, rino.Margin.Top, rino.Margin.Right - moveSpeed, rino.Margin.Bottom);
                }

            }

            if (e.Key == Key.Space)
            {
                
                while (rino.Margin.Top > theGrid.ActualHeight - 450)
                {
                    rino.Margin = new Thickness(rino.Margin.Left, rino.Margin.Top - 2, rino.Margin.Right, rino.Margin.Bottom);
                }

            }



        }

        private void image_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
               
                while (rino.Margin.Top < 421)
                {
                    rino.Margin = new Thickness(rino.Margin.Left, rino.Margin.Top + 2, rino.Margin.Right, rino.Margin.Bottom);
                }

            }
        }


        #endregion


    } //fim classe Page2
} //fim namespace
