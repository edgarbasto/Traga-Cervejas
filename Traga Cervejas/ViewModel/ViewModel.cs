using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traga_Cervejas.View;
using Traga_Cervejas;


namespace Traga_Cervejas
{
    public class ViewModel : INotifyPropertyChanged
    {
        public MainWindow mainwindowproperty { get; set; }

        
        

        public ViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));

        }



        #region navpaginas

        public void navega(String pag)
        {

            switch (pag)
            {
                case "start":
                    Page2 p2 = new Page2();
                   Traga_Cervejas.MainWindow.
                    mainwindowproperty.frame.Navigate(p2);
                    break;
                //case "Page3":
                //    Page3 p3 = new Page3();
                //    mainwindowproperty.frame.Navigate(p3);
                //    break;
            }
        }

        public void sair()
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

        

    } //fim da classe ViewModel
} // fim do namespace
