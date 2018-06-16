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
        //public Page2 pag2property { get; set; }

        #endregion


        #region PropertyChange Handler
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string nome)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nome));
        }

        #endregion


        #region Construtor

        public Jogo(string nomejogador)
        {
            _jogador = nomejogador;

            //vmproperty.pag2property = new Page2();
            

            //binding das properties
            //vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;
            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;



            //ticker da animação das cervejas (6s)
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 6);
            dispatcherTimer.Start();


            //ticker para deteção da colisão (10ms)
            DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            gameTimer.Start();

            

        }

        #endregion


        #region Jogo


        



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

            Image[] cervejas = new Image[5] { vmproperty.pag2property.sagres0, vmproperty.pag2property.sagres1, vmproperty.pag2property.sagres2, vmproperty.pag2property.sagres3, vmproperty.pag2property.sagres4 };



            for (int i = 0; i < 5; i++)
            {


                vmproperty.pag2property.theGrid.Children.Remove(cervejas[i]);

                vmproperty.pag2property.theGrid.Children.Add(cervejas[i]);

                leftStart[i] = _t.Next(10, (int)vmproperty.pag2property.theGrid.ActualWidth - 50);
                topStart[i] = _t.Next(10, 70);
                leftFinish[i] = _t.Next(10, (int)vmproperty.pag2property.theGrid.ActualWidth - 50);
                topFinish[i] = _t.Next(680, 700);

                int tempoAnim = _t.Next(2, 6);

                //Animação Cerveja
                ThicknessAnimation thicknessanimation = new ThicknessAnimation();
                thicknessanimation.From = new Thickness(leftStart[i], topStart[i], cervejas[i].Margin.Right, cervejas[i].Margin.Bottom);
                thicknessanimation.To = new Thickness(leftFinish[i], topFinish[i], cervejas[i].Margin.Right, cervejas[i].Margin.Bottom);
                thicknessanimation.Duration = TimeSpan.FromSeconds(tempoAnim);


                cervejas[i].BeginAnimation(MarginProperty, thicknessanimation);
                

            }


            
        } //metodo animação cervejas

        public DependencyProperty MarginProperty { get; private set; }

        //metodo deteção colisão
        public void gameTimer_Tick(object sender, EventArgs e)
        {


            Image[] cervejas = new Image[5] { vmproperty.pag2property.sagres0, vmproperty.pag2property.sagres1, vmproperty.pag2property.sagres2, vmproperty.pag2property.sagres3, vmproperty.pag2property.sagres4 };

            for (int i = 0; i < 5; i++)
            {


                if (vmproperty.pag2property.rino.Margin.Top > cervejas[i].Margin.Top - 50 && vmproperty.pag2property.rino.Margin.Top < cervejas[i].Margin.Top + 50)
                {
                    if (vmproperty.pag2property.rino.Margin.Left > cervejas[i].Margin.Left - 50 && vmproperty.pag2property.rino.Margin.Left < cervejas[i].Margin.Left + 50)
                    {
                        vmproperty.pag2property.theGrid.Children.Remove(cervejas[i]);
                        Pontos += 1;

                       
                    }
                }
            }



        } //metodo deteção colisão


        //movimento rino
        //bool isLeftPressed, isRightPressed;

        public void image_KeyDown(object sender, KeyEventArgs e)
        {
            int moveSpeed = 15;

            if (e.Key == Key.Left)
            {

                //isLeftPressed = true;


                if (vmproperty.pag2property.rino.Margin.Left > 1)
                {
                    vmproperty.pag2property.rino.Margin = new Thickness(vmproperty.pag2property.rino.Margin.Left - moveSpeed, vmproperty.pag2property.rino.Margin.Top, vmproperty.pag2property.rino.Margin.Right + moveSpeed, vmproperty.pag2property.rino.Margin.Bottom);
                }



            }

            if (e.Key == Key.Right)
            {
                //isRightPressed = true;
               
                if (vmproperty.pag2property.rino.Margin.Right > -325)
                {
                    vmproperty.pag2property.rino.Margin = new Thickness(vmproperty.pag2property.rino.Margin.Left + moveSpeed, vmproperty.pag2property.rino.Margin.Top, vmproperty.pag2property.rino.Margin.Right - moveSpeed, vmproperty.pag2property.rino.Margin.Bottom);
                }

            }

            if (e.Key == Key.Space)
            {
                //421 to top
                while (vmproperty.pag2property.rino.Margin.Top > vmproperty.pag2property.theGrid.ActualHeight - 450)
                {
                    vmproperty.pag2property.rino.Margin = new Thickness(vmproperty.pag2property.rino.Margin.Left, vmproperty.pag2property.rino.Margin.Top - 2, vmproperty.pag2property.rino.Margin.Right, vmproperty.pag2property.rino.Margin.Bottom);
                }

            }


        }


        public void image_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Left)
            //{
            //    isLeftPressed = false;
                
            //}

            //if (e.Key == Key.Right)
            //{
            //    isRightPressed = false;
                
            //}

            if (e.Key == Key.Space)
            {
                //421 to top
                while (vmproperty.pag2property.rino.Margin.Top < 421)
                {
                    vmproperty.pag2property.rino.Margin = new Thickness(vmproperty.pag2property.rino.Margin.Left, vmproperty.pag2property.rino.Margin.Top + 2, vmproperty.pag2property.rino.Margin.Right, vmproperty.pag2property.rino.Margin.Bottom);
                }

            }


        } //movimento Rino


        ////Resolução do FOCUS na GRID.
        //private void theGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    theGrid.Focus();

        //} //focus Grid - ficar no page2.cs ??





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
