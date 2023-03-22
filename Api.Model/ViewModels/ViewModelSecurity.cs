using Api.Model.Modelos;
using System.Collections.Generic;

namespace Api.Model.ViewModels
{
    public class ViewModelSecurity
    {
        public Funciones Funciones { get; set; } = null;

        public Roles Roles { get; set; } = null;

        public List<FuncionesRoles> FuncionesRoles { get; set; }

        public Usuarios Usuarios { get; set; } = null;

        public List<RolesUsuarios> RolesUsuarios { get; set; }
    }
}
