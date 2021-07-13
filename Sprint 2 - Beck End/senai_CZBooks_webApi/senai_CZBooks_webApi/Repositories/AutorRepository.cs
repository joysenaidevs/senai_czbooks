using senai_CZBooks_webApi.Contexts;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Repositories
{
    /// <summary>
    /// Repositório responsavel por Autor
    /// </summary>
    public class AutorRepository : IAutorRepository
    {
        /// <summary>
        /// Objeto contexto que sera chamado ao EF Core
        /// </summary>
        CZBooksContext ctx = new CZBooksContext();

        public void Atualizar(int id, Autor autorUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca um autor existente através do seu id
        /// </summary>
        /// <param name="id">objeto que será buscado</param>
        /// <returns>retorna o autor buscado e um status code 200</returns>
        public Autor BuscarPorId(int id)
        {
            // retorna um autor buscado através do seu id
            return ctx.Autors.FirstOrDefault(a => a.IdAutor == id);
        }

        public void Cadastrar(Autor novoAutor)
        {
            ctx.Autors.Add(novoAutor);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um autor existente
        /// </summary>
        /// <param name="id">objeto que será deletado</param>
        public void Deletar(int id)
        {
            // remover um autor buscado
            ctx.Autors.Remove(BuscarPorId(id));
            
            // salva como alteracoes
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os autores
        /// </summary>
        /// <returns>retorna uma lista de autores</returns>
        public List<Autor> Listar()
        {
            // retorna uma lista de autores
            return ctx.Autors.ToList();
        }
    }
}
