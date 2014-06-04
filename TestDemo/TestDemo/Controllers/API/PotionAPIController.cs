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
    public class PotionAPIController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage Get([FromBody]int? id)
        {
            try
            {
                var pManager = new PotionManager();
                var potion = id < 0 || id == null
                    ? new Potions
                    {
                        Name = "No RecipieId given",
                        Description = "No RecipieId was given.",
                        navColor = new Color { Description = string.Empty },
                        navEffect = new Effect { Description = string.Empty }
                    }
                    : (pManager.GetPotion(n => n.PotionID == id) ?? new Potions
                    {
                        Name = "No Recipie found",
                        Description = "No Recipie found with the id of " + id,
                        navColor = new Color { Description = string.Empty },
                        navEffect = new Effect { Description = string.Empty }
                    });

                Mapper.CreateMap<Potions, PotionResponseMessage>();
                var responseMessage = Mapper.Map<Potions, PotionResponseMessage>(potion);

                return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]int? id)
        {
            try
            {
                var pManager = new PotionManager();

                var potion = id < 0 || id == null
                    ? new Potions
                    {
                        Name = "No Recipie found",
                        Description = "No Recipie found with the id of " + id,
                        navColor = new Color { Description = string.Empty },
                        navEffect = new Effect { Description = string.Empty }
                    }
                    : (pManager.GetPotion(n => n.PotionID == id) ?? new Potions
                    {
                        Name = "No Recipie found",
                        Description = "No Recipie found with the id of " + id,
                        navColor = new Color { Description = string.Empty },
                        navEffect = new Effect { Description = string.Empty }
                    });

                Mapper.CreateMap<Potions, PotionResponse>();
                var response = Mapper.Map<Potions, PotionResponse>(potion);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }


        }
    }
}
