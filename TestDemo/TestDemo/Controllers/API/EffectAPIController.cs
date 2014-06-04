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
    public class EffectAPIController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var pManager = new PotionManager();
            var effect = pManager.GetAllEffects();
            Mapper.CreateMap<Effect, EffectResponseMessage>();
            List<EffectResponseMessage> response = Mapper.Map<List<Effect>, List<EffectResponseMessage>>(effect);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
