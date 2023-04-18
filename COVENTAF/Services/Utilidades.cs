using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace COVENTAF.Services
{
    public static class Utilidades
    {
        public static void UnPunto(KeyPressEventArgs e, String cadena, ref bool bandera)
        {
            int contador = 0;
            String caracter = "";
            for (int n = 0; n < cadena.Length; n++)
            {
                caracter = cadena.Substring(n, 1);
                if (caracter == ".")
                {
                    contador++;
                }
            }

            if (contador == 0)
            {
                bandera = true;
                if (e.KeyChar == '.' && bandera)
                {
                    bandera = false;
                    e.Handled = false;
                }
                else if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                bandera = false;
                e.Handled = true;
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public static string GetDefaultPrintName()
        {
            PrintDocument printDocument = new PrintDocument();
            var defaultPrinter = printDocument.PrinterSettings.PrinterName;

            return defaultPrinter;
        }

        public static decimal RoundApproximate(decimal valorDecimal, int decimales)
        {
            string valorString = valorDecimal.ToString($"N{decimales}");
            decimal nuevoValorDecimal = Convert.ToDecimal(valorString);
            return nuevoValorDecimal;
        }

        public static bool AutorizacionExitosa()
        {
            bool resultExitoso;
            //llamar la ventana de autorizacion
            using (var frmAutorizacion = new PuntoVenta.frmAutorizacion())
            {
                //mostrar la ventana de autorizacion
                frmAutorizacion.ShowDialog();
                resultExitoso=frmAutorizacion.resultExitoso;
            }

            //si el resultado 
            return resultExitoso;
        }
    }
}
