using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Documento_Pos
    {
        [Required]
        [StringLength(50)]
        public string Documento { get; set; }
        [StringLength(1)]
        public string Tipo { get; set; }
        [StringLength(6)]
        public string Caja { get; set; }
        [StringLength(6)]
        public string Caja_Cobro { get; set; }
        [StringLength(10)]
        public string Correlativo { get; set; }
        [StringLength(4)]
        public string Perfil { get; set; }
        [StringLength(4)]
        public string Vendedor { get; set; }
        [StringLength(20)]
        public string Cliente { get; set; }
        /*public varchar(150) string Nombre_Cliente { get; set; }
        public varchar(25) string Cajero { get; set; }
        public decimal  Impuesto1 { get; set; }
        public decimal  Impuesto2 { get; set; }
        public decimal  Descuento { get; set; }
        public decimal  Total_Pagar { get; set; }
        public decimal  Total { get; set; }
        public datetime  Fch_Hora_Creacion { get; set; }
        public datetime  Fch_Hora_Cobro { get; set; }
        public datetime  Fch_Hora_Anula { get; set; }
        public varchar(1) string Exportado { get; set; }
        public varchar(1) string Estado_Cobro { get; set; }
        public decimal  Saldo { get; set; }
        public decimal  Saldo_Reporte { get; set; }
        public varchar(1) string Moneda_Doc { get; set; }
        public datetime  Fecha_Vence { get; set; }
        public varchar(1) string Listo_Inventario { get; set; }
        public varchar(12) string Nivel_Precio { get; set; }
        public varchar(1) string Moneda_Nivel { get; set; }
        public int string Version { get; set; }
        public datetime string Fechanac_Cliente { get; set; }
        public varchar(50) string Telefono_Cliente { get; set; }
        public varchar(20) string Nit_Cliente { get; set; }
        public text string Notas { get; set; }
        public varchar(4) string Pais { get; set; }
        public varchar(1) string Clase_Documento { get; set; }
        public varchar(4000) string Direccion { get; set; }
        public varchar(1) string Exportado_Tienda { get; set; }
        public varchar(4) string Condicion_Pago_Apa { get; set; }
        public varchar(50) string Doc_Cc { get; set; }
        public varchar(3) string Tipo_Doc_Cc { get; set; }
        public varchar(1) string Cargado_Cc { get; set; }
        public varchar(1) string Cargado_Cg { get; set; }
        public varchar(1) string Devuelve_Dinero { get; set; }
        public varchar(50) string Doc_Cc_Anul { get; set; }
        public varchar(3) string Tipo_Doc_Cc_Anul { get; set; }
        public varchar(1) string Genero_Factura_Inicio { get; set; }
        public varchar(1) string Afecta_Contabil { get; set; }
        public decimal string Efectivo_Devuelto { get; set; }
        public decimal string Tipo_Cambio { get; set; }
        public varchar(254) string Beneficiario { get; set; }
        public varchar(1) string Moneda { get; set; }
        public varchar(1) string Subtipo { get; set; }
        public varchar(20) string Id_Beneficiario { get; set; }
        public varchar(25) string Usuario_Ult_Impre { get; set; }
        public datetime string Fch_Hora_Ult_Impre { get; set; }
        public varchar(25) string Usuario_Aplicacion { get; set; }
        public datetime string Fch_Hora_Aplicacio { get; set; }
        public varchar(25) string Usuario_Anulacion { get; set; }
        public varchar(1) string Estado_Impresion { get; set; }
        public varchar(50) string Telefono_Beneficia { get; set; }
        public varchar(20) string Ncf { get; set; }
        public varchar(6) string Tipo_Ncf { get; set; }
        public varchar(20) string Num_Cierre { get; set; }
        public varchar(150) string Recibido_De { get; set; }
        public varchar(20) string Resolucion { get; set; }
        public varchar(10) string Cod_Clase_Doc { get; set; }
        public varchar(1) string Doc_Express { get; set; }
        public varchar(10) string Mensajero { get; set; }
        public varchar(20) string Cliente_Express { get; set; }
        public varchar(80) string Entrega_Exprss_A { get; set; }
        public varchar(1) string Estado_Express { get; set; }
        public decimal string Monto_Entregado { get; set; }
        public decimal string Monto_Devuelto { get; set; }
        public datetime string Fch_Envio { get; set; }
        public datetime string Fch_Entrega { get; set; }
        public varchar(10) string Motiv_Cancela_Expr { get; set; }
        public varchar(1000) string Nota_Express { get; set; }
        public decimal string Base_Impuesto1 { get; set; }
        public decimal string Base_Impuesto2 { get; set; }
        public varchar(50) string Doc_Fiscal { get; set; }
        public varchar(50) string Prefijo { get; set; }
        public varchar(50) string Pedido_Autorizado { get; set; }
        public varchar(50) string Doc_Cc_Anticipo { get; set; }
        public varchar(20) string Nombremaquina { get; set; }
        public varchar(20) string Cierre_Anulacion { get; set; }
        public varchar(1) string Doc_Sincronizado { get; set; }
        public decimal string Monto_Bonificado { get; set; }
        public varchar(1) string Es_Doc_Externo { get; set; }
        public varchar(4000) string Tienda_Enviado { get; set; }
        public varchar(1) string Usa_Despachos { get; set; }
        public varchar(50) string Clave_Referencia_De { get; set; }
        public datetime string Fecha_Referencia_De { get; set; }
        public varchar(4) string Forma_Pago { get; set; }
        public varchar(3) string Uso_Cfdi { get; set; }
        public varchar(2) string Justi_Dev_Haciend { get; set; }
        public varchar(50) string Clave_De { get; set; }
        public tinyint string Noteexistsflag { get; set; }
        public datetime string Recorddate { get; set; }
        public uniqueidentifier string Rowpointer { get; set; }
        public varchar(30) string Createdby { get; set; }
        public varchar(30) string Updatedby { get; set; }
        public datetime string Createdate { get; set; }
        public varchar(10) string Actividad_Comercial { get; set; }
        public decimal string Monto_Otro_Cargo { get; set; }
        public decimal string Monto_Total_Iva_Devuelto { get; set; }
        public varchar(50) string Ncf_Modificado { get; set; }*/



    }
}
