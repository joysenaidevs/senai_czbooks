using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_CZBooks_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Autors = new HashSet<Autor>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe a senha do usuário!")]
        [StringLength(9, MinimumLength = 4, ErrorMessage = "Ao Cadastrar um usuario, a senha deverá ter de 3 a 6 caracteres")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Autor> Autors { get; set; }
    }
}
