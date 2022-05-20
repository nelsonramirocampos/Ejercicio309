using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107.Eventos
{
    class Evento
    {
        private String _nombreColum;
        private Double _tiempo;

        public Evento(string nombreColum, double tiempo)
        {
            _nombreColum = nombreColum;
            _tiempo = tiempo;
        }

        public string NombreColum { get => _nombreColum; set => _nombreColum = value; }
        public double Tiempo { get => _tiempo; set => _tiempo = value; }
    }
}
