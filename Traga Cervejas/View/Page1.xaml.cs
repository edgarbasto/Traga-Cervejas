using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page, INotifyPropertyChanged
    {

        public MainWindow mainwindowproperty { get; set; }
        //public ViewModel vmproperty { get; set; }

        public Page1()
        {
            InitializeComponent();
            //vmproperty = (ViewModel)Resources["testevm"];
            //vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            


            mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;
            DataContext = this;




            NomeJogador = "Inserir o nome";
            ligabotoes();

            //this.DataContext = mainwindowproperty.vmproperty;
            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = main.vmproperty;

        }


        #region PropertyChange Handler
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));
        }

        #endregion




        public string nomejogador;

        public string NomeJogador
        {
            get { return nomejogador; }
            set
            {
                nomejogador = value;
                OnPropertyChanged("NomeJogador");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(NomeJogador.ToString());
        }

        //public Page1(TextBox txtnome, bool contentLoaded, MainWindow mainwindowproperty, string canecos, string canecos)
        //{
        //    this.txtnome = txtnome;
        //    _contentLoaded = contentLoaded;
        //    this.mainwindowproperty = mainwindowproperty;
        //    Canecos = canecos;
        //    Canecos = canecos;
        //}






        #region botões

        public void ligabotoes()
        {
            //vmproperty = new ViewModel();
            CommandBindings.Add(new CommandBinding(
                Comandos.start,
                (sender, e) => mainwindowproperty.vmproperty.navega("start", NomeJogador),
                (sender, e) => e.CanExecute = true
                ));
            //CommandBindings.Add(new CommandBinding(
            //    Comandos.start,
            //    (sender, e) => vmproperty.navega("Page3"),
            //    (sender, e) => e.CanExecute = true
            //    ));


            CommandBindings.Add(new CommandBinding(
                Comandos.sair,
                (sender, e) => mainwindowproperty.vmproperty.sair(),
                (sender, e) => e.CanExecute = true
                ));


        }

        #endregion


    } //fim classe
} //fim namespace
