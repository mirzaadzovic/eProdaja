using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest, Database.Korisnici>, IKorisniciService
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
        public override Model.Korisnici Insert(KorisniciInsertRequest request)
        {

            var entity = _mapper.Map<Database.Korisnici>(request);

            if(request.Password!=request.PasswordPotvrda)
            {
                throw new UserException("Lozinka nije ispravno unesena!");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnicis.Add(entity);
            _context.SaveChanges();

            foreach(var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new KorisniciUloge()
                {
                    KorisnikId=entity.KorisnikId,
                    UlogaId=uloga,
                    DatumIzmjene=DateTime.Now
                };

                _context.KorisniciUloges.Add(korisniciUloge);
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
