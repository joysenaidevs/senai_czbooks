using senai_CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Interfaces
{
    // interface responsavel pelos livros
    interface ILivroRepository
    {
        void Cadastrar(Livro novoLivro);

        List<Livro> Listar();

        void Atualizar(int id, Livro livroUpdate);

        Livro BuscarPorId(int id);

        void Deletar(int id);

    }
}
