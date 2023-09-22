using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Api.Helpers
{
    public static class Utilidades
    {
        public static Guid GenerarGuid()
        {
            Guid miGUID = Guid.NewGuid();
            //String sGUID = miGUID.ToString();
            return miGUID;
        }

        public static string ConvertirEnCadenatring(object obj, string nombreObjeto, string campo)
        {
            string nuevaCadena = "";

            if (nombreObjeto == "FuncionesRoles")
            {
                List<FuncionesRoles> funcionesRoles = (List<FuncionesRoles>)obj;
                foreach (var item in funcionesRoles)
                {
                    if (campo == "RolID")
                    {
                        nuevaCadena = nuevaCadena + item.RolID.ToString() + "*";
                    }
                    else if (campo == "FuncionID")
                    {
                        nuevaCadena = nuevaCadena + item.FuncionID.ToString() + "*";
                    }
                }
            }
            else if (nombreObjeto == "RolesUsuarios")
            {
                List<RolesUsuarios> rolesUsuario = (List<RolesUsuarios>)obj;
                foreach (var item in rolesUsuario)
                {

                    nuevaCadena = nuevaCadena + item.RolID.ToString() + "*";

                }
            }

            //si la cadena no esta vacia entonces quita el ultimo caracter (*) para enviarlo al servidor de sql server.
            if (nuevaCadena.Length > 0) nuevaCadena = nuevaCadena.Substring(0, nuevaCadena.Length - 1);

            return nuevaCadena;
        }


        //public override bool Equals(object obj)
        //{
        //    if (obj is Persona)
        //    {
        //        Persona otro = (Persona)obj;
        //        return otro.Edad == Edad &&
        //               otro.Nombre == Nombre;
        //    }
        //    return false;


        public static string ConvertirEnCadenatring2(List<FuncionesRoles> funcionesRoles, string Campo)
        {

            var cadena = "";
            foreach (var item in funcionesRoles)
            {
                if (Campo == "RolID")
                {
                    cadena = cadena + item.RolID.ToString() + "*";
                }
                else if (Campo == "FuncionID")
                {
                    cadena = cadena + item.FuncionID.ToString() + "*";
                }

            }

            //si la cadena no esta vacia entonces quita el ultimo caracter (*) para enviarlo al servidor de sql server.
            if (cadena.Length > 0) cadena = cadena.Substring(0, cadena.Length - 1);
            return cadena;
        }

        /// <summary>
        /// Método que devuelve el Domingo de Pascua dado un año a consultar.
        /// </summary>
        /// <param name="anyo">Año a consultar.</param>
        /// <returns>Día del año que es Domingo de Pascua.</returns> 
        private static DateTime GetFechaPascua(int anyo)
        {
            int M = 25;
            int N = 5;

            if (anyo >= 1583 && anyo <= 1699) { M = 22; N = 2; }
            else if (anyo >= 1700 && anyo <= 1799) { M = 23; N = 3; }
            else if (anyo >= 1800 && anyo <= 1899) { M = 23; N = 4; }
            else if (anyo >= 1900 && anyo <= 2099) { M = 24; N = 5; }
            else if (anyo >= 2100 && anyo <= 2199) { M = 24; N = 6; }
            else if (anyo >= 2200 && anyo <= 2299) { M = 25; N = 0; }

            int a, b, c, d, e, dia, mes;

            //Cálculo de residuos
            a = anyo % 19;
            b = anyo % 4;
            c = anyo % 7;
            d = (19 * a + M) % 30;
            e = (2 * b + 4 * c + 6 * d + N) % 7;

            // Decidir entre los 2 casos:
            if (d + e < 10) { dia = d + e + 22; mes = 3; }
            else { dia = d + e - 9; mes = 4; }

            // Excepciones especiales
            if (dia == 26 && mes == 4) dia = 19;
            if (dia == 25 && mes == 4 && d == 28 && e == 6 && a > 10) dia = 18;

            return new DateTime(anyo, mes, dia);
        }

        public static bool FechaEsSemanaSanta(DateTime fecha)
        {
            bool esSemanaSanta = false;

            DateTime domingoSanto = GetFechaPascua(fecha.Year);
            DateTime juevesSanto = domingoSanto.AddDays(-3);
            DateTime viernesSanto = domingoSanto.AddDays(-2);
            DateTime sabadoSanto = domingoSanto.AddDays(-1);

            if (fecha.Date == juevesSanto)
            {
                esSemanaSanta = true;
            }
            else if (fecha.Date == viernesSanto)
            {
                esSemanaSanta = true;
            }
            else if (fecha.Date == sabadoSanto)
            {
                esSemanaSanta = true;
            }

            return esSemanaSanta;
        }

        public static decimal RoundApproximate(decimal valorDecimal, int decimales)
        {
            string valorString = valorDecimal.ToString($"N{decimales}");
            decimal nuevoValorDecimal = Convert.ToDecimal(valorString);
            return nuevoValorDecimal;
        }

        public static bool NumeroDecimalCorrecto(KeyPressEventArgs e, string cadena, int textoSeleccionado)
        {
            bool isValido = false;
            int sumarPuntoDecimal = 0;
            bool puntoDecimalLocalizd = false;
            int cantidadDecimales = 0;

            //si el texto esta seleccionado y la tecla presionada es un digito entonces caracter aceptado
            if (textoSeleccionado > 0 && (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Back)) return true;
            //si el texto está seleccionado y la tecla presionada no es un digito, entonces denegar el caracter
            if (textoSeleccionado > 0 && !char.IsDigit(e.KeyChar)) return false;

            foreach (var newCaracter in cadena)
            {
                //verificar si ya se localizo el punto decimal en la cadena
                if (puntoDecimalLocalizd)
                {
                    cantidadDecimales += 1;
                }
                //contar cuantos punto decimal tiene la cadena
                else if (newCaracter == '.')
                {
                    puntoDecimalLocalizd = true;
                    sumarPuntoDecimal += 1;
                }
                else if (newCaracter == ',')
                {
                    continue;
                }
                else if (!char.IsDigit(newCaracter))
                {
                    isValido = false;
                    break;
                }

            }

            //verificar si es un punto decimal
            if (e.KeyChar == '.')
            {
                sumarPuntoDecimal += 1;
            }
            //verificar si es un espacio
            else if (e.KeyChar == ' ')
            {
                return false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                isValido = true;
            }
            else if (!char.IsDigit(e.KeyChar))
            {
                return false;
            }
            //verificar si ya localizo el punto decimal
            else if (puntoDecimalLocalizd)
            {
                cantidadDecimales += 1;
            }
            //de lo contrario significa que todo esta bien
            else
            {
                isValido = true;
            }

            //verificar la cantidad de punto decimal que tiene la cadena
            if (sumarPuntoDecimal > 1)
            {
                isValido = false;
            }
            else if (cantidadDecimales > 2)
            {
                isValido = false;
            }
            else
            {
                isValido = true;
            }



            return isValido;
        }

        public static bool DigitOrLetter(KeyPressEventArgs e)
        {
            bool result = false;
            //ctrl + v =22.  ctrl + c =3     ctrl+x= 24
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Back || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24)
            {
                result = true;
            }
            //verificar el caracter sea una letra o un digito
            else if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                result = true;
            }

            return result;
        }

        public static void tmTransition_Tick(ref string Transition, Timer tmTransition, Form miForm)
        {
            if (Transition == "FadeOut")
            {
                if (miForm.Opacity == 0)
                {
                    tmTransition.Stop();
                    miForm.Close();
                }
                else
                {
                    miForm.Opacity = miForm.Opacity - 0.15;
                    miForm.Top = miForm.Top + 3;
                }
            }
            else if (Transition == "FadeIn")
            {
                if (miForm.Opacity == 1)
                {
                    Transition = "FadeOut";
                    tmTransition.Stop();
                }
                else
                {
                    miForm.Opacity = miForm.Opacity + 0.15;
                    miForm.Top = miForm.Top - 3;
                }
            }
        }

        public static DateTime ObtenerFechaHaceXDias(byte dias)
        {
            //obtengo la fecha de hoy
            DateTime fechaInicial = DateTime.Now;
            //restar menos 30 dias
            fechaInicial = fechaInicial.AddDays(-dias);

            return fechaInicial;

        }

        public static bool DigitoDecimal(KeyPressEventArgs e, string cadena, int textoSeleccionado)
        {
            bool isValido = false;
            int sumarPuntoDecimal = 0;
            bool puntoDecimalLocalizd = false;
            int cantidadDecimales = 0;


            //si el texto esta seleccionado y la tecla presionada es un digito entonces caracter aceptado
            if (textoSeleccionado > 0 && (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Back)) return true;
            //si el texto está seleccionado y la tecla presionada no es un digito, entonces denegar el caracter
            if (textoSeleccionado > 0 && !char.IsDigit(e.KeyChar)) return false;

            foreach (var newCaracter in cadena)
            {
                //verificar si ya se localizo el punto decimal en la cadena
                if (puntoDecimalLocalizd)
                {
                    cantidadDecimales += 1;
                }
                //contar cuantos punto decimal tiene la cadena
                else if (newCaracter == '.')
                {
                    puntoDecimalLocalizd = true;
                    sumarPuntoDecimal += 1;
                }
                else if (newCaracter == ',')
                {
                    continue;
                }
                else if (!char.IsDigit(newCaracter))
                {
                    isValido = false;
                    break;
                }
            }

            //verificar si es un punto decimal
            if (e.KeyChar == '.')
            {
                sumarPuntoDecimal += 1;
            }
            //verificar si es un espacio
            else if (e.KeyChar == ' ')
            {
                return false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                isValido = true;
            }
            else if (!char.IsDigit(e.KeyChar))
            {
                return false;
            }
            //verificar si ya localizo el punto decimal
            else if (puntoDecimalLocalizd)
            {
                cantidadDecimales += 1;
            }
            //de lo contrario significa que todo esta bien
            else
            {
                isValido = true;
            }

            //verificar la cantidad de punto decimal que tiene la cadena
            if (sumarPuntoDecimal > 1)
            {
                isValido = false;
            }
            else if (cantidadDecimales > 2)
            {
                isValido = false;
            }
            else
            {
                isValido = true;
            }


            return isValido;
        }

        public static bool TieneLetra(string valor)
        {
            bool caracterLetra = false;
            foreach (var caracter in valor)
            {
                if (char.IsLetter(caracter))
                {
                    caracterLetra = true;
                    break;
                }
            }

            return caracterLetra;
        }

        public static bool CantidadIsValido(string cantidad, bool IsPermitodFraccion, ref string Mensaje)
        {
            bool isValido = false;
            //comprobar que el primer caracter es un digito
            if (char.IsDigit(cantidad[0]))
            {
                int contadorPuntoDecimal = 0;
                bool caracterInvalido = false;
                bool puntoDecimalIdentificado = false;
                //bool tieneCeroDespuesDecimal = false;
                bool tieneNumDespuesDecimal = false;

                foreach (var caracter in cantidad)
                {
                    //verificar si es un punto decimal
                    if (caracter == '.')
                    {
                        contadorPuntoDecimal += 1;
                        puntoDecimalIdentificado = true;
                        continue;
                    }
                    //comprobar si no es un digito
                    else if (!(char.IsDigit(caracter)))
                    {
                        //aqui identifica q se encontro un caracter invalido. (am-+%)
                        caracterInvalido = true;
                        //detener el ciclo
                        break;
                    }

                    //una vez identificado el punto decimal el sistema verifica q los siguientes caracteres sean digitos para la parte decimal
                    if (puntoDecimalIdentificado)
                    {

                        //comprobar si es un cero
                        if (caracter == '0')
                        {
                            continue;
                        }
                        else
                        {
                            tieneNumDespuesDecimal = true;
                        }
                    }
                }

                //identificar si encontro mas de 2 punto decimales(ej.. 2.5.6)
                if (contadorPuntoDecimal >= 2)
                {
                    Mensaje = "La cantidad digitada tiena mas de un punto decimal";
                }
                //comprobar si tiene caracter invalido
                else if (caracterInvalido)
                {
                    Mensaje = "La cantidad digitada tiene caracter invalido";
                }
                else if (tieneNumDespuesDecimal && !IsPermitodFraccion)
                {
                    Mensaje = "La unidad de medida para este articulo no permite cantidades con decimales";
                }
                else
                {
                    isValido = true;
                }
            }
            else
            {
                Mensaje = "La cantidad tiene caracteres inválidos";
            }

            return isValido;
        }

        public static string AgregarCeroIzquierda(string valor , int cantidad)
        {
            string nuevoValor = "";

            if (valor.Length == cantidad)
            {
                nuevoValor = valor;
            }
            else if (valor.Length < cantidad)
            {
                
                for (int index=0; index < valor.Length; ++ index)
                {
                    nuevoValor = "0" + valor[index];
                    if (nuevoValor.Length == cantidad) break;                   
                }
               
            }


            return nuevoValor;
        }

    }
}

