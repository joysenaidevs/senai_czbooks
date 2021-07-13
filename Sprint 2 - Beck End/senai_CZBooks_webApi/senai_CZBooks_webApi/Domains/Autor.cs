using System;
using System.Collections.Generic;

#nullable disable

namespace senai_CZBooks_webApi.Domains
{
    public partial class Autor
    {
        public int IdAutor { get; set; }
        public int? IdLivro { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeAutor { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual Livro IdLivroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
