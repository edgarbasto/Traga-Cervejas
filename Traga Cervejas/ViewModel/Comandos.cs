using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Traga_Cervejas
{
    class Comandos
    {

        public static RoutedUICommand start = new RoutedUICommand("start", "start", typeof(Comandos));
        //public static RoutedUICommand finish = new RoutedUICommand("Finish", "Finish", typeof(Comandos));
        public static RoutedUICommand sair = new RoutedUICommand("Sair", "Sair", typeof(Comandos));

        
    }
}
