namespace CAR.Parques.Business.Contract.ManagerContracts.Parametricos
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using System.Collections.Generic;

    public interface IMunicipioManager : IBaseAccionManager<MunicipioEO>
    {
        ResultadoEjecucion<IEnumerable<MunicipioEO>> ConsultarMunicipiosXDepartamento(int departamentoId);
    }
}
