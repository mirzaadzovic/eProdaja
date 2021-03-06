using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController:ControllerBase
    {
        private IProizvodServices _proizvodi;

        public ProizvodController(IProizvodServices proizvodi)
        {
            _proizvodi = proizvodi;
        }
        [HttpGet]
        public IEnumerable<Proizvod> Get()
        {
            return _proizvodi.Get();
        }
        [HttpGet("{id}")]
        public Proizvod GetById(int id)
        {
            return _proizvodi.GetById(id);
        }

        [HttpPost]
        public Proizvod Insert(Proizvod proizvod)
        {
            return _proizvodi.Insert(proizvod);
        }
       
        [HttpPut("{id}")]
        public Proizvod Update(int id, Proizvod proizvod)
        {
            return _proizvodi.Update(id, proizvod);
        }
        
        [HttpDelete("{id}")]
       public Proizvod Delete(int id)
        {
            return _proizvodi.Delete(id);
        }

    }
    public class Proizvod
    { 
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
