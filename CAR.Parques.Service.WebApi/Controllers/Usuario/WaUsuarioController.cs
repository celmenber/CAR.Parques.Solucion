namespace CAR.Parques.Service.WebApi.Controllers.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.Usuario;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using CAR.Parques.Service.WebApi.Adaptadores;
    using CAR.Parques.Service.WebApi.Core;
    using CAR.Parques.Service.WebApi.Core.ContratoBase;
    using CAR.Parques.Service.WebApi.Filters;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/WaUsuario")]
    public class WaUsuarioController : ApiControllerBase, IApiAccionDTControllerBase<UsuarioModel>
    {
        private readonly IUsuarioManager _usuarioRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _usuarioRepository;
            }
        }

        [ImportingConstructor]
        public WaUsuarioController(IUsuarioManager usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(UsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<UsuarioModel, UsuarioEO>(entidad);
                var resultado = this._usuarioRepository.Actualizar(usuario);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("Consultar/{id:int}")]
        public HttpResponseMessage Consultar(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._usuarioRepository.Consultar(id);
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<UsuarioEO, UsuarioModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<UsuarioModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = usuario
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public HttpResponseMessage ConsultarTodos()
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._usuarioRepository.ConsultarTodos();
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<UsuarioEO>, IEnumerable<UsuarioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<UsuarioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = usuario
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarTodosDetalles")]
        public HttpResponseMessage ConsultarTodosDetalles()
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._usuarioRepository.ConsultarUsariosDetalle();
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<UsuarioDetalleEO>, IEnumerable<UsuarioDetalleModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<UsuarioDetalleModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = usuario
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(UsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<UsuarioModel, UsuarioEO>(entidad);
                var resultado = this._usuarioRepository.Crear(usuario);
                var resultadoEjecucion = new ResultadoEjecucionModel<int>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("OlvidoContrasenia")]
        public HttpResponseMessage OlvidoContrasenia(UsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<UsuarioModel, UsuarioEO>(entidad);
                var resultado = this._usuarioRepository.OlvidoContrasenia(usuario);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }
    
        [HttpPost]
        [Route("Restablecer")]
        public HttpResponseMessage Restablecer(RestablecerModel restablecer)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._usuarioRepository.RestablecerContrasenia(restablecer.Contrasenia, restablecer.Token);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Eliminar(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._usuarioRepository.Eliminar(id);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("VerificarUsuario")]
        public HttpResponseMessage VerificarUsuario(UsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._usuarioRepository.VerificarUsuario(entidad.Email, entidad.PasswordUsuario);
                var usuario = ConfiguracionApiMappers.GetInstance.
                To<UsuarioDetalleEO, UsuarioDetalleModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<UsuarioDetalleModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = usuario
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }
    }
}
