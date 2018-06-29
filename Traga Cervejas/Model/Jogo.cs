using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;



using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Media;

using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Timers;


namespace Traga_Cervejas
{
    public class Jogo:DependencyObject, INotifyPropertyChanged
    {


        #region Binding

        public ViewModel vmproperty { get; set; }
        public Page2 pag2property { get; set; }

        //public MainWindow mainwindowproperty { get; set; }

        #endregion


        #region PropertyChange Handler
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));
        }

        #endregion


        #region Construtor

        public Jogo(string nomejogador, Page2 p2, ViewModel vm)
        {
            _jogador = nomejogador;
            pag2property = p2;
            vmproperty = vm;

            //vmproperty.pag2property = new Page2();
            

            //binding das properties
            //vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;
            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;



            //ticker da animação das cervejas (6s)
            //DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 6);
            dispatcherTimer.Start();


            //ticker para deteção da colisão (10ms)
            //DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            gameTimer.Start();
            
            
            
            //tempo de Jogo
            //DispatcherTimer tempodeJogo = new System.Windows.Threading.DispatcherTimer();
            tempodeJogo.Tick += TempodeJogo_Tick;
            tempodeJogo.Interval = new TimeSpan(0, 0, 0, 10);
            tempodeJogo.Start();

            //pag2property.rino.Focus();
            pag2property.theGrid.Focus();
            //pag2property.theGrid.KeyDown += image_KeyDown; 
               
            //pag2property.theGrid.KeyUp += image_KeyDown;

        }





        #endregion


        #region Jogo

        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        DispatcherTimer tempodeJogo = new System.Windows.Threading.DispatcherTimer();




        //public void criaImagens()
        //{


        //    //CERVEJA

        //    Image sagres0 = new Image(); 
        //    Image sagres1 = new Image(); 
        //    Image sagres2 = new Image(); 
        //    Image sagres3 = new Image(); 
        //    Image sagres4 = new Image(); 
        //    Image[] cervejas = new Image[5] { vmproperty.pag2property.sagres0, vmproperty.pag2property.sagres1, vmproperty.pag2property.sagres2, vmproperty.pag2property.sagres3, vmproperty.pag2property.sagres4 };


        //    for (int i =0; i<5; i++)
        //    {

        //        cervejas[i].Width = 100;
        //        cervejas[i].Height = 100;
        //        BitmapImage bi3 = new BitmapImage();
        //        bi3.BeginInit();
        //        bi3.UriSource = new Uri("../images/sagres.png", UriKind.Relative);
        //        bi3.EndInit();
        //        cervejas[i].Source = bi3;
        //        //img.Source = "images/sagres.png".ToString();
        //        //theGrid.Children.Add(img);

        //    }

        //}



        //metodo animação cervejas
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random _t = new Random();

            int[] leftStart = new int[5];
            int[] topStart = new int[5];
            int[] leftFinish = new int[5];
            int[] topFinish = new int[5];

            Image[] cervejas = new Image[5] { pag2property.sagres0, pag2property.sagres1, pag2property.sagres2, pag2property.sagres3, pag2property.sagres4 };
            //Image[] cervejas = new Image[5] { vmproperty.pag2property.sagres0, vmproperty.pag2property.sagres1, vmproperty.pag2property.sagres2, vmproperty.pag2property.sagres3, vmproperty.pag2property.sagres4 };

            

            for (int i = 0; i < 5; i++)
            {
                
                
                pag2property.theGrid.Children.Remove(cervejas[i]);

                pag2property.theGrid.Children.Add(cervejas[i]);

                leftStart[i] = _t.Next(10, 550);
                topStart[i] = _t.Next(10, 70);
                leftFinish[i] = _t.Next(10, 550);
                topFinish[i] = _t.Next(680, 700);

                int tempoAnim = _t.Next(2, 6);

                //Animação Cerveja
                ThicknessAnimation thicknessanimation = new ThicknessAnimation();
                thicknessanimation.From = new Thickness(leftStart[i], topStart[i], cervejas[i].Margin.Right, cervejas[i].Margin.Bottom);
                thicknessanimation.To = new Thickness(leftFinish[i], topFinish[i], cervejas[i].Margin.Right, cervejas[i].Margin.Bottom);
                thicknessanimation.Duration = TimeSpan.FromSeconds(tempoAnim);


                cervejas[i].BeginAnimation(Canvas.MarginProperty, thicknessanimation);
                

            }



        } //metodo animação cervejas

        
        //metodo deteção colisão
        public void gameTimer_Tick(object sender, EventArgs e)
        {

            Image[] cervejas = new Image[5] { pag2property.sagres0, pag2property.sagres1, pag2property.sagres2, pag2property.sagres3, pag2property.sagres4 };
            //Image[] cervejas = new Image[5] { vmproperty.pag2property.sagres0, vmproperty.pag2property.sagres1, vmproperty.pag2property.sagres2, vmproperty.pag2property.sagres3, vmproperty.pag2property.sagres4 };

            for (int i = 0; i < 5; i++)
            {
                

                if (pag2property.rino.Margin.Top > cervejas[i].Margin.Top - 50 && pag2property.rino.Margin.Top < cervejas[i].Margin.Top + 50)
                {
                    if (pag2property.rino.Margin.Left > cervejas[i].Margin.Left - 50 && pag2property.rino.Margin.Left < cervejas[i].Margin.Left + 50)
                    {
                        //falta incluir controlo de 1 ponto por ceveja, devido aos 10ms de verificação da colisão
                        pag2property.theGrid.Children.Remove(cervejas[i]);
                        Pontos += 1;
                        pag2property.txtpontos.Text = Pontos.ToString();

                       
                    }
                }
            }



        } //metodo deteção colisão


        //tempo de jogo
        private void TempodeJogo_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            gameTimer.Start();
            tempodeJogo.Stop();
            vmproperty.addScore(Jogador, Pontos);
            vmproperty.navega("fim");


            //pag2property.vmproperty.addScore(Jogador, Pontos);
            //pag2property.vmproperty.navega("fim");
            
           

        }


        #endregion




        #region Info Sobre Jogador

        private string _jogador;
        private int _pontos;


        public string Jogador
        {
            get { return _jogador; }
            set
            {
                _jogador = value;
                OnPropertyChanged("Jogador");
            }
        }

        public int Pontos
        {
            get { return _pontos; }
            set
            {
                _pontos = value;
                OnPropertyChanged("Pontos");
            }
        }

       



        #endregion








    }
}
