using Microsoft.EntityFrameworkCore;
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
            // Busca um autor  através do id
            Autor autorBuscado = ctx.Autors.Find(id);

            //verifica se o id do usuario foi informado
            if (autorUpdate.IdUsuario != null)
            {
                // atribui novos valores aos campos existentes
                autorBuscado.IdUsuario = autorUpdate.IdUsuario;
            }

            // verifica se o id do livro foi informado
            if (autorUpdate.IdLivro != null)
            {
                // atribui novos valores aos campos existentes
                autorBuscado.IdLivro = autorUpdate.IdLivro;
            }

            // verifica se o nome do autor foi infromado
            if (autorUpdate.NomeAutor != null)
            {
                autorBuscado.NomeAutor = autorUpdate.NomeAutor;
            }



            //Atualiza o autor que foi buscado
            ctx.Autors.Update(autorBuscado);

            // salva as informacoes para serem gravadas
            ctx.SaveChanges();
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

        public List<Autor> ListarMeus(int id)
        {
            //retorna uma lista com todas as informações do autor
            return ctx.Autors
                // adiciona na busca as informacoes do livro que o usuario escreveu ou leu
                .Include(a => a.IdLivroNavigation)
                //adiciona na busca o tipo de livro que o usuario escreveu
                .Include(a => a.IdLivroNavigation.IdTipoLivroNavigation)

                //adiciona na busca a biblioteca referente ao livro
                .Include(a => a.IdLivroNavigation.IdBibliotecaNavigation)

                // estabelece como parametro de consulta o id do usuario recebido
                .Where(a => a.IdUsuario == id)
                .ToList();
        }
    }
}
