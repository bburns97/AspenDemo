using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aspen.Domain;
using Aspen.Domain.Models;
using Aspen.Domain.PotionManager;
using AutoMapper;

namespace TestDemo.Controllers.API
{
    public class PotionRecipieAPIController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(PotionRecipieRequestMessage requestMessage)
        {
            try
            {
                var pManager = new PotionManager();
                var potionrecipies = pManager.GetPotionRecipes(n => n.PotionRecipieIngredientList == requestMessage.PotionRecipieIngredientList && n.MoodID == requestMessage.MoodID);
                Mapper.CreateMap<PotionRecipes, PotionRecipieResponseMessage>().ForMember(dest => dest.Effect, opt => opt.MapFrom(src => src.navEffect.Name));
                PotionRecipieResponseMessage response = Mapper.Map<PotionRecipes, PotionRecipieResponseMessage>(potionrecipies);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }

        }

    }
}
