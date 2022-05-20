using Servicio_107.Estados;
using Servicio_107.Eventos;
using Servicio_107.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio_107
{
    public partial class Simulacion : Form
    {
        VectorEstado vectorEstado;
        /*
        List<Ambulancia> ambulancias;
        Llamada e_llamada;
        LlegadaAmbulancia e_llegada;
        TrasladoPaciente e_traslado;
        */

        public Simulacion()
        {
            InitializeComponent();
        }

        private void Simulacion_Load(object sender, EventArgs e)
        {
            valores_por_defecto();
            //crear_ambulancias();
            //generar_grilla();
        }
        
        /*
        private void crear_ambulancias()
        {
            this.ambulancias = new List<Ambulancia>();

            for (int i = 1; i <= int.Parse(txt_cantidad_ambulancias.Text); i++)
            {
                ambulancias.Add(new Ambulancia(i, Estado_Ambulancia.LIBRE));
            }
        }
        */
        
        private void generar_grilla()
        {
            dgv_grilla.Columns.Add(Columnas.EVENTO, "Evento");
            dgv_grilla.Columns.Add(Columnas.RELOJ, "Reloj");

            //Evento Llamada
            dgv_grilla.Columns.Add(Columnas.RND_LLAMADA, "Rnd");
            dgv_grilla.Columns.Add(Columnas.TIEMPO_PROXIMA_LLAMADA, "Tiempo Prox. Llamada");
            dgv_grilla.Columns.Add(Columnas.PROXIMA_LLAMADA, "Prox. Llamada");

            //Evento Llegada Ambulancia
            dgv_grilla.Columns.Add(Columnas.RND_LLEGADA, "Rnd");
            dgv_grilla.Columns.Add(Columnas.TIEMPO_PROXIMA_LLEGADA, "Tiempo Prox. Llegada");
            dgv_grilla.Columns.Add(Columnas.LLEGADA, "Prox. Llegada");
            dgv_grilla.Columns.Add(Columnas.LLEGADA_PROXIMO, "Prox. Fin Llegada");
            

            //Evento Traslado
            dgv_grilla.Columns.Add(Columnas.TRASLADO, "Fin Traslado");
            dgv_grilla.Columns.Add(Columnas.TRASLADO_PROXIMO, "Fin Traslado Prox.");

            

            //Ambulancias
            foreach (Ambulancia ambulancia in vectorEstado.Ambulancias)
            {
                dgv_grilla.Columns.Add(Columnas.AMBULANCIA_X + ambulancia.Nro, "Ambulancia " + ambulancia.Nro);
            }
        }
        

        private void valores_por_defecto()
        {
            txt_distribucion_llamada.Text = "Exponencial";
            txt_lambda_llamada.Text = "0,5";

            txt_distribucacion_llegada_ambulancia.Text = "Uniforme";
            txt_A_llegada_ambulancia.Text = "12";
            txt_B_llegada_ambulancia.Text = "25";

            txt_distribucion_traslado_paciente.Text = "Constante";
            txt_tiempo_traslado_paciente.Text = "10";

            txt_cantidad_ambulancias.Text = "4";

            txt_tiempo_simulacion.Text = "4";
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            //Creación de los eventos con sus parametros
            /*
            this.e_llamada = new Llamada(Double.Parse(txt_lambda_llamada.Text));
            this.e_llegada = new LlegadaAmbulancia(Double.Parse(txt_A_llegada_ambulancia.Text), Double.Parse(txt_B_llegada_ambulancia.Text));
            this.e_traslado = new TrasladoPaciente(Double.Parse(txt_tiempo_traslado_paciente.Text));
            */

            //Limpieza de grilla
            dgv_grilla.Rows.Clear();
            dgv_grilla.Columns.Clear();

            //Inicialización del vector de estado
            vectorEstado = new VectorEstado();
            vectorEstado.crear_evento_llamada(Double.Parse(txt_lambda_llamada.Text));
            vectorEstado.crear_evento_llegada(Double.Parse(txt_A_llegada_ambulancia.Text), Double.Parse(txt_B_llegada_ambulancia.Text));
            vectorEstado.crear_evento_traslado(Double.Parse(txt_tiempo_traslado_paciente.Text));

            vectorEstado.crear_ambulancias(int.Parse(txt_cantidad_ambulancias.Text));

            generar_grilla();

            //Variables para manipular el tiempo de simulacion
            Double tiempo_fin_simulacion = Double.Parse(txt_tiempo_simulacion.Text);
            //Double tiempo_desde = Double.Parse(txt_desde.Text);
            //Double tiempo_hasta = Double.Parse(txt_hasta.Text);

            for (double i = 0; i <= tiempo_fin_simulacion; i = vectorEstado.Reloj)
            {
                String c_evento = vectorEstado.proximo_evento();

                switch (c_evento)
                {
                    case "Inicio":
                        vectorEstado.evento_inicio();
                        break;

                    case Columnas.PROXIMA_LLAMADA:
                        vectorEstado.evento_proxima_llamada();
                        break;

                    case Columnas.LLEGADA_PROXIMO:
                        vectorEstado.evento_proxima_llegada();
                        break;

                    case Columnas.TRASLADO_PROXIMO:
                        vectorEstado.evento_fin_traslado();
                        break;
                }

                dibujar_grilla(c_evento);
            }


            //vectorEstado.evento_fin_simulacion();
            //dibujar_grilla("Fin");
        }

        private void dibujar_grilla(String c_evento)
        {
            dgv_grilla.Rows.Add();

            int fila = dgv_grilla.Rows.Count - 1;

            if (c_evento != "Inicio" && c_evento != "Fin") dgv_grilla[c_evento, fila-1].Style.BackColor = Color.Yellow;

            dgv_grilla[Columnas.EVENTO, fila].Value = vectorEstado.Evento;
            dgv_grilla[Columnas.RELOJ, fila].Value = vectorEstado.Reloj;

            dgv_grilla[Columnas.RND_LLAMADA, fila].Value = vectorEstado.getRndLlamada();
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLAMADA, fila].Value = vectorEstado.getTiempoEntreLlamada();
            dgv_grilla[Columnas.PROXIMA_LLAMADA, fila].Value = vectorEstado.getProximaLlamada();

            dgv_grilla[Columnas.RND_LLEGADA, fila].Value = vectorEstado.getRndLlegada();
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLEGADA, fila].Value = vectorEstado.getTiempoEntreLlegada();
            dgv_grilla[Columnas.LLEGADA, fila].Value = vectorEstado.getProximaLlegada();
            dgv_grilla[Columnas.LLEGADA_PROXIMO, fila].Value = vectorEstado.getProximaFinLlegada();


            dgv_grilla[Columnas.TRASLADO, fila].Value = vectorEstado.getFinTraslado();
            dgv_grilla[Columnas.TRASLADO_PROXIMO, fila].Value = vectorEstado.getFinTrasladoProx();

            //Actualizacion de las ambulancias
            foreach (Ambulancia ambulancia in vectorEstado.Ambulancias)
            {
                dgv_grilla[Columnas.AMBULANCIA_X + ambulancia.Nro, dgv_grilla.Rows.Count - 1].Value = ambulancia.ToString();
            }
        }

        /*
        private void evento_fin_traslado()
        {
            //Obtengo la ambulancia que retorno con el paciente
            Ambulancia ambulancia_x = this.ambulancias.OrderBy(x => x.Tiempo).ToList().Find(y => y.Estado == Estado_Ambulancia.VOLVIENDO);


            dgv_grilla.Rows.Add();

            dgv_grilla[Columnas.EVENTO, dgv_grilla.Rows.Count - 1].Value = "Fin Traslado " + ambulancia_x.Nro;
            dgv_grilla[Columnas.RELOJ, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 2].Value.ToString();


            //Actualizacion de la Ambulancia
            ambulancia_x.Estado = Estado_Ambulancia.LIBRE;
            ambulancia_x.Tiempo = -1;
            this.ambulancias[ambulancia_x.Nro - 1] = ambulancia_x;


            //Busco la proxima ambulancia que esté retornando
            ambulancia_x = this.ambulancias.OrderBy(x => x.Tiempo).ToList().Find(y => y.Estado == Estado_Ambulancia.VOLVIENDO);
            if(ambulancia_x != null) dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value = ambulancia_x.Tiempo;
            else dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value = "";


            //Copia de valores de las columnas no afectadas por el evento
            dgv_grilla[Columnas.RND_LLAMADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 2].Value.ToString();

            dgv_grilla[Columnas.RND_LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 2].Value.ToString();

        }

        private void grabar_grilla()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("D:\\Test.txt");

                for (int i = 0; i < dgv_grilla.Rows.Count; i++)
                {
                    String cad = "";
                    for (int j = 0; j < dgv_grilla.Rows[i].Cells.Count; j++)
                    {
                        cad = cad + "," + dgv_grilla[j, i].Value.ToString();
                    }

                    sw.WriteLine(cad);
                }

                sw.WriteLine();

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void evento_proxima_llegada()
        {
            //Obtengo la ambulancia que llega
            Ambulancia ambulancia_x = this.ambulancias.OrderBy(x => x.Tiempo).ToList().Find(y => y.Estado == Estado_Ambulancia.YENDO);



            dgv_grilla.Rows.Add();

            dgv_grilla[Columnas.EVENTO, dgv_grilla.Rows.Count - 1].Value = "Llegada Ambulancia " + ambulancia_x.Nro;
            dgv_grilla[Columnas.RELOJ, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 2].Value.ToString();

            //Se calcula el tiempo de Traslado
            this.e_traslado.generar_tiempo();
            dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value = Double.Parse(dgv_grilla[Columnas.RELOJ, dgv_grilla.Rows.Count - 1].Value.ToString()) + this.e_traslado.Tiempo;

            //Actualizacion de la Ambulancia
            ambulancia_x.Estado = Estado_Ambulancia.VOLVIENDO;
            ambulancia_x.Tiempo = Double.Parse(dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value.ToString());
            this.ambulancias[ambulancia_x.Nro-1] = ambulancia_x;

            //Se busca el tiempo de la proxima ambulancia que llega al lugar solicitado
            Ambulancia proxima_ambulancia = this.ambulancias.OrderBy(x => x.Tiempo).ToList().Find(y => y.Estado == Estado_Ambulancia.YENDO);
            dgv_grilla[Columnas.RND_LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";
            if(proxima_ambulancia != null) dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value = proxima_ambulancia.Tiempo;
            else dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";



            //Actualizacion de las ambulancias
            foreach (Ambulancia ambulancia in this.ambulancias)
            {
                dgv_grilla[Columnas.AMBULANCIA_X + ambulancia.Nro, dgv_grilla.Rows.Count - 1].Value = ambulancia.ToString();
            }


            //Copia de valores de las columnas no afectadas por el evento
            dgv_grilla[Columnas.RND_LLAMADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value = "";
            dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 2].Value.ToString();



            //FALTA ACTUALIZAR LOS PACIENTES
        }

        private void evento_proxima_llamada()
        {
            dgv_grilla.Rows.Add();

            dgv_grilla[Columnas.EVENTO, dgv_grilla.Rows.Count - 1].Value = "Llamado";
            dgv_grilla[Columnas.RELOJ, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 2].Value.ToString();

            //Calculo la proxima llamada
            this.e_llamada.generar_tiempo();
            dgv_grilla[Columnas.RND_LLAMADA, dgv_grilla.Rows.Count - 1].Value = e_llamada.Rnd;
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value = e_llamada.Tiempo;
            dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value = Double.Parse(dgv_grilla[Columnas.RELOJ, dgv_grilla.Rows.Count - 1].Value.ToString()) + e_llamada.Tiempo;

            //Buscamos si tenemos alguna ambulancia libre, la primera libre será asignada al llamado
            Ambulancia ambulancia_libre = this.ambulancias.Find(x => x.Estado == Estado_Ambulancia.LIBRE);
            if(ambulancia_libre != null) //Si encontramos una ambulancia libre
            {
                //Calculamos el tiempo de llegada
                this.e_llegada.generar_tiempo();
                dgv_grilla[Columnas.RND_LLEGADA, dgv_grilla.Rows.Count - 1].Value = e_llegada.Rnd;
                dgv_grilla[Columnas.TIEMPO_PROXIMA_LLEGADA, dgv_grilla.Rows.Count - 1].Value = e_llegada.Tiempo;
                dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value = Double.Parse(dgv_grilla[Columnas.RELOJ, dgv_grilla.Rows.Count - 1].Value.ToString()) + e_llegada.Tiempo;

                //Actualizamos el estado de la ambulancia
                ambulancia_libre.Estado = Estado_Ambulancia.YENDO;
                ambulancia_libre.Tiempo = Double.Parse(dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value.ToString());
                this.ambulancias[ambulancia_libre.Nro - 1] = ambulancia_libre;
            }
            else //No tengo Ambulancias LIBRE
            {
                dgv_grilla[Columnas.RND_LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";
                dgv_grilla[Columnas.TIEMPO_PROXIMA_LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";

                Ambulancia ambulancia_mas_proxima = this.ambulancias.OrderBy(x => x.Tiempo).ToList().Find(x => x.Estado == Estado_Ambulancia.YENDO);
                if (ambulancia_mas_proxima != null) dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value = ambulancia_mas_proxima.Tiempo;
                else dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value = "";

            }




            //Actualizacion de las ambulancias
            foreach (Ambulancia ambulancia in this.ambulancias)
            {
                dgv_grilla[Columnas.AMBULANCIA_X + ambulancia.Nro, dgv_grilla.Rows.Count - 1].Value = ambulancia.ToString();
            }

            //Copia de valores de las columnas no afectadas por el evento
            dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value = dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 2].Value.ToString();



            //FALTA ACTUALIZAR PACIENTES
        }

        private void evento_inicio()
        {
            dgv_grilla.Rows.Add();

            dgv_grilla[Columnas.EVENTO, 0].Value = "Inicio";
            dgv_grilla[Columnas.RELOJ, 0].Value = "0";

            foreach (Ambulancia ambulancia in this.ambulancias)
            {
                dgv_grilla[Columnas.AMBULANCIA_X + ambulancia.Nro, 0].Value = ambulancia.Estado;
            }

            //Como es el evento de inicio, calculo la proxima llamada
            this.e_llamada.generar_tiempo();
            dgv_grilla[Columnas.RND_LLAMADA, 0].Value = e_llamada.Rnd;
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLAMADA, 0].Value = e_llamada.Tiempo;
            dgv_grilla[Columnas.PROXIMA_LLAMADA, 0].Value = e_llamada.Tiempo;


            //Evento Llegada Ambulancia
            dgv_grilla[Columnas.RND_LLEGADA, 0].Value = "";
            dgv_grilla[Columnas.TIEMPO_PROXIMA_LLEGADA, 0].Value = "";
            dgv_grilla[Columnas.LLEGADA, 0].Value = "";

            //Evento Traslado
            dgv_grilla[Columnas.TRASLADO, 0].Value = "";
        }

        private string proximo_evento()
        {
            if (dgv_grilla.Rows.Count == 0) return "Inicio";



            List<Evento> eventos = new List<Evento>();

            if(string.IsNullOrWhiteSpace(dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value.ToString()) == false)
            {
                eventos.Add(new Evento(Columnas.PROXIMA_LLAMADA, Double.Parse(dgv_grilla[Columnas.PROXIMA_LLAMADA, dgv_grilla.Rows.Count - 1].Value.ToString())));
            }

            if (string.IsNullOrWhiteSpace(dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value.ToString()) == false)
            {
                eventos.Add(new Evento(Columnas.LLEGADA, Double.Parse(dgv_grilla[Columnas.LLEGADA, dgv_grilla.Rows.Count - 1].Value.ToString())));
            }

            if (string.IsNullOrWhiteSpace(dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value.ToString()) == false)
            {
                eventos.Add(new Evento(Columnas.TRASLADO, Double.Parse(dgv_grilla[Columnas.TRASLADO, dgv_grilla.Rows.Count - 1].Value.ToString())));
            }

            eventos = eventos.OrderBy(x => x.Tiempo).ToList();

            return eventos[0].NombreColum;

        }
        */
    }
}
