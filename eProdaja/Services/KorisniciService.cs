using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        private eProdajaContext _db { get; set; }
        private readonly IMapper _mapper;
        public KorisniciService(eProdajaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IList<Model.Korisnici> Get()
        {
            return _db.Korisnicis.Select(korisnik=>_mapper.Map<Model.Korisnici>(korisnik)).ToList();
        }
        public Model.Korisnici GetById(int id)
        {
            return _db.Korisnicis.Where(korisnik=>korisnik.KorisnikId==id)
                .Select(korisnik => _mapper.Map<Model.Korisnici>(korisnik))
                .SingleOrDefault();
        }

        public Model.Korisnici Insert(KorisniciInsertRequest korisnik)
        {
            throw new NotImplementedException();
        }
    }
}
