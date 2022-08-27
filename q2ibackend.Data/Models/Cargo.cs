using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string? Titulo { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
