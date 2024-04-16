using Microsoft.AspNetCore.Mvc;
using WSmostCommonWordsInEnglishNuevo.Response;
using WSmostCommonWordsInEnglishNuevo.Tools;
using WSmostCommonWordsInEnglishNuevo.Models;

namespace WSmostCommonWordsInEnglishNuevo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {

        private DbMostcommonwordsinenglishContext _db;

        public WordController(DbMostcommonwordsinenglishContext db)
        {
            _db = db;
        }


        [HttpGet]

        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            var lst = new List<Word>();

            try
            {

                using (_db)
                {

                    lst = _db.Words.ToList();
                    respuesta.Mensaje = "Todo ok";
                    respuesta.Codigo = 1;
                    respuesta.Data = lst;
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta respuesta = new Respuesta();


            try
            {
                using (_db)
                {
                    if (id > 0)
                    {
                        var filtro = _db.Words.Where(w => w.IdWord == id).FirstOrDefault();
                        respuesta.Mensaje = "Todo ok";
                        respuesta.Codigo = 1;
                        respuesta.Data = filtro;

                        if (respuesta.Data == null)
                        {
                            respuesta.Codigo = 404;
                            respuesta.Mensaje = "El id solicitado no existe";
                        }

                    }
                    else
                    {
                        respuesta.Codigo = 204;
                        respuesta.Mensaje = "El numero debe ser mayor a 0";
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }


        [HttpGet("random")]
        public IActionResult GetRandom([FromQuery(Name = "cantidad")] int cant)
        {
            Respuesta respuesta = new Respuesta();


            try
            {
                using (_db)
                {
                    if (cant > 0)
                    {
                        var lst = new List<Word>();
                        var lstFiltrado = new List<Word>();
                        var oRandom = new RandomNumber();
                        lst = _db.Words.ToList();



                        for (int i = 0; i < cant; i++)
                        {
                            var numeroSeleccionado = oRandom.NumeroRandom(lst);
                            lstFiltrado.Add(lst[numeroSeleccionado]);
                            lst.RemoveAt(numeroSeleccionado);
                        }

                        respuesta.Mensaje = "Todo ok";
                        respuesta.Codigo = 1;
                        respuesta.Data = lstFiltrado;


                        if (respuesta.Data == null)
                        {
                            respuesta.Codigo = 404;
                            respuesta.Mensaje = "El id solicitado no existe";
                        }

                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "El numero debe ser mayor a 0";
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
                if (cant > 1001)
                {
                    respuesta.Codigo = 404;
                    respuesta.Mensaje = $"No existe/n {cant} palabras, intenta con un numero menor a 1002";
                }
            }

            return Ok(respuesta);
        }


        [HttpGet("rango")]

        public IActionResult GetRango([FromQuery(Name = "inicio")] int inicio, [FromQuery(Name = "fin")] int fin)
        {
            Respuesta oRespuesta = new Respuesta();
            var lst = new List<Word>();

            try
            {
                using (_db)
                {
                    if (inicio <= fin)
                    {
                        if (inicio == 0)
                        {
                            inicio = 1;
                        }
                        else { }


                        if (fin <= 1001)
                        {
                            if (inicio != 0)
                            {
                                if (fin == 0)
                                {
                                    fin = 1001;
                                }
                                else { }

                                lst = _db.Words.Where(w => w.IdWord >= inicio && w.IdWord <= fin).ToList();
                                oRespuesta.Codigo = 200;
                                oRespuesta.Mensaje = "Todo Ok";
                                oRespuesta.Data = lst;
                            }

                        }

                        else
                        {
                            oRespuesta.Codigo = 400;
                            oRespuesta.Mensaje = "El fin no puede ser mayor a 1001";
                        }
                    }
                    else
                    {
                        if (fin != 0)
                        {
                            oRespuesta.Codigo = 400;
                            oRespuesta.Mensaje = "El fin no puede ser menor que el inicio";
                        }
                        else
                        {
                            oRespuesta.Codigo = 400;
                            oRespuesta.Mensaje = "Debes agregar un numero para el fin";
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }


            return Ok(oRespuesta);
        }

    }
}
