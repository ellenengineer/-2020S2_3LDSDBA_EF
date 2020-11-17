using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EF.Models
{
    public partial class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O login é obrigatório")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo do login é de 10 caracteres")]
        public string Login1 { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo da senha é de 10 caracteres")]
        public string Senha { get; set; }
        public int CodCli { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
    }
}
