
namespace Servicio_107
{
    partial class Simulacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_evento_llamada = new System.Windows.Forms.GroupBox();
            this.txt_lambda_llamada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_distribucion_llamada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_evento_llegada_ambulancia = new System.Windows.Forms.GroupBox();
            this.txt_B_llegada_ambulancia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_A_llegada_ambulancia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_distribucacion_llegada_ambulancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_evento_traslado_paciente = new System.Windows.Forms.GroupBox();
            this.txt_tiempo_traslado_paciente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_distribucion_traslado_paciente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_grilla = new System.Windows.Forms.DataGridView();
            this.btn_simular = new System.Windows.Forms.Button();
            this.txt_cantidad_ambulancias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_tiempo_simulacion = new System.Windows.Forms.TextBox();
            this.txt_desde = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_hasta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dg_evento_llamada.SuspendLayout();
            this.gb_evento_llegada_ambulancia.SuspendLayout();
            this.gb_evento_traslado_paciente.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_evento_llamada
            // 
            this.dg_evento_llamada.Controls.Add(this.txt_lambda_llamada);
            this.dg_evento_llamada.Controls.Add(this.label2);
            this.dg_evento_llamada.Controls.Add(this.txt_distribucion_llamada);
            this.dg_evento_llamada.Controls.Add(this.label1);
            resources.ApplyResources(this.dg_evento_llamada, "dg_evento_llamada");
            this.dg_evento_llamada.Name = "dg_evento_llamada";
            this.dg_evento_llamada.TabStop = false;
            // 
            // txt_lambda_llamada
            // 
            resources.ApplyResources(this.txt_lambda_llamada, "txt_lambda_llamada");
            this.txt_lambda_llamada.Name = "txt_lambda_llamada";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txt_distribucion_llamada
            // 
            resources.ApplyResources(this.txt_distribucion_llamada, "txt_distribucion_llamada");
            this.txt_distribucion_llamada.Name = "txt_distribucion_llamada";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gb_evento_llegada_ambulancia
            // 
            this.gb_evento_llegada_ambulancia.Controls.Add(this.txt_B_llegada_ambulancia);
            this.gb_evento_llegada_ambulancia.Controls.Add(this.label5);
            this.gb_evento_llegada_ambulancia.Controls.Add(this.txt_A_llegada_ambulancia);
            this.gb_evento_llegada_ambulancia.Controls.Add(this.label3);
            this.gb_evento_llegada_ambulancia.Controls.Add(this.txt_distribucacion_llegada_ambulancia);
            this.gb_evento_llegada_ambulancia.Controls.Add(this.label4);
            resources.ApplyResources(this.gb_evento_llegada_ambulancia, "gb_evento_llegada_ambulancia");
            this.gb_evento_llegada_ambulancia.Name = "gb_evento_llegada_ambulancia";
            this.gb_evento_llegada_ambulancia.TabStop = false;
            // 
            // txt_B_llegada_ambulancia
            // 
            resources.ApplyResources(this.txt_B_llegada_ambulancia, "txt_B_llegada_ambulancia");
            this.txt_B_llegada_ambulancia.Name = "txt_B_llegada_ambulancia";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txt_A_llegada_ambulancia
            // 
            resources.ApplyResources(this.txt_A_llegada_ambulancia, "txt_A_llegada_ambulancia");
            this.txt_A_llegada_ambulancia.Name = "txt_A_llegada_ambulancia";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txt_distribucacion_llegada_ambulancia
            // 
            resources.ApplyResources(this.txt_distribucacion_llegada_ambulancia, "txt_distribucacion_llegada_ambulancia");
            this.txt_distribucacion_llegada_ambulancia.Name = "txt_distribucacion_llegada_ambulancia";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // gb_evento_traslado_paciente
            // 
            this.gb_evento_traslado_paciente.Controls.Add(this.txt_tiempo_traslado_paciente);
            this.gb_evento_traslado_paciente.Controls.Add(this.label6);
            this.gb_evento_traslado_paciente.Controls.Add(this.txt_distribucion_traslado_paciente);
            this.gb_evento_traslado_paciente.Controls.Add(this.label7);
            resources.ApplyResources(this.gb_evento_traslado_paciente, "gb_evento_traslado_paciente");
            this.gb_evento_traslado_paciente.Name = "gb_evento_traslado_paciente";
            this.gb_evento_traslado_paciente.TabStop = false;
            // 
            // txt_tiempo_traslado_paciente
            // 
            resources.ApplyResources(this.txt_tiempo_traslado_paciente, "txt_tiempo_traslado_paciente");
            this.txt_tiempo_traslado_paciente.Name = "txt_tiempo_traslado_paciente";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txt_distribucion_traslado_paciente
            // 
            resources.ApplyResources(this.txt_distribucion_traslado_paciente, "txt_distribucion_traslado_paciente");
            this.txt_distribucion_traslado_paciente.Name = "txt_distribucion_traslado_paciente";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_grilla);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // dgv_grilla
            // 
            this.dgv_grilla.AllowUserToAddRows = false;
            this.dgv_grilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_grilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_grilla.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgv_grilla, "dgv_grilla");
            this.dgv_grilla.Name = "dgv_grilla";
            this.dgv_grilla.ReadOnly = true;
            // 
            // btn_simular
            // 
            resources.ApplyResources(this.btn_simular, "btn_simular");
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // txt_cantidad_ambulancias
            // 
            resources.ApplyResources(this.txt_cantidad_ambulancias, "txt_cantidad_ambulancias");
            this.txt_cantidad_ambulancias.Name = "txt_cantidad_ambulancias";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txt_tiempo_simulacion
            // 
            resources.ApplyResources(this.txt_tiempo_simulacion, "txt_tiempo_simulacion");
            this.txt_tiempo_simulacion.Name = "txt_tiempo_simulacion";
            // 
            // txt_desde
            // 
            resources.ApplyResources(this.txt_desde, "txt_desde");
            this.txt_desde.Name = "txt_desde";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txt_hasta
            // 
            resources.ApplyResources(this.txt_hasta, "txt_hasta");
            this.txt_hasta.Name = "txt_hasta";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // Simulacion
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_hasta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_desde);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_tiempo_simulacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_cantidad_ambulancias);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_evento_traslado_paciente);
            this.Controls.Add(this.gb_evento_llegada_ambulancia);
            this.Controls.Add(this.dg_evento_llamada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Simulacion";
            this.Load += new System.EventHandler(this.Simulacion_Load);
            this.dg_evento_llamada.ResumeLayout(false);
            this.dg_evento_llamada.PerformLayout();
            this.gb_evento_llegada_ambulancia.ResumeLayout(false);
            this.gb_evento_llegada_ambulancia.PerformLayout();
            this.gb_evento_traslado_paciente.ResumeLayout(false);
            this.gb_evento_traslado_paciente.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox dg_evento_llamada;
        private System.Windows.Forms.TextBox txt_lambda_llamada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_distribucion_llamada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_evento_llegada_ambulancia;
        private System.Windows.Forms.TextBox txt_B_llegada_ambulancia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_A_llegada_ambulancia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_distribucacion_llegada_ambulancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_evento_traslado_paciente;
        private System.Windows.Forms.TextBox txt_tiempo_traslado_paciente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_distribucion_traslado_paciente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_grilla;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.TextBox txt_cantidad_ambulancias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_tiempo_simulacion;
        private System.Windows.Forms.TextBox txt_desde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_hasta;
        private System.Windows.Forms.Label label11;
    }
}

