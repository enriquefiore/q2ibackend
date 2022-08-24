using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Funcionarios = new HashSet<Funcionario>();
        }
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int? IdEndereco { get; set; }
        public int? IdTelefone { get; set; }

        public virtual Endereco? IdEnderecoNavigation { get; set; }
        public virtual Telefone? IdTelefoneNavigation { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
