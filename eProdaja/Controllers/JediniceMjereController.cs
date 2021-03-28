using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class JediniceMjereController/*:ControllerBase*/:BaseReadController<Model.JedinicaMjere, object>
    {
        //private readonly IJedinicaMjereService _service;
        public JediniceMjereController(IJedinicaMjereService service)
            :base(service)
        {
            //_service = service;
        }
        //[HttpGet]
        //public IEnumerable<Model.JedinicaMjere> Get()
        //{
        //    return _service.Get();
        //}
        //[HttpGet("{id}")]
        //public Model.JedinicaMjere GetById(int id)
        //{
        //    return _service.GetById(id);
        //}
    }
}
