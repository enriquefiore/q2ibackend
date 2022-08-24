using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Usuarios = new HashSet<Usuario>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Salario { get; set; }
        public int? IdCargo { get; set; }
        public int? IdEmpresa { get; set; }
        public virtual Cargo? IdCargoNavigation { get; set; }
        public virtual Empresa? IdEmpresaNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
