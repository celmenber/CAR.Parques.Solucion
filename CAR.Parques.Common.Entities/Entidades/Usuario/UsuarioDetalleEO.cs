using System.Collections.Generic;

namespace CAR.Parques.Common.Entities.Entidades.Usuario
{
    public class UsuarioDetalleEO : UsuarioEO
    {
        public string NombrePerfil { get; set; }
        public string TipoUsuario { get; set; }
        public IEnumerable<MenuEO> Menu { get; set; }
    }
}
