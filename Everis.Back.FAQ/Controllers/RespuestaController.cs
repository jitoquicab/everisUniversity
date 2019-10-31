using Everis.back.FAQ.core.kiwi.bussines;
using Everis.back.FAQ.core.models.EntityModel;
using Everis.back.FAQ.core.models.Enum;
using Everis.back.FAQ.core.models.Peticiones.v1.Base;
using Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Request;
using Everis.back.FAQ.core.rabbit.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Everis.Back.FAQ.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RespuestaController: ControllerBase
    {
        private readonly BORespuestas _BORespuestas;
        private readonly IConfiguration _configuration;

        public RespuestaController(FAQContext context, IConfiguration configuration)
        {
            var dataBase = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration;
            _BORespuestas = new BORespuestas(dataBase);
        }


        #region Respuestas
        /// <summary>
        /// Consulta una respuesta especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("respuestas/{id}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<Respuestas>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> getRespuesta(long id)
        {
            var resp = await _BORespuestas.GetAsync(id);
            return StatusCode( resp.codigo,resp);
        }

        /// <summary>
        /// Consulta todas las respuestas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("respuestas")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<List<Respuestas>>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerRespuestas()
        {
            var resp = await _BORespuestas.GetTodoAsync();
            return StatusCode(resp.codigo, resp);
        }

        /// <summary>
        /// Crear una pregunta
        /// </summary>
        /// <param name="faq"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<RequestRespuesta>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> crearRespuesta([FromBody]  RequestRespuesta faq)
        {
            var resp = await _BORespuestas.save(faq, Transaction.Insert);
            return StatusCode(resp.codigo, resp);
        }

        /// <summary>
        /// Actualiza los datos de una respuesta
        /// </summary>
        /// <param name="faq"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<RequestRespuesta>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> actualizarRespuesta([FromBody]  RequestRespuesta faq)
        {
            var resp = await _BORespuestas.save(faq, Transaction.Update);
            return StatusCode(resp.codigo, resp);
        }
        #endregion
    }
}
