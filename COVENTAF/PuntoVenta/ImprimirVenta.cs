using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace COVENTAF.PuntoVenta
{
    public partial class ImprimirVenta : Form
    {
        private List<DetalleFactura> _listDetFactura;
        private Encabezado _datoEncabezadoFact;

        public ImprimirVenta(List<DetalleFactura> listDetFactura, Encabezado datoEncabezadoFact)
        {
            InitializeComponent();
            this._listDetFactura = listDetFactura;
            this._datoEncabezadoFact = datoEncabezadoFact;
        }

        private void ImprimirVenta_Load(object sender, EventArgs e)
        {
            string tickettexto = Properties.Resources.TicketVenta.ToString();
            //Tienda otienda = TiendaLogica.Instancia.Obtener();
            //Venta oVenta = VentaLogica.Instancia.ListarVenta().Where(v => v.IdVenta == _IdVenta).FirstOrDefault();
            //List<DetalleVenta> oDetalleVenta = VentaLogica.Instancia.ListarDetalleVenta().Where(dv => dv.IdVenta == _IdVenta).ToList();

            tickettexto = tickettexto.Replace("{nombreEmpresa}", User.NombreTienda);
            tickettexto = tickettexto.Replace("{direccionEmpresa}", User.DireccionTienda);
            tickettexto = tickettexto.Replace("{telefonoEmpresa}", User.TelefonoTienda);
            tickettexto = tickettexto.Replace("{numeroRucEmpresa}", "J1330000001272");

            tickettexto = tickettexto.Replace("{factura}", _datoEncabezadoFact.noFactura);
            tickettexto = tickettexto.Replace("{codigoCliente}", _datoEncabezadoFact.codigoCliente);
            tickettexto = tickettexto.Replace("{cliente}", _datoEncabezadoFact.cliente);
            tickettexto = tickettexto.Replace("{fechaventa}", _datoEncabezadoFact.fecha.ToString("dd/MM/yyyy HH:mm:ss"));

            tickettexto = tickettexto.Replace("{bodega}", _datoEncabezadoFact.bodega);
            tickettexto = tickettexto.Replace("{caja}", _datoEncabezadoFact.caja);
            tickettexto = tickettexto.Replace("{tipocambio}", _datoEncabezadoFact.tipoCambio.ToString("N4"));

            StringBuilder tr = new StringBuilder();
            foreach (var factLinea in _listDetFactura)
            {
                tr.AppendLine("<tr>");
                tr.AppendLine("<td width=\"30\">" + factLinea.ArticuloId + "</td>");
                tr.AppendLine("<td width=\"15\">" + factLinea.Cantidad + "</td>");
                tr.AppendLine("<td width=\"30\">" + factLinea.PrecioCordobas.ToString("N2") + "</td>");
                tr.AppendLine("<td width=\"30\">" + factLinea.DescuentoPorLineaCordoba.ToString("N2") + "</td>");
                tr.AppendLine("<td width=\"30\">" + factLinea.TotalCordobas.ToString("N2") + "</td>");
                tr.AppendLine("</tr>");
                tr.AppendLine("<tr style=\"font-size:14px\">");
                tr.AppendLine("<td colspan=\"5\">" + factLinea.Descripcion + " </td>");
                tr.AppendLine("</tr>");
            }
            tickettexto = tickettexto.Replace("{detalleFacturaLinea}", tr.ToString());

            tickettexto = tickettexto.Replace("{subtotal}", _datoEncabezadoFact.subTotalCordoba.ToString("N2"));
            tickettexto = tickettexto.Replace("{descuento}", _datoEncabezadoFact.descuentoCordoba.ToString("N2"));
            tickettexto = tickettexto.Replace("{retencion}", _datoEncabezadoFact.MontoRetencion.ToString("N2"));
            tickettexto = tickettexto.Replace("{iva}", _datoEncabezadoFact.ivaCordoba.ToString("N2"));

            tickettexto = tickettexto.Replace("{totalpagar}", _datoEncabezadoFact.totalCordoba.ToString("N2"));
            tickettexto = tickettexto.Replace("{totalpagardolar}", _datoEncabezadoFact.totalDolar.ToString("N2"));
            tickettexto = tickettexto.Replace("{recibido}", "ESTA PENDIENTE");
            tickettexto = tickettexto.Replace("{sucambio}", "ESTA PENDIENTE");
            tickettexto = tickettexto.Replace("{formapago}", _datoEncabezadoFact.formaDePago);
            tickettexto = tickettexto.Replace("{observaciones}", _datoEncabezadoFact.observaciones);
            tickettexto = tickettexto.Replace("{cajero}", User.NombreUsuario);



            webBrowser1.DocumentText = tickettexto;
            //webBrowser1.Print();
            //webBrowser1.ShowPrintPreviewDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
