using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnici, KorisniciSearchObject, object, object, Database.Korisnici>, IKorisniciService
    {

        public KorisniciService(eProdajaContext db, IMapper mapper):base(db, mapper)
        {
        }
        public override IEnumerable<Model.Korisnici> Get(KorisniciSearchObject search = null)
        {
            var set = _context.Set<Database.Korisnici>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Ime))
            {
                set = set.Where(k => k.Ime.StartsWith(search.Ime));
            }
            var entity = set.ToList();

            return _mapper.Map<List<Model.Korisnici>>(entity);
        }
    }
}
