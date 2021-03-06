using eProdaja.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IProizvodServices
    {
        IEnumerable<Proizvod> Get();
        Proizvod GetById(int id);
        Proizvod Insert(Proizvod proizvod);
        Proizvod Update(int id, Proizvod proizvod);
        Proizvod Delete(int id);

    }
}
