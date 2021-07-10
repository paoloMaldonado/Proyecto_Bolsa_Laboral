using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBolsaLaboral.Web.Models
{
    public partial class CategoriaEmpleo
    {
        public CategoriaEmpleo()
        {
            OfertaLaboral = new HashSet<OfertaLaboral>();
        }

        public int IdCatEmpleo { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<OfertaLaboral> OfertaLaboral { get; set; }
    }
}
