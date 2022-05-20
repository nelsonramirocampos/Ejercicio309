using Servicio_107.Varios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107.Eventos
{
    class LlegadaAmbulancia
    {
        private double _rnd;
        private double _tiempo;
        private double _A;
        private double _B;

        public LlegadaAmbulancia(double a, double b)
        {
            _rnd = -0.99;
            _tiempo = -553;
            _A = a;
            _B = b;
        }


        public void generar_tiempo()
        {
            this._rnd = GeneradorRandom.obtenerRandom();

            distribucion_uniforme();
        }

        private void distribucion_uniforme()
        {
            _tiempo = Utilidades.truncar(_B + (_rnd * (_B - _A)));
        }

        public double Rnd { get => _rnd; set => _rnd = value; }
        public double Tiempo { get => _tiempo; set => _tiempo = value; }
        public double A { get => _A; set => _A = value; }
        public double B { get => _B; set => _B = value; }
    }
}
