using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aspen.Domain;
using Aspen.Domain.Models;
using Aspen.Domain.PotionManager;
using AutoMapper;

namespace TestDemo.Controllers.API
{
    public class ColorAPIController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var pManager = new PotionManager();
            var colors = pManager.GetAllColors();
            Mapper.CreateMap<Color, ColorResponseMessage>();
            List<ColorResponseMessage> response = Mapper.Map<List<Color>, List<ColorResponseMessage>>(colors);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
