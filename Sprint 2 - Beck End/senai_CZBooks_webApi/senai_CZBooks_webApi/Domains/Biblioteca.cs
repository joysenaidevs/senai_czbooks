using System;
using System.Collections.Generic;

#nullable disable

namespace senai_CZBooks_webApi.Domains
{
    public partial class Biblioteca
    {
        public Biblioteca()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdBiblioteca { get; set; }
        public string NomeBiblioteca { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
