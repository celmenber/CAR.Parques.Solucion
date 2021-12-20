using CAR.Parques.Common.Entities.Entidades.Base;
using CAR.Parques.Common.Models.Modelos.Parametricos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR.Parques.UI.Proxy.Contracts.Parametricos
{
    public interface IMunicipioProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<MunicipioModel>>> ConsultarListadoMunicipiosXDepto(int departamentoId);
    }
}
