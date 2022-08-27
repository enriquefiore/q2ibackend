using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Telefone
    {
        public Telefone()
        {
            Empresas = new HashSet<Empresa>();
        }

        public int Id { get; set; }
        public int? Numero { get; set; }
        public int? Ddd { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
