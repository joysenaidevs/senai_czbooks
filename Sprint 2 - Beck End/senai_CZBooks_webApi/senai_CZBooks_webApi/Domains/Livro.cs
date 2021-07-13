using System;
using System.Collections.Generic;

#nullable disable

namespace senai_CZBooks_webApi.Domains
{
    public partial class Livro
    {
        public Livro()
        {
            Autors = new HashSet<Autor>();
        }

        public int IdLivro { get; set; }
        public int? IdTipoLivro { get; set; }
        public int? IdBiblioteca { get; set; }
        public string NomeLivro { get; set; }
        public string Sinopse { get; set; }
        public string Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public decimal Preco { get; set; }

        public virtual Biblioteca IdBibliotecaNavigation { get; set; }
        public virtual TipoLivro IdTipoLivroNavigation { get; set; }
        public virtual ICollection<Autor> Autors { get; set; }
    }
}
