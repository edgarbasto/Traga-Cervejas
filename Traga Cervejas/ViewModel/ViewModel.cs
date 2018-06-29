using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using System.ComponentModel;
using System.Windows.Data;
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


        public Page1 pag1property { get; set; }
        public Page2 pag2property { get; set; }
        public Page3 pag3property { get; set; }
   
        public ViewModel()
        {
            reset();

            


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));

        }


        #region database

        public void reset()
        {
            using (tragacervejasdbEntities bd = new tragacervejasdbEntities())
            {
                ListaJogos = new ObservableCollection<jogo>(bd.jogos);
                JogosView = CollectionViewSource.GetDefaultView(ListaJogos);
                JogoCorrente = (jogo)JogosView.CurrentItem;


            }


        }


        public void addScore(string _jogador, int _pontos )
        {
            using (tragacervejasdbEntities bd = new tragacervejasdbEntities())
            {
                
                if (_jogador != null && _pontos != null)
                {
                    
                    jogo j = new jogo();

                    j.jogador = _jogador;
                    j.pontos = _pontos;
                    j.dia = DateTime.Now;

                    bd.jogos.Add(j);
                    

                    //bd.Entry(j).State = j.id == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                    //var teste = bd.Set<jogo>
                    //bd.jogos.At
                    //bd.jogos.Attach(j);
                    bd.SaveChanges();
                    reset();


                }

                
                System.Windows.MessageBox.Show(String.Format("Pontos: {0}", _pontos.ToString()));


            }

            //reset();
        }



        ObservableCollection<jogo> _listajogos;
        public ObservableCollection<jogo> ListaJogos
        {
            get { return _listajogos; }
            set { _listajogos = value;
                OnPropertyChanged("ListaJogos");
            }
        }

        ICollectionView _jogosview;
        public ICollectionView JogosView
        {
            get { return _jogosview; }
            set { _jogosview = value;
                OnPropertyChanged("JogosView");
            }
        }

        jogo _jogocorrente;

        public jogo JogoCorrente
        {
            get { return _jogocorrente; }
            set { _jogocorrente = value;
                OnPropertyChanged("JogoCorrente");
            }
        }




        #endregion
        

        #region navpaginas

        public void navega(String pag)
        {

            switch (pag)
            {
                case "start":
                    Page2 p2 = new Page2(/*jogoproperty*/);
                    mainwindowproperty.frame.Navigate(p2);                   
                    jogoproperty = new Jogo("teste", p2, this);
                    break;
                case "fim":
                    Page3 p3 = new Page3();
                    mainwindowproperty.frame.Navigate(p3);
                    break;
            }
        }

        public void navega(String pag, String player)
        {

            switch (pag)
            {
                case "start":
                    Page2 p2 = new Page2(/*jogoproperty*/);
                    mainwindowproperty.frame.Navigate(p2);
                    jogoproperty = new Jogo(player, p2, this);
                    break;
               
            }
        }


        public void sair()
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion



        



    } //fim da classe ViewModel
} // fim do namespace
