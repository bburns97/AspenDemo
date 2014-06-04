using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aspen.Domain;
using Aspen.Domain.Models;
using Aspen.Domain.PotionManager;
using AutoMapper;

namespace TestDemo.Controllers.API
{
    public class PotionsAPIController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetGrid()
        {
            try
            {
                var pManager = new PotionManager();
                var potions = pManager.GetAllPotions();

                Mapper.CreateMap<Potions, PotionResponse>().ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.navColor.Name)).ForMember(dest => dest.Effect, opt => opt.MapFrom(src => src.navEffect.Name));
                var response = Mapper.Map<List<Potions>, List<PotionResponse>>(potions);

                var responseMessage = new PotionResponseMessage
                {
                    page = "1",
                    records = response.Count.ToString(CultureInfo.InvariantCulture),
                    total = 1,
                    rows = new PotionResponse[response.Count]
                };

                for (var i = 0; i < response.Count; i++)
                {
                    responseMessage.rows[i] = response[i];
                }

                return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);

            }

        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new PotionResponseMessage());
        }

        [HttpPut]
        public HttpResponseMessage Put(PotionPutMessage potion)
        {

            return Request.CreateResponse(HttpStatusCode.OK, new PotionResponseMessage());
        }

        [HttpDelete]
        public HttpResponseMessage Delete()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new PotionResponseMessage());
        }



    }
}
