using Servicio_107.Estados;
using Servicio_107.Eventos;
using Servicio_107.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_107
{
    class VectorEstado
    {
        private String _evento;
        private Double _reloj;

        private Double _rndLlamada;
        private Double _tiempoProximaLlamada;
        private Double _proximaLlamada;

        private Double _rndLlegada;
        private Double _tiempoProximaLlegada;
        private Double _proximaLlegada;
        private Double _proximaFinLlegada;

        private Double _finTraslado;
        private Double _finTrasladoProx;

        private List<Ambulancia> _ambulancias;

        private Llamada _e_llamada;
        private LlegadaAmbulancia _e_llegada;
        private TrasladoPaciente _e_traslado;

        internal List<Ambulancia> Ambulancias { get => _ambulancias; set => _ambulancias = value; }
        public string Evento { get => _evento; set => _evento = value; }
        public double Reloj { get => _reloj; set => _reloj = value; }

        public VectorEstado()
        {
            _reloj = 0;

            _rndLlamada = -1;
            _tiempoProximaLlamada = -1;
            _proximaLlamada = -1;

            _rndLlegada = -1;
            _tiempoProximaLlegada = -1;
            _proximaLlegada = -1;
            _proximaFinLlegada = -1;

            _finTraslado = -1;
            _finTrasladoProx = -1;

            _ambulancias = null;
            _e_llamada = null;
            _e_traslado = null;
        }

        public void crear_ambulancias(int n)
        {
            this._ambulancias = new List<Ambulancia>();
            for (int i = 1; i <= n; i++)
            {
                this._ambulancias.Add(new Ambulancia(i, Estado_Ambulancia.LIBRE));
            }
        }

        public void crear_evento_llamada(double lambda)
        {
            _e_llamada = new Llamada(lambda);
        }

        public void crear_evento_llegada(double A, double B)
        {
            _e_llegada = new LlegadaAmbulancia(A, B);
        }

        public void crear_evento_traslado(double tiempo)
        {
            _e_traslado = new TrasladoPaciente(tiempo);
        }

        public void evento_proxima_llamada()
        {
            _evento = "Llamada";
            _reloj = _proximaLlamada;

            generar_proxima_llamada();
            Ambulancia ambulancia_libre = existe_ambulancia_libre();
            if (ambulancia_libre != null) //Existe ambulancia libre
            {
                //Calculo cuanto tiempo le lleva llegar al lugar
                generar_proxima_llegada();

                actualizar_proximo_fin_traslado();


                //Actualizo el estado de la ambulancia
                actualizar_ambulancias(ambulancia_libre, Estado_Ambulancia.YENDO, _proximaLlegada);
            }
            else //FALTA: No hay ambulancia libre
            {

            }


            //Actualización de los demas valores
            _finTraslado = -1;
        }

        private void actualizar_proximo_llegada()
        {
            if (_proximaFinLlegada < 0)
            {
                _proximaFinLlegada = _proximaLlegada;
            }
            else if (_proximaLlegada < 0)
            {
                _proximaFinLlegada = -1;
            }
            else if (_proximaLlegada < _proximaFinLlegada)
            {
                _proximaFinLlegada = _proximaLlegada;
            }
        }

        private void actualizar_proximo_fin_traslado()
        {
            if(_finTrasladoProx < 0)
            {
                _finTrasladoProx = _finTraslado;
            }
            else if(_finTraslado < 0)
            {
                _finTrasladoProx = -1;
            }
            else if(_finTraslado < _finTrasladoProx)
            {
                _finTrasladoProx = _finTraslado;
            }
        }

        public void evento_proxima_llegada()
        {
            Ambulancia ambulancia_llega = proxima_ambulancia_llego();

            _evento = "Llegada Ambulancia " + ambulancia_llega.Nro;
            _reloj = _proximaFinLlegada;

            //Calculo el tiempo del proximo Traslado
            generar_proxima_traslado();
            //Actualizo la ambulancia que está volviendo
            actualizar_ambulancias(ambulancia_llega, Estado_Ambulancia.VOLVIENDO, _finTraslado);


            _proximaLlegada = -1;

            //No se genera otro tiempo de llegada
            _rndLlegada = -1;
            _tiempoProximaLlegada = -1;

            Ambulancia proxima_ambulancia_llega = proxima_ambulancia_llego();
            if (proxima_ambulancia_llega != null) //Hay otra ambulancia por llegar al lugar
            {
                _proximaFinLlegada = proxima_ambulancia_llega.Tiempo;
            }
            else //No hay otra ambulancia por llegar al lugar
            {
                _proximaFinLlegada = -1;
            }


            //Actualización de los demas valores
            _rndLlamada = -1;
            _tiempoProximaLlamada = -1;

            //Actualización de los tiempos de las proximas llegadas
            actualizar_proximo_fin_traslado();
        }

        public void evento_fin_traslado()
        {
            Ambulancia ambulancia_traslado = proxima_ambulancia_traslado();

            _evento = "Fin Traslado Ambulancia " + ambulancia_traslado.Nro;
            _reloj = _finTrasladoProx;

            //Actualización de la ambulancia
            actualizar_ambulancias(ambulancia_traslado, Estado_Ambulancia.LIBRE, -1);

            _finTraslado = -1;
            ambulancia_traslado = proxima_ambulancia_traslado();
            if (ambulancia_traslado != null) _finTrasladoProx = ambulancia_traslado.Tiempo;
            else _finTrasladoProx = -1;

    }

    private Ambulancia proxima_ambulancia_traslado()
        {
            return _ambulancias.OrderBy(x => x.Tiempo).ToList().Find(y => y.Estado == Estado_Ambulancia.VOLVIENDO);
        }

        internal void evento_fin_simulacion()
        {
            _evento = "Fin Simulacion";
        }

        private Ambulancia proxima_ambulancia_llego()
        {
            return _ambulancias.OrderBy(x => x.Tiempo).ToList().Find(y => y.Estado == Estado_Ambulancia.YENDO);
        }

        private void actualizar_ambulancias(Ambulancia ambulancia, string estado, double tiempo)
        {
            ambulancia.Estado = estado;
            ambulancia.Tiempo = tiempo;
            _ambulancias[ambulancia.Nro - 1] = ambulancia;
        }

        private void generar_proxima_llamada()
        {
            //Genero el rnd y el tiempo
            _e_llamada.generar_tiempo();

            _rndLlamada = _e_llamada.Rnd;
            _tiempoProximaLlamada = _e_llamada.Tiempo;
            _proximaLlamada = this._reloj + _tiempoProximaLlamada;
        }

        private void generar_proxima_llegada()
        {
            //Genero el rnd y el tiempo
            _e_llegada.generar_tiempo();

            _rndLlegada = _e_llegada.Rnd;
            _tiempoProximaLlegada = _e_llegada.Tiempo;
            _proximaLlegada = this._reloj + _tiempoProximaLlegada;


            if (_proximaFinLlegada < 0)
            {
                _proximaFinLlegada = _proximaLlegada;
            }
            else if (_proximaLlegada < 0)
            {
                _proximaFinLlegada = -1;
            }
            else if (_proximaLlegada < _proximaFinLlegada)
            {
                _proximaFinLlegada = _proximaLlegada;
            }

        }

        private void generar_proxima_traslado()
        {
            //Genero el rnd y el tiempo
            _e_traslado.generar_tiempo();

            _finTraslado = this._reloj + _e_traslado.Tiempo;
            actualizar_proximo_fin_traslado();
        }

        public Ambulancia existe_ambulancia_libre()
        {
            return _ambulancias.Find(x => x.Estado == Estado_Ambulancia.LIBRE);
        }


        public String proximo_evento()
        {
            //Si recien comienza la simulación, el reloj se encuentra el 0
            if (_reloj == 0 && _proximaLlamada < 0) return "Inicio";



            List<Evento> eventos = new List<Evento>();

            if (_proximaLlamada > 0)
            {
                eventos.Add(new Evento(Columnas.PROXIMA_LLAMADA, _proximaLlamada));
            }

            if (_proximaFinLlegada > 0)
            {
                eventos.Add(new Evento(Columnas.LLEGADA_PROXIMO, _proximaFinLlegada));
            }

            if (_finTrasladoProx > 0)
            {
                eventos.Add(new Evento(Columnas.TRASLADO_PROXIMO, _finTrasladoProx));
            }

            //Ordeno los eventos por su tiempo de menor a mayor
            eventos = eventos.OrderBy(x => x.Tiempo).ToList();

            //Al retornar el primer elemento, significa que es el proximo evento a suceder
            return eventos[0].NombreColum;
        }

        public void evento_inicio()
        {
            _evento = "Inicio";
            _reloj = 0;

            generar_proxima_llamada();
        }


        public String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_evento).Append(";");
            sb.Append(_reloj).Append(";"); ;

            if (_rndLlamada > 0) sb.Append(_rndLlamada).Append(";");
            else sb.Append("").Append(";");

            if (_tiempoProximaLlamada > 0) sb.Append(_tiempoProximaLlamada).Append(";");
            else sb.Append("").Append(";");

            if (_proximaLlamada > 0) sb.Append(_proximaLlamada).Append(";");
            else sb.Append("").Append(";");


            if (_rndLlegada > 0) sb.Append(_rndLlegada).Append(";");
            else sb.Append("").Append(";");

            if (_tiempoProximaLlegada > 0) sb.Append(_tiempoProximaLlegada).Append(";");
            else sb.Append("").Append(";");

            if (_proximaLlegada > 0) sb.Append(_proximaLlegada).Append(";");
            else sb.Append("").Append(";");


            if (_finTraslado > 0) sb.Append(_finTraslado).Append(";");
            else sb.Append("").Append(";");

            if (_finTrasladoProx > 0) sb.Append(_finTrasladoProx).Append(";");
            else sb.Append("").Append(";");


            foreach (Ambulancia ambulancia in _ambulancias)
            {
                sb.Append(ambulancia.ToString()).Append(";");
            }


            return sb.ToString();
        }

        public String getRndLlamada()
        {
            return _rndLlamada > 0 ? _rndLlamada.ToString() : "";
        }

        public String getTiempoEntreLlamada()
        {
            return _tiempoProximaLlamada > 0 ? _tiempoProximaLlamada.ToString() : "";
        }

        public String getProximaLlamada()
        {
            return _proximaLlamada > 0 ? _proximaLlamada.ToString() : "";
        }


        public String getRndLlegada()
        {
            return _rndLlegada > 0 ? _rndLlegada.ToString() : "";
        }

        public String getTiempoEntreLlegada()
        {
            return _tiempoProximaLlegada > 0 ? _tiempoProximaLlegada.ToString() : "";
        }

        public String getProximaLlegada()
        {
            return _proximaLlegada > 0 ? _proximaLlegada.ToString() : "";
        }
        public String getProximaFinLlegada()
        {
            return _proximaFinLlegada > 0 ? _proximaFinLlegada.ToString() : "";
        }

        
        public String getFinTraslado()
        {
            return _finTraslado > 0 ? _finTraslado.ToString() : "";
        }

        public String getFinTrasladoProx()
        {
            return _finTrasladoProx > 0 ? _finTrasladoProx.ToString() : "";
        }

    }
}
