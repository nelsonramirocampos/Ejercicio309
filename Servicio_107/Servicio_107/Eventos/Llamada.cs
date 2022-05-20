using Servicio_107.Varios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107.Eventos
{
    class Llamada
    {
        private double _rnd;
        private double _tiempo;
        private double _lambda;

        public Llamada(double lambda)
        {
            this._rnd = -0.1;
            this._tiempo = -123;

            this._lambda = lambda;
        }

        public void generar_tiempo()
        {
            this._rnd = GeneradorRandom.obtenerRandom();

            distribucion_exponencial();
        }

        public void distribucion_exponencial()
        {
            _tiempo = Utilidades.truncar((-1.0 / _lambda) * Math.Log(1.0 - _rnd));
        }

        public double Rnd { get => _rnd; set => _rnd = value; }
        public double Tiempo { get => _tiempo; set => _tiempo = value; }
        public double Lambda { get => _lambda; set => _lambda = value; }

    }
}
