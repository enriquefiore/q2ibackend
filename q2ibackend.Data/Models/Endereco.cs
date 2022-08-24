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

        public int Id { get; set; }
        public int? Cep { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
