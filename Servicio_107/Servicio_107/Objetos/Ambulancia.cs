using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107.Objetos
{
    class Ambulancia
    {
        private int _nro;
        private String _estado;
        private Double _tiempo;

        public Ambulancia(int nro, string estado)
        {
            _nro = nro;
            _estado = estado;
            _tiempo = -1;
        }

        public String ToString()
        {
            String cad = _estado;
            if (_tiempo > 0) cad = _estado + " / " + _tiempo;

            return cad;
        }

        public int Nro { get => _nro; set => _nro = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public double Tiempo { get => _tiempo; set => _tiempo = value; }
    }
}
