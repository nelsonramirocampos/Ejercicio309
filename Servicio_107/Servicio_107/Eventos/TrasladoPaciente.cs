using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107.Eventos
{
    class TrasladoPaciente
    {
        private double _tiempo;
        private double _constante;

        public TrasladoPaciente(double constante)
        {
            _constante = constante;
        }

        public void generar_tiempo()
        {
            _tiempo = _constante;
        }


        public double Tiempo { get => _tiempo; set => _tiempo = value; }
        public double Constante { get => _constante; set => _constante = value; }
    }
}
