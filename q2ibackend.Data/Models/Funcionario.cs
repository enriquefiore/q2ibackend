using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Funcionario
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public byte[]? Salario { get; set; }
        public long? IdCargo { get; set; }
        public long? IdEmpresa { get; set; }

        public virtual Cargo? IdCargoNavigation { get; set; }
    }
}
