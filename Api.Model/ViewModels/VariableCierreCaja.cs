namespace Api.Model.ViewModels
{
    public class VariableCierreCaja
    {

        //TotalCordoba =TOTAL_LOCAL= [es la suma de todo lo q se recibió solo en cordoba incluyendo efectivo, tarjeta, cheque, creditos]
        public decimal TotalCordoba { get; set; } = 0.00M;
        //--TotalDolar=TOTAL_DOLAR=[es la suma de todo el dinero q se recibió en dolares incluyendo efectivo, tarjeta cheque, pero que solo sea dólar      
        public decimal TotalDolar { get; set; } = 0.00M;        
        //--VentaEfectivoCordoba=VENTAS_EFECTIVO= [es la suma  solo en efectivo en cordoba y nada mas]
        public decimal VentaEfectivoCordoba { get; set; } = 0.00M;
        //--VentaEfectivoDolar=COBRO_EFECTIVO_REP= [es la suma  solo en efectivo en dolares y nada mas]
        public decimal VentaEfectivoDolar { get; set; } = 0.00M;
        public decimal TotalDiferencia { get; set; } = 0.00M;


        /*esto propiedades son para la impresion de Prelectura*/
        public decimal EfectivoCordoba { get; set; } = 0.00M;
        public decimal EfectivoDolar { get; set; } = 0.00M;
        public decimal MontoApertura { get; set; } = 0.00M;
        public decimal VentasEfectivo { get; set; } = 0.00M;



        /*
        public decimal TotalCajaCordoba { get; set; } = 0;
        public decimal TotalCajaDolares { get; set; } = 0;

        public decimal SumaDenomCordoba { get; set; } = 0;
        public decimal SumaDenomDolar { get; set; } = 0;*/
    }
}
