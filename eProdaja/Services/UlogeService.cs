using AutoMapper;
using eProdaja.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class UlogeService:BaseReadService<Model.Uloge, Database.Uloge, object>, IUlogeService
    {
        public UlogeService(eProdajaContext context, IMapper mapper) :base(context, mapper)
        {

        }
    }
}
