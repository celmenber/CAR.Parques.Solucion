using CAR.Parques.Common.Entities.Entidades.Base;
using CAR.Parques.Common.Models.Modelos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR.Parques.UI.Proxy.Contracts.Usuario
{
    public interface IPerfilProxy : IBaseProxy
    {
        ResultadoEjecucion<IEnumerable<PerfilModel>> ConsultarListadoPerfiles();

        ResultadoEjecucion<PerfilModel> ConsultarPerfilId(int perfilId);
    }
}
