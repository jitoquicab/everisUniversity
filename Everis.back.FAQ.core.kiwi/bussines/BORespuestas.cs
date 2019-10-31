using Everis.back.FAQ.core.models.EntityModel;
using Everis.back.FAQ.core.models.Enum;
using Everis.back.FAQ.core.models.Peticiones.v1.Base;
using Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Request;
using Everis.back.FAQ.core.rabbit.Context;
using Everis.back.FAQ.core.rabbit.DALC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Everis.back.FAQ.core.kiwi.bussines
{
    public class BORespuestas
    {
        public Dictionary<string, string> _endPointsDictinoDictionary { get; set; }

        private readonly FAQContext _context;

        private readonly DALCRespuestas<Respuestas> _dalc;

        public BORespuestas(FAQContext context)
        {
            _context = context;
            _dalc = new DALCRespuestas<Respuestas>(_context);
        }

        public async Task<ResponseBase<Respuestas>> GetAsync(long id)
        {
            try
            {
                var menus = await _dalc.get(id);

                if (menus != null)
                {
                    return new ResponseBase<Respuestas>()
                    {
                        codigo = (int)HttpStatusCode.OK,
                        estado = true,
                        mensaje = string.Empty,
                        datos = menus
                    };
                }
                else
                {
                    return new ResponseBase<Respuestas>()
                    {
                        codigo = (int)HttpStatusCode.NotFound,
                        estado = true,
                        mensaje = "La respuesta consultada no esta disponible.",
                        datos = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<Respuestas>()
                {
                    codigo = (int)HttpStatusCode.InternalServerError,
                    estado = false,
                    mensaje = $"Error: {ex.Message}",
                    datos = null
                };
            }
        }

        public async Task<ResponseBase<List<Respuestas>>> GetTodoAsync()
        {
            try
            {
                var menúss = await _dalc.getTodas();

                if (menúss != null)
                {
                    if (menúss.Count > 0)
                        return new ResponseBase<List<Respuestas>>()
                        {
                            codigo = (int)HttpStatusCode.OK,
                            estado = true,
                            mensaje = string.Empty,
                            datos = menúss
                        };
                    else
                        return new ResponseBase<List<Respuestas>>()
                        {
                            codigo = (int)HttpStatusCode.NotFound,
                            estado = true,
                            mensaje = "No hay respuestas disponibles.",
                            datos = null
                        };
                }
                else
                {
                    return new ResponseBase<List<Respuestas>>()
                    {
                        codigo = (int)HttpStatusCode.NotFound,
                        estado = false,
                        mensaje = "La consulta de respuesta no retorno resultados.",
                        datos = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<List<Respuestas>>()
                {
                    codigo = (int)HttpStatusCode.InternalServerError,
                    estado = false,
                    mensaje = $"Error: {ex.Message}",
                    datos = null
                };
            }
        }

        public async Task<ResponseBase<Respuestas>> save(RequestRespuesta _data, Transaction trans)
        {
            var ob = new Respuestas();
            ob = JsonConvert.DeserializeObject<Respuestas>(JsonConvert.SerializeObject(_data));

            if (trans == Transaction.Delete)
            {
                return new ResponseBase<Respuestas>()
                {
                    codigo = (int)HttpStatusCode.NotFound,
                    estado = false,
                    mensaje = $"La operación de eliminar respuesta no ha sido implementada.",
                    datos = null
                };
            }
            else
            {
                var data = await _dalc.set(ob, trans);
                if (data != null)
                {
                    return new ResponseBase<Respuestas>()
                    {
                        codigo = (int)HttpStatusCode.OK,
                        estado = true,
                        mensaje = $"Operación realizada con exito",
                        datos = data
                    };
                }
                else
                    return new ResponseBase<Respuestas>()
                    {
                        codigo = (int)HttpStatusCode.InternalServerError,
                        estado = false,
                        mensaje = $"La operación solicitada no se pudo realizar.",
                        datos = data
                    };
            }
        }
    }
}
