﻿using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace COVENTAF.Metodos
{
    public static class Utilidades
    {
        static List<RolesUsuarioActual> _rolesUsuarioActual = new List<RolesUsuarioActual>();

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
                resultExitoso = frmAutorizacion.resultExitoso;
            }

            //si el resultado 
            return resultExitoso;
        }

        public static bool ValidacionDescuentoExitoso(decimal descuento)
        {
            if (!(descuento >= 0 && descuento < 100))
            {
                MessageBox.Show("Debes indicar un valor para el Pocentaje de descuento mayor a cero y menor a 100", "Sistema COVENTAF");
                return false;
            }
            else
            {
                return true;
            }
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

        public static void GuardarMemoriaRolesDelUsuario(List<RolesUsuarioActual> rolesUsuarioActual)
        {            
            foreach(var item in rolesUsuarioActual)
            {
                _rolesUsuarioActual.Add( new RolesUsuarioActual { RolID = item.RolID, NombreRol = item.NombreRol });
            }          
            
        }

        public static bool  AccesoPermitido(List<string> roleDisponible)
        {
            var accesoHabilitado = false;
            //var rolesUsuario = _rolesUsuarioActual.DataAux as List<RolesUsuarioActual>;

            foreach (var item in _rolesUsuarioActual)
            {
                //asignar el nombre del rol del usuario actual
                var rolId = item.RolID;

                //verificar de roles disponible
                foreach (var valorRol in roleDisponible)
                {
                    if (rolId == valorRol)
                    {
                        accesoHabilitado = true;
                        break;
                    }
                }

                if (accesoHabilitado) break;
            }

            return accesoHabilitado;
        }

    }
}