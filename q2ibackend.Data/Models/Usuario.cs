using System;
using System.Collections.Generic;

namespace q2ibackend.Data.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int IsAdmin { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario? IdFuncionarioNavigation { get; set; }

    }
}
