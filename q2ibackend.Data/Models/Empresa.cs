using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Empresa
    {
        public long Id { get; set; }
        public string Nome { get; set; } = null!;
        public long? IdEndereco { get; set; }
        public long? IdTelefone { get; set; }

        public virtual Endereco? IdEnderecoNavigation { get; set; }
        public virtual Telefone? IdTelefoneNavigation { get; set; }
    }
}
