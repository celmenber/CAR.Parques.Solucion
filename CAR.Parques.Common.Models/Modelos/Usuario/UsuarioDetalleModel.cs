using System.Collections.Generic;

namespace CAR.Parques.Common.Models.Modelos.Usuario
{
    public class UsuarioDetalleModel : UsuarioModel
    {
        public string NombrePerfil { get; set; }

        public string TipoUsuario { get; set; }

        public IEnumerable<MenuModel> Menu { get; set; }
    }
}
