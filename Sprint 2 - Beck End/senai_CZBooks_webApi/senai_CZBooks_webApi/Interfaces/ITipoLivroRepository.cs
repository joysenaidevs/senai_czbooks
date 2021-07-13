using senai_CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Interfaces
{
    interface ITipoLivroRepository
    {
        void Cadastrar(TipoLivro novoLivro);

        List<TipoLivro> Listar();

        void Atualizar(int id, TipoLivro tipoLivroUpdate);

        TipoLivro BuscarPorId(int id);

        void Deletar(int id);
    }
}
