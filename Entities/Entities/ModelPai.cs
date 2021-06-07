using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ModelPai
    {
        public IList<Prefeito> Prefeito { get; set; }
        public IList<Vereador> Vereador { get; set; }
    }
}
