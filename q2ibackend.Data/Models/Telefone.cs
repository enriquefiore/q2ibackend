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

        public long Id { get; set; }
        public long? Numero { get; set; }
        public long? Ddd { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
