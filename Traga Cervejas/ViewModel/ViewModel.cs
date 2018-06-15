using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Traga_Cervejas.View;
//using Traga_Cervejas;


namespace Traga_Cervejas
{
    public class ViewModel : INotifyPropertyChanged
    {
        public MainWindow mainwindowproperty { get; set; }

        public Jogo jogoproperty { get; set; }
        public Page2 pag2property { get; set; }

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



        //Aqui tenho que arrancar o Jogo, onde inicia a classe Jogo(nomejogador)
        //Considerar 1minuto de jogo e depois executar a saída para a Page3 onde vai buscar os pontos e manda para uma base de Dados nomejogador e pontos.



    } //fim da classe ViewModel
} // fim do namespace
