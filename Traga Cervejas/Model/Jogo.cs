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
using System.Windows.Threading;

namespace Traga_Cervejas
{
    public class Jogo:DependencyObject, INotifyPropertyChanged
    {


        #region Binding

        public ViewModel vmproperty { get; set; }


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

           
            //binding das properties
            vmproperty.mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = mainwindowproperty.vmproperty;
            //mainwindowproperty = (MainWindow)Application.Current.MainWindow;
            //this.DataContext = main.vmproperty;


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


        //metodo animação cervejas
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Random _t = new Random();

            int[] leftStart = new int[5];
            int[] topStart = new int[5];
            int[] leftFinish = new int[5];
            int[] topFinish = new int[5];

            Image[] cervejas = new Image[5] { sagres0, sagres1, sagres2, sagres3, sagres4 };



            for (int i = 0; i < 5; i++)
            {

                theGrid.Children.Remove(cervejas[i]);

                theGrid.Children.Add(cervejas[i]);

                leftStart[i] = _t.Next(10, (int)theGrid.ActualWidth - 50);
                topStart[i] = _t.Next(10, 70);
                leftFinish[i] = _t.Next(10, (int)theGrid.ActualWidth - 50);
                topFinish[i] = _t.Next(680, 700);

                int tempoAnim = _t.Next(2, 6);

                //Animação Cerveja
                ThicknessAnimation thicknessanimation = new ThicknessAnimation();
                thicknessanimation.From = new Thickness(leftStart[i], topStart[i], this.Margin.Right, this.Margin.Bottom);
                thicknessanimation.To = new Thickness(leftFinish[i], topFinish[i], this.Margin.Right, this.Margin.Bottom);
                thicknessanimation.Duration = TimeSpan.FromSeconds(tempoAnim);


                cervejas[i].BeginAnimation(MarginProperty, thicknessanimation);


            }


            
        } //metodo animação cervejas


        //metodo deteção colisão
        private void gameTimer_Tick(object sender, EventArgs e)
        {


            Image[] cervejas = new Image[5] { sagres0, sagres1, sagres2, sagres3, sagres4 };

            for (int i = 0; i < 5; i++)
            {


                if (image.Margin.Top > cervejas[i].Margin.Top - 50 && image.Margin.Top < cervejas[i].Margin.Top + 50)
                {
                    if (image.Margin.Left > cervejas[i].Margin.Left - 50 && image.Margin.Left < cervejas[i].Margin.Left + 50)
                    {
                        theGrid.Children.Remove(cervejas[i]);
                       
                    }
                }
            }



        } //metodo deteção colisão


        //movimento rino
        bool isLeftPressed, isRightPressed;

        private void image_KeyDown(object sender, KeyEventArgs e)
        {
            int moveSpeed = 15;

            if (e.Key == Key.Left)
            {

                isLeftPressed = true;


                if (rino.Margin.Left > 1)
                {
                    rino.Margin = new Thickness(rino.Margin.Left - moveSpeed, rino.Margin.Top, rino.Margin.Right + moveSpeed, rino.Margin.Bottom);
                }



            }

            if (e.Key == Key.Right)
            {
                isRightPressed = true;
               
                if (rino.Margin.Right > -325)
                {
                    rino.Margin = new Thickness(rino.Margin.Left + moveSpeed, rino.Margin.Top, rino.Margin.Right - moveSpeed, rino.Margin.Bottom);
                }

            }

            if (e.Key == Key.Space)
            {
                //421 to top
                while (rino.Margin.Top > theGrid.ActualHeight - 450)
                {
                    rino.Margin = new Thickness(rino.Margin.Left, rino.Margin.Top - 2, rino.Margin.Right, rino.Margin.Bottom);
                }

            }


        }


        private void image_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                isLeftPressed = false;
                
            }

            if (e.Key == Key.Right)
            {
                isRightPressed = false;
                
            }

            if (e.Key == Key.Space)
            {
                //421 to top
                while (rino.Margin.Top < 421)
                {
                    rino.Margin = new Thickness(rino.Margin.Left, rino.Margin.Top + 2, rino.Margin.Right, rino.Margin.Bottom);
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
