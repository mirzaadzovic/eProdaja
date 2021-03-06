using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodServices:IProizvodServices
    {
        private readonly static List<Proizvod> _proizvodi;
        static ProizvodServices()
        {
            _proizvodi = new List<Proizvod>()
            {
                new Proizvod()
                {
                    ID=1,
                    Naziv="Monitor"
                },
                new Proizvod()
                {
                    ID=2,
                    Naziv="CPU"
                },
                new Proizvod()
                {
                    ID=3,
                    Naziv="RAM"
                }
            };

        }
        public IEnumerable<Proizvod> Get()
        {
            return _proizvodi;
        }
        public Proizvod GetById(int id)
        {
            var lista = _proizvodi.SingleOrDefault(proizvod => proizvod.ID == id);
            return lista;
        }
        public Proizvod Insert(Proizvod proizvod)
        {
            _proizvodi.Add(proizvod);
            return proizvod;
        }
        public Proizvod Update(int id, Proizvod proizvod)
        {
            var proizvodUredjen = _proizvodi.SingleOrDefault(p => p.ID == id);
            proizvodUredjen.Naziv = proizvod.Naziv;
            return proizvodUredjen;
        }
        public Proizvod Delete(int id)
        {
            var proizvod = _proizvodi.SingleOrDefault(p => p.ID == id);
            _proizvodi.Remove(proizvod);
            return proizvod;
        }
    }
}
