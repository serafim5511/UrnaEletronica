using Entities.Entities.Enums;
using Entities.Notifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Vereador : Notifies
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(150)]
        public string Numero { get; set; }

        public Titulo partido { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public DateTime DataCadastro { get; set; }
        [NotMapped]
        public IFormFile Imagem { get; set; }
        public string Url { get; set; }
        public string legenda { get; set; }
        public int voto { get; set; }

    }
}
