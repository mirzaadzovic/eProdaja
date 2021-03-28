using AutoMapper;
using eProdaja.Controllers;
using eProdaja.Database;
using eProdaja.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodServices:BaseCRUDService<Model.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest, Database.Proizvodi>, IProizvodService
    {
        public ProizvodServices(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
          
        }
        public override IEnumerable<Model.Proizvodi> Get(ProizvodiSearchObject search=null)
        {
            var set = _context.Set<Database.Proizvodi>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                set = set.Where(p => p.Naziv.Contains(search.Naziv));
            }
            if (search.JedinicaMjereId.HasValue)
            {
                set = set.Where(p => p.JedinicaMjereId == search.JedinicaMjereId);
            }
            if (search.VrstaId.HasValue)
            {
                set = set.Where(p => p.VrstaId== search.VrstaId);
            }
            if (search?.IncludeJedinicaMjere==true)
            {
                set = set.Include(p => p.JedinicaMjere);
            }
            if (search?.IncludeVrsta == true)
            {
                set = set.Include(p => p.Vrsta);
            }
            if (search?.IncludeList?.Length > 0)
            {
                foreach(var item in search.IncludeList)
                {
                    set = set.Include(item);
                }
            }
            var list = set.ToList();
            return _mapper.Map<List<Model.Proizvodi>>(list);
        }

        //-----------------LOŠA PRAKSA---------------------

        //public IEnumerable<Model.Proizvodi> GetByName(string Name)
        //{
        //    return base.Get().Where(proizvod => proizvod.Naziv.Contains(Name)).ToList();
        //}
        //public IEnumerable<Model.Proizvodi> GetByVrstaId(int VrstaId)
        //{
        //    return base.Get().Where(proizvod => proizvod.VrstaId == VrstaId).ToList();
        //}
        //public IEnumerable<Model.Proizvodi> GetByVrstaIdAndName(int VrstaId, string Name)
        //{
        //    return base.Get()
        //        .Where(proizvod => proizvod.VrstaId == VrstaId && proizvod.Naziv.Contains(Name))
        //        .ToList();
        //}

        //public IEnumerable<Proizvod> Get()
        //{
        //    return _proizvodi;
        //}
        //public Proizvod GetById(int id)
        //{
        //    var lista = _proizvodi.SingleOrDefault(proizvod => proizvod.ID == id);
        //    return lista;
        //}
        //public Proizvod Insert(Proizvod proizvod)
        //{
        //    _proizvodi.Add(proizvod);
        //    return proizvod;
        //}
        //public Proizvod Update(int id, Proizvod proizvod)
        //{
        //    var proizvodUredjen = _proizvodi.SingleOrDefault(p => p.ID == id);
        //    proizvodUredjen.Naziv = proizvod.Naziv;
        //    return proizvodUredjen;
        //}
        //public Proizvod Delete(int id)
        //{
        //    var proizvod = _proizvodi.SingleOrDefault(p => p.ID == id);
        //    _proizvodi.Remove(proizvod);
        //    return proizvod;
        //}
    }
}
