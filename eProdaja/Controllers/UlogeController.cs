using eProdaja.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    public class UlogeController:BaseReadController<Model.Uloge, object>
    {
        public UlogeController(IReadService<Model.Uloge, object> service) :base(service)
        {
            /*Proslijedili smo direktno IReadService da ne moramo praviti
            poseban interfejs za IUlogeService (postoje u folderu jer sam ih 
            napravio prije nego sam ovo saznao)*/
        }
    }
}
