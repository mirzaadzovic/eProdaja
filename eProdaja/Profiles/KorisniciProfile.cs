using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Profiles
{
    public class KorisniciProfile:Profile
    {
        public KorisniciProfile()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>().ReverseMap();
            CreateMap<Model.KorisniciInsertRequest ,Database.Korisnici>();
            CreateMap<Model.KorisniciUpdateRequest, Database.Korisnici>();
            CreateMap<Database.JediniceMjere, Model.JedinicaMjere>();
            CreateMap<Database.VrsteProizvodum, Model.VrsteProizvodum>();
            CreateMap<Database.Proizvodi, Model.Proizvodi>();
            CreateMap<ProizvodiInsertRequest, Database.Proizvodi>();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>();
            CreateMap<Database.Uloge, Model.Uloge>().ReverseMap();
        }

    }
}
