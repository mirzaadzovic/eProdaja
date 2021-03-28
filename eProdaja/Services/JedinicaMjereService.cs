using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class JedinicaMjereService : BaseReadService<Model.JedinicaMjere, Database.JediniceMjere, object>, IJedinicaMjereService
    {
        //private readonly eProdajaContext _context;
        //private readonly IMapper _mapper;
        public JedinicaMjereService(eProdajaContext context, IMapper mapper)
            :base(context, mapper)
        {
            //_context = context;
            //_mapper = mapper;
        }
        //public IEnumerable<JedinicaMjere> Get()
        //{
        //    var list = _context.JediniceMjeres
        //        .Select(jm => _mapper.Map<Model.JedinicaMjere>(jm))
        //        .ToList();
        //    return list;

        //}

        //public JedinicaMjere GetById(int id)
        //{
        //    return _mapper.Map<Model.JedinicaMjere>(_context.JediniceMjeres.Find(id));
        //}
    }
}
