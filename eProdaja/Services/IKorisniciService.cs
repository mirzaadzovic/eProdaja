using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IKorisniciService
    {
        IList<Model.Korisnici> Get();
        Model.Korisnici GetById(int id);
        Model.Korisnici Insert(KorisniciInsertRequest korisnik);
    }
}
