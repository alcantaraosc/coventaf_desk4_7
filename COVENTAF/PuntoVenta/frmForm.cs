using COVENTAF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class frmForm : Form
    {
        public frmForm()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            


            var crearTicket = new Metodos.MetodoCrearTicket.CreaTicket();
            crearTicket.TextoIzquierda("***********************************************************************************************");
            crearTicket.TextoIzquierda("                    EJERCITO DE NICARAGUA");
            crearTicket.TextoCentro("EJERCITO DE NICARAGUA");
            crearTicket.TextoCentro("TIENDA ELECTRODOMESTICO");
            crearTicket.TextoCentro("TELEFONO: 224436-61");
            crearTicket.TextoCentro("");

            crearTicket.TextoIzquierda("No Factura: 0252555");
            crearTicket.TextoIzquierda("Cliente: T2522512444");
            crearTicket.TextoIzquierda("Oscar Omar Alcantara Duarte");
            crearTicket.TextoIzquierda("Caja: T01C2");

            crearTicket.TextoIzquierda("");
            crearTicket.LineasGuion();

            crearTicket.EncabezadoVenta();

            for (var row =0; row <= 40; row++)
            {
                
                crearTicket.AgregaArticulo("23003842" + row.ToString(),3.50M, 5.00M, 1500.30M);
                crearTicket.TextoIzquierda("30% = C$30.60");
                crearTicket.TextoIzquierda("JABON PARA DAMA DE LA CLASE MEDIA ALTA DE 35GR");
                //crearTicket.TextoCentro("TIENDA ELECTRODOMESTICO");
                //crearTicket.TextoCentro("TELEFONO: 224436-61");
                //crearTicket.TextoIzquierda("No Factura: 0252555");
                //crearTicket.TextoIzquierda("Cliente: T2522512444");
                //crearTicket.TextoIzquierda("Oscar Omar Alcantara Duarte");
                //crearTicket.TextoIzquierda("Caja: T01C2");
            }
            crearTicket.LineasGuion();


            crearTicket.TextoExtremos("Extremo 1", "extemo2" );
            crearTicket.TextoDerecha("Total a pagar c$50.00");
            crearTicket.LineasGuion();

            crearTicket.TextoCentro("METODO DE PAGO");
            crearTicket.TextoIzquierda("TARJETA DE CREDITO C$500.03");
            crearTicket.TextoIzquierda("TARJETA DOLAR C$500.03");
            crearTicket.TextoIzquierda("EFECTIVO C$500.03");
            crearTicket.TextoIzquierda("EFECTIVO C$500.03");
            crearTicket.TextoIzquierda("SU CAMBIO: C$ 0.00");

            crearTicket.TextoIzquierda("OBSERAVACIONES: EL CLIENTE VINO A PAGAR CON TARJETA DE CREDITO SE PUSO MOLESTO Y DIJO Q NO VOLVIA A VENIR A COMPRAR  A LA TIENDA YA QUE SEGUN EL DICE QUE EL CAJERO OSCRA ALCANTARA CON CEDULA 001-241080-0028U NO LO ATENDIO COMO SE LO MERECE X TANTO NUNCA MASVUELVE. GRACIAS");
            crearTicket.TextoIzquierda("ATENDIDO POR OSCAR OMAR ALCANTARA DUARTE");




            crearTicket.TextoCentro("Gracia por su compra");


            crearTicket.ImprimirTiket(Utilidades.GetDefaultPrintName());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Metodos.MetodoImpresion().ImprimirTicketFactura_Prueba();
        }
    }
}

