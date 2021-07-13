using System;
using System.Collections.Generic;

#nullable disable

namespace senai_CZBooks_webApi.Domains
{
    public partial class TipoLivro
    {
        public TipoLivro()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdTipoLivro { get; set; }
        public string TituloTipoLivro { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
