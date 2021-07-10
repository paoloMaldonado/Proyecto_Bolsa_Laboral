using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoBolsaLaboral.Web.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Empresa = new HashSet<Empresa>();
        }

        public int IdSector { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
