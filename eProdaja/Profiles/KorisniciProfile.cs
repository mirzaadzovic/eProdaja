﻿using AutoMapper;
using eProdaja.Database;
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
            CreateMap<Korisnici, Model.Korisnici>();
        }

    }
}
