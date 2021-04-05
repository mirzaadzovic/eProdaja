using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public class JedinicaMjere
    {
        public int JedinicaMjereId { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return this.Naziv;
        }
    }
}
