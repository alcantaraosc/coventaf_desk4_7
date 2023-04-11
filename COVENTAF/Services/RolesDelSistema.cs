using Api.Model.ViewModels;
using System.Collections.Generic;

namespace COVENTAF.Services
{
    public class RolesDelSistema
    {
        private readonly ResponseModel _rolesUsuarioActual;

        public RolesDelSistema(ResponseModel rolesUsuarioActual)
        {
            this._rolesUsuarioActual = rolesUsuarioActual;

        }

        /// <summary>
        /// verificar si el sistema de tiene acceso al 
        /// </summary>
        /// <param name="roleDisponible"></param>
        /// <returns></returns>
        public bool TieneAccesoSistema(List<string> roleDisponible)
        {
            var accesoHabilitado = false;
            var rolesUsuario = _rolesUsuarioActual.DataAux as List<RolesUsuarioActual>;

            foreach (var item in rolesUsuario)
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

