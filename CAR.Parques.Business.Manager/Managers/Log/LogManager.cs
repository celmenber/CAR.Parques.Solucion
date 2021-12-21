namespace CAR.Parques.Business.Manager.Managers.Log
{
    using Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Log;
    using Common.Entities.Entidades.Bitacora;
    using System.ComponentModel.Composition;

    [Export(typeof(ILogManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LogManager : ILogManager
    {
        private readonly ITransaccionLogQO iTransaccionLogRepository;

        [ImportingConstructor]
        public LogManager(ITransaccionLogQO transaccionLogRepository)
        {
            this.iTransaccionLogRepository = transaccionLogRepository;
        }

        public ResultadoEjecucion<bool> RegistrarLog(LogTransaccion log)
        {
            return this.iTransaccionLogRepository.Insertar(log);
        }
    }
}
