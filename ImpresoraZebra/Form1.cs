using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZebraTesting;

namespace ImpresoraZebra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZebraPrint();
        }
        public void ZebraPrint()
        {
            try
            {
                String Marca = txtbxMarca.Text;
                String Descripcion = txtbxDescrpcion.Text;
                var sb = new StringBuilder();
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                sb.AppendLine();// la primera linea siempre tiene que estar en blanco
                sb.AppendLine("N"); // se limpia la imagen del buffer
                sb.AppendLine("q425");//Se dice el ancho de la etiqueta Cuidado no del contenido
                sb.AppendLine("Q300,26");// Declaramos el alto
                /* la siguiente linea es la que da las propiedades al contenido dentro de la etiqueta  como dodne quiere que empiece 
                los parametros son los siguientes 
                Apunto de partida horizontal,punto de partida Vertical,rotacion de los caracteres,
                Fuente que se quiere, Expansion horizontal ,Expancion vertical,busqueda inversa de imagenes , los datos a imprimir
                */
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                    "A26,96,0,4,1,1,N,\"{0}\"",Marca));

                sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                    "A26,130,0,4,1,1,N,\"{0}\"", Descripcion));

                sb.AppendLine("P1,1");//en esta linea se señana  el comando para imprimir y la cantidad  de etiquetas

                if (DialogResult.OK==pd.ShowDialog(this))
                {
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, sb.ToString());
                }


            }
            catch (Exception es)
            {
                MessageBox.Show("error al imprimir: " + es.Message);
            }
        }
    }
}
