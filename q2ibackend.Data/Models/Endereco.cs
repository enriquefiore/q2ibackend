using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Empresas = new HashSet<Empresa>();
        }

        public long Id { get; set; }
        public long? Cep { get; set; }
        public string? Logradouro { get; set; }
        public long? Numero { get; set; }
        public string? Complemento { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
