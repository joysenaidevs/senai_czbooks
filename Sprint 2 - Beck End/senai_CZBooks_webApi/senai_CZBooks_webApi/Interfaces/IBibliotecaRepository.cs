using senai_CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Interfaces
{
    interface IBibliotecaRepository
    {

        void Cadastrar(Biblioteca novaBiblioteca);

        List<Biblioteca> Listar();

        void Atualizar(int id, Biblioteca bibliotecaUpdate);

        Biblioteca BuscarPorId(int id);

        void Deletar(int id);
    }
}
