using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class Clientes
    {
        /*el siguiente procedimiento almacenado: [ERPADMIN].[TDA_TECHO_DESCUENTO] asigna el techo a cada empleado y militar dependiendo del rango*/
        public Clientes()
        {

        }

       
        [StringLength(20)]
        public string Cliente { get; set; }
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        public int? Detalle_Direccion { get; set; }

        [StringLength(150)]
        public string Alias { get; set; }

        [Required]
        [StringLength(30)]
        public string Contacto { get; set; }
        [Required]
        [StringLength(30)]
        public string Cargo { get; set; }
        [Column(TypeName = "text")]
        public string Direccion { get; set; }

        [StringLength(8)]
        public string Dir_Emb_Default { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Fax { get; set; }
        [Required]
        [StringLength(20)]
        public string Contribuyente { get; set; }
        [Required]
        public DateTime Fecha_Ingreso { get; set; }
        [Required]
        [StringLength(1)]
        public string Multimoneda { get; set; }
        [Required]
        [StringLength(4)]
        public string Moneda { get; set; }

        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public decimal Saldo_Local { get; set; }
        [Required]
        public decimal Saldo_Dolar { get; set; }
        [Required]
        public decimal Saldo_Credito { get; set; }
        public decimal? Saldo_NoCargos { get; set; }
        public decimal? Limite_Credito { get; set; }
        [Required]
        [StringLength(1)]
        public string Exceder_Limite { get; set; }
        [Required]
        public decimal Tasa_Interes { get; set; }
        [Required]
        public decimal Tasa_Interes_Mora { get; set; }
        [Required]
        public DateTime Fecha_Ult_Mora { get; set; }
        [Required]
        public DateTime Fecha_Ult_Mov { get; set; }
        [Required]
        [StringLength(4)]
        public string Condicion_Pago { get; set; }
        [Required]
        [StringLength(12)]
        public string Nivel_Precio { get; set; }
        [Required]
        public decimal Descuento { get; set; }
        [Required]
        [StringLength(1)]
        public string Moneda_Nivel { get; set; }
        [Required]
        [StringLength(1)]
        public string Acepta_Backorder { get; set; }
        [Required]
        [StringLength(4)]
        public string Pais { get; set; }
        [Required]
        [StringLength(4)]
        public string Zona { get; set; }
        [Required]
        [StringLength(4)]
        public string Ruta { get; set; }

        [StringLength(4)]
        public string Vendedor { get; set; }
        [Required]
        [StringLength(4)]
        public string Cobrador { get; set; }
        [Required]
        [StringLength(1)]
        public string Acepta_Fracciones { get; set; }
        [Required]
        [StringLength(1)]
        public string Activo { get; set; }
        [Required]
        [StringLength(1)]
        public string Exento_Impuestos { get; set; }
        [Required]
        public decimal Exencion_Imp1 { get; set; }
        [Required]
        public decimal Exencion_Imp2 { get; set; }
        [Required]  
        [StringLength(1)]
        public string Cobro_Judicial { get; set; }
        [Required]  
        [StringLength(8)]
        public string Categoria_Cliente { get; set; }
        [StringLength(1)]
        public string Clase_Abc { get; set; }

        [Required]        
        public short Dias_Abastecimien { get; set; }
        [Required]  
        [StringLength(1)]
        public string Usa_Tarjeta { get; set; }
        
        [StringLength(20)]
        public string Tarjeta_Credito { get; set; }
        [StringLength(12)]
        public string Tipo_Tarjeta { get; set; }
        public DateTime? Fecha_Vence_Tarj { get; set; }
        [StringLength(249)]
        public string E_Mail { get; set; }
        [Required]  
        [StringLength(1)]
        public string Requiere_Oc { get; set; }

        [Required]
        [StringLength(1)]
        public string Es_Corporacion {get; set; }

        [StringLength(20)]
        public string Cli_Corporac_Asoc {get; set; }

        [Required]
        [StringLength(1)]
        public string RegistrarDocSacorp {get; set; }

        [Required]
        [StringLength(1)]
        public string Usar_Diremb_Corp {get; set; }

        [Required]
        [StringLength(1)]
        public string Aplicac_Abiertas {get; set; }

        [Required]
        [StringLength(1)]
        public string Verif_Limcred_Corp {get; set; }

        [Required]
        [StringLength(1)]
        public string Usar_Desc_Corp {get; set; }

        [Required]
        [StringLength(1)]
        public string Doc_A_Generar {get; set; }

        [StringLength(40)]
        public string Rubro1_Cliente {get; set; }
        
        [StringLength(40)]
        public string Rubro2_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro3_Cliente {get; set; }

        [Required]
        [StringLength(1)]
        public string Tiene_Convenio {get; set; }

        [Column(TypeName = "Text")]
        public string Notas { get; set; }

        [Required] 
        public short Dias_Promed_Atraso { get; set; }

        [StringLength(50)]
        public string Rubro1_Cli {get; set; }

        [StringLength(50)]
        public string Rubro2_Cli {get; set; }

        [StringLength(50)]
        public string Rubro3_Cli {get; set; }

        [StringLength(50)]
        public string Rubro4_Cli {get; set; }

        [StringLength(50)]
        public string Rubro5_Cli {get; set; }

        [Required]
        [StringLength(1)]
        public string Asocobligcontfact { get; set; }

        [StringLength(40)]
        public string Rubro4_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro5_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro6_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro7_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro8_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro9_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro10_Cliente {get; set; }

        [Required]
        [StringLength(1)]
        public string Usar_Precios_Corp {get; set; }
        
        [Required]
        [StringLength(1)]
        public string Usar_Exencimp_Corp {get; set; }

        [StringLength(13)]
        public string Dias_De_Cobro {get; set; }

        [Required]
        [StringLength(1)]
        public string Ajuste_Fecha_Cobro {get; set; }

        [StringLength(13)]
        public string Gln {get; set; }

        [StringLength(249)]
        public string Ubicacion {get; set; }

        [Required]
        [StringLength(1)]
        public string Clase_Documento {get; set; }

        [Required]
        [StringLength(1)]
        public string Local {get; set; }

        [StringLength(1)]
        public string Tipo_Contribuyente {get; set; }

        [StringLength(40)]
        public string Rubro11_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro12_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro13_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro14_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro15_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro16_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro17_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro18_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro19_Cliente {get; set; }

        [StringLength(40)]
        public string Rubro20_Cliente {get; set; }

        [StringLength(4)]
        public string Modelo_Retencion {get; set; }

        [Required]
        [StringLength(1)]
        public string Acepta_Doc_Electronico {get; set; }

        [Required]
        [StringLength(1)]
        public string Confirma_Doc_Electronico {get; set; }

        [StringLength(249)]
        public string Email_Doc_Electronico {get; set; }

        [StringLength(249)]
        public string Email_Ped_Edi {get; set; }

        [Required]
        [StringLength(1)]
        public string Acepta_Doc_Edi {get; set; }

        [Required]
        [StringLength(1)]
        public string Notificar_Error_Edi {get; set; }

        [StringLength(249)]
        public string Email_Error_Ped_Edi {get; set; }
            
              
        [StringLength(4)]
        public string Codigo_Impuesto { get; set; }

        
        [StringLength(12)]
        public string Division_Geografica1 {get; set; }

        [StringLength(12)]
        public string Division_Geografica2 {get; set; }

        [StringLength(12)]
        public string Regimen_Trib {get; set; }

        [Required]
        [StringLength(1)]
        public string Moroso {get; set; }

        [Required]
        [StringLength(1)]
        public string Modif_Nomb_En_Fac {get; set; }

        [Required] 
        public decimal Saldo_Trans { get; set; }

        [Required] 
        public decimal Saldo_Trans_Local { get; set; }

        [Required] 
        public decimal Saldo_Trans_Dolar { get; set; }

        [Required]
        [StringLength(1)]
        public string Permite_Doc_Gp {get; set; }

        [Required]
        [StringLength(1)]
        public string Participa_Flujocaja {get; set; }

        [StringLength(18)]
        public string Curp {get; set; }

        [StringLength(25)]
        public string Usuario_Creacion {get; set; }

        public DateTime? Fecha_Hora_Creacion { get; set; }

        [StringLength(25)]
        public string Usuario_Ult_Mod {get; set; }

        public DateTime? Fch_Hora_Ult_Mod { get; set; }

        [StringLength(249)]
        public string Email_Doc_Electronico_Copia {get; set; }

        [Required]
        [StringLength(1)]
        public string Detallar_Kits {get; set; }

        [StringLength(20)]
        public string Xslt_Personalizado {get; set; }

        [StringLength(20)]
        public string Nombre_Addenda {get; set; }

        public decimal? Geo_Latitud {get; set; }

        public decimal? Geo_Longitud {get; set; }

        [StringLength(12)]
        public string Division_Geografica3 {get; set; }

        [StringLength(12)]
        public string Division_Geografica4 {get; set; }

        [StringLength(160)]
        public string Otras_Senas {get; set; }

        [StringLength(25)]
        public string Subtipodoc {get; set; }
     
        [StringLength(254)]
        public string Api_Recepcion_De {get; set; }

        [StringLength(1)]
        public string Usa_Api_Recepcion {get; set; }

        [StringLength(254)]
        public string User_Api_Recepcion {get; set; }

        [StringLength(254)]
        public string Pass_Api_Recepcion {get; set; }

        [Required] 
        public byte NoteExistsFlag { get; set; }

        [Required] 
        public DateTime RecordDate { get; set; }

        [Required] 
        public Guid RowPointer { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatedBy {get; set; }

        [Required]
        [StringLength(30)]
        public string UpdatedBy {get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [StringLength(1)]
        public string U_Sexo {get; set; }

        public DateTime? U_Fecha_Nac { get; set; }

        public int? U_Nentradas { get; set; }

        public DateTime? U_Ultent { get; set; }

        [StringLength(20)]
        public string U_Identidad {get; set; }

        [StringLength(300)]
        public string U_Compania {get; set; }

        [StringLength(20)]
        public string U_Procedencia {get; set; }

        [StringLength(50)]
        public string U_Parentesco {get; set; }

        [StringLength(300)]
        public string U_Autoriza {get; set; }

        [StringLength(20)]
        public string U_Unidad_Militar {get; set; }

        [StringLength(20)]
        public string U_Numero_Unico {get; set; }

        [StringLength(20)]
        public string U_Codigo_Vam {get; set; }

        public DateTime? U_Ultima_Carta { get; set; }

        public DateTime? U_Fecha_Venc_Contrato { get; set; }

        public DateTime? U_Proceso { get; set; }

        [StringLength(300)]
        public string U_Estadocivil {get; set; }

        [StringLength(50)]
        public string U_Telefono1 {get; set; }

        [StringLength(50)]
        public string U_Telefono2 {get; set; }

        public int? U_Dependientes { get; set; }

        public DateTime? U_Vigencia { get; set; }

        [StringLength(4)]
        public string Tipo_Impuesto {get; set; }

        [StringLength(2)]
        public string Tipo_Tarifa {get; set; }

        public decimal? Porc_Tarifa { get; set; }

        [StringLength(2)]
        public string Tipificacion_Cliente {get; set; }

        [StringLength(2)]
        public string Afectacion_Iva {get; set; }

        [Required]
        [StringLength(1)]
        public string Es_Extranjero {get; set; }

        [StringLength(4)]
        public string Item_Hacienda {get; set; }

        [StringLength(20)]
        public string Xslt_Personalizado_Credito {get; set; }

        [StringLength(10)]
        public string Tipo_Generar {get; set; }

        [StringLength(10)]
        public string Tipo_Personeria {get; set; }

        [StringLength(3)]
        public string Uso_Cfdi {get; set; }

        [StringLength(10)]
        public string Metodo_Pago {get; set; }

        [StringLength(240)]
        public string Banco_Nacion {get; set; }
       
        [Required]
        [StringLength(1)]
        public string Es_Agente_Percepcion { get; set; }

        [Required]
        [StringLength(1)]
        public string Es_Buen_Contribuyente { get; set; }

        public decimal? U_Saldo_Feria { get; set; }

        public decimal? U_Credito_Feria { get; set; }

        [StringLength(1)]
        public string U_EsMilitar { get; set; }

        [StringLength(1)]
        public string U_EsEmpleado { get; set; }

        /*este es el monto q se le asigna a inicio de cada mes */
        public decimal? U_MontoInicial { get; set; }

        /*saldo disponible del descuento del cliente */
        public decimal? U_U_SaldoDisponible { get; set; }
        /*PorCentajeDescuento */
        public decimal? U_U_Descuento { get; set; }

        /*este es el 2do credito para super para los militares quincenal llamado a corto plazo*/
        /*este es el campo para identificar que tiene credito aprobado*/
        public decimal? U_U_Credito2 { get; set; }
        /*U_U_Credito2Disponible aquie muestra el mnontro del 2do credito disponible */
        public decimal? U_U_Credito2Disponible { get; set; }
    }
}
