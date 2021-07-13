using senai_CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Interfaces
{
    // interface responsavel pelos endpoints autor
    interface IAutorRepository
    {
        /// <summary>
        /// Cadastra um novo autor
        /// </summary>
        /// <param name="novoAutor">objeto que sera cadastrado</param>
        void Cadastrar(Autor novoAutor);

        /// <summary>
        /// Lista todos os autores
        /// </summary>
        /// <returns>retorna uma lista de autores</returns>
        List<Autor> Listar();

        /// <summary>
        /// Busca um autor atraves do id
        /// </summary>
        /// <param name="id">id que será buscado</param>
        /// <returns>retorna o id do autor buscada </returns>
        Autor BuscarPorId(int id);

        /// <summary>
        /// Atualiza umm autor existente atrevés do seu id
        /// </summary>
        /// <param name="id">id do autor atualizado</param>
        /// <param name="autorUpdate">objeto que será atualizado</param>
        void Atualizar(int id, Autor autorUpdate);

        /// <summary>
        /// deleta um autor existente
        /// </summary>
        /// <param name="id">objeto que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os livros de um determinado usuario
        /// </summary>
        /// <param name="id">id do livro que será listado</param>
        /// <returns>retorna a lista de livros</returns>
        List<Autor> ListarMeus(int id);
    }
}
