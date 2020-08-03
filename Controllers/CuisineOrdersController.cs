using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using CuisineOrdersAPI.Data;
//using CuisineOrdersAPI.Dtos;
using CuisineOrdersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuisineOrdersAPI.Controllers
{
    [Route("api/CuisineOrders")]
    [ApiController]
    public class CuisineOrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICuisineOrderRepo _repository;

        public CuisineOrdersController(ICuisineOrderRepo repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CuisineOrder>> GetAllCommmands()
        {
            var orderItems = _repository.GetAllCommands();

            return Ok(orderItems);
        }

        [HttpPost]
        public ActionResult CreateCuisineOrder(CuisineOrder cuisineOrder)
        {

            Data.Mapper mapper = new Data.Mapper();

            mapper.Map(cuisineOrder);

            _repository.CreateCuisineOrder(mapper.orderHeader, mapper.orderLines); 
            _repository.SaveChanges(); 

            return Ok();
        }
    }
}
