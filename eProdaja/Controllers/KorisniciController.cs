using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
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
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _korisniciService;
        public KorisniciController(IKorisniciService korisniciService)
        {
            _korisniciService = korisniciService;
        }
        [HttpGet]
        public IList<Model.Korisnici> Get()
        {
            return _korisniciService.Get();
        }
        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _korisniciService.GetById(id);
        }
        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest korisnik)
        {
            return _korisniciService.Insert(korisnik);
        }
    }
}
