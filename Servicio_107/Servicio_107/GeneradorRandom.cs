using Servicio_107.Varios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107
{
    class GeneradorRandom
    {

        public static double obtenerRandom()
        {
            return Utilidades.truncar(random().NextDouble());
        }

        private static Random random()
        {
            Guid guid = Guid.NewGuid();
            String justNumber = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            int seed = int.Parse(justNumber.Substring(0, 4));

            return new Random(seed);
        }
    }
}
