using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Everis.back.FAQ.core.kiwi.bussines;
using Everis.back.FAQ.core.models.EntityModel;
using Everis.back.FAQ.core.models.Enum;
using Everis.back.FAQ.core.models.Peticiones.v1.Base;
using Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Request;
using Everis.back.FAQ.core.rabbit.Context;

namespace Everis.Back.FAQ.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FAQsController : ControllerBase
    {
        private readonly BOFAQs _BOFaq;
        private readonly IConfiguration _configuration;

        public FAQsController(FAQContext context, IConfiguration configuration)
        {
            var dataBase = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration;
            _BOFaq = new BOFAQs(dataBase);
            
        }

        #region Preguntas
        /// <summary>
        /// Consulta una pregunta especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FAQ/{id}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<FAQs>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> get(long id)
        {
            var resp = await _BOFaq.GetAsync(id);
            return StatusCode(resp.codigo, resp);
        }

        /// <summary>
        /// Consulta todas las preguntas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("FAQ")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<List<FAQs>>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Obtenerpreguntas()
        {
            var resp = await _BOFaq.GetTodoAsync();
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
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<FAQs>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> crear([FromBody]  RequestFAQs faq)
        {
            var resp = await _BOFaq.save(faq, Transaction.Insert);
            return StatusCode(resp.codigo, resp);
        }

        /// <summary>
        /// Actualiza los datos de una pregunta
        /// </summary>
        /// <param name="faq"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<ResponseBase<FAQs>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> actualizar([FromBody]  RequestFAQs faq)
        {
            var resp = await _BOFaq.save(faq, Transaction.Update);
            return StatusCode(resp.codigo, resp);
        }
        #endregion

       
    }
}