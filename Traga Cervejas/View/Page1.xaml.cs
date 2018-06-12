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
using Traga_Cervejas;


namespace Traga_Cervejas.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        public MainWindow mainwindowproperty { get; set; }
        public ViewModel vmproperty { get; set; }

        public Page1()
        {
            InitializeComponent();
            mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            this.DataContext = mainwindowproperty.vmproperty;
            ligabotoes();
        }

        public void ligabotoes()
        {
            vmproperty = new ViewModel();
            CommandBindings.Add(new CommandBinding(
                Comandos.start,
                (sender, e) => vmproperty.navega("start"),
                (sender, e) => e.CanExecute = true
                ));
            //CommandBindings.Add(new CommandBinding(
            //    Comandos.start,
            //    (sender, e) => vmproperty.navega("Page3"),
            //    (sender, e) => e.CanExecute = true
            //    ));


            CommandBindings.Add(new CommandBinding(
                Comandos.sair,
                (sender, e) => vmproperty.sair(),
                (sender, e) => e.CanExecute = true
                ));


        }







    } //fim classe
} //fim namespace
