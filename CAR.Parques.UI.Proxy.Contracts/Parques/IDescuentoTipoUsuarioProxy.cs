namespace CAR.Parques.UI.Proxy.Contracts.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using System.Collections.Generic;

    public interface IDescuentoTipoUsuarioProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<DescuentoTipoUsuarioModel>> ConsultarDescuentoTipoUsuario(int descuentoId);

        ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarDescuentoTipoUsuario(DescuentoTipoUsuarioModel descuentoTipoUsuario);

        ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarDescuentoTipoUsuario(int descuentoId);

        ResultadoEjecucion<ResultadoEjecucion<int>> CrearDescuentoTipoUsuario(DescuentoTipoUsuarioModel descuentoTipoUsuario);
    }
}
