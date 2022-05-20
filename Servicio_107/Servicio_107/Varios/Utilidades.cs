using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio_107.Varios
{
    class Utilidades
    {
        public static double truncar(double number)
        {
            int decimales = int.Parse(Math.Pow(10, Parametros.CANT_DECIMALES).ToString());
            return Math.Truncate(number * decimales) / decimales;
        }

        public static void soloNumeros(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
    }
}
