using senai_CZBooks_webApi.Contexts;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Repositories
{
    public class TipoLivroRepository : ITipoLivroRepository
    {
        /// <summary>
        /// Objeto contexto que sera chamado ao EF Core
        /// </summary>
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// Atualiza um tipo de livro existente
        /// </summary>
        /// <param name="id">id do tipo de livro atualizado</param>
        /// <param name="tipoLivroUpdate">objeto que será atualizado</param>
        public void Atualizar(int id, TipoLivro tipoLivroUpdate)
        {
            // Busca um autor  através do id
            TipoLivro tipoLivroBuscado = ctx.TipoLivros.Find(id);

            // verifica se o livro foi informado
            if (tipoLivroUpdate.Livros != null)
            {
                tipoLivroBuscado.Livros = tipoLivroUpdate.Livros;
            }

            // verifica se o titulo do livro foi informado
            if (tipoLivroUpdate.TituloTipoLivro != null)
            {
                tipoLivroBuscado.TituloTipoLivro = tipoLivroUpdate.TituloTipoLivro;
            }

            //Atualiza o autor que foi buscado
            ctx.TipoLivros.Update(tipoLivroBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um livro através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TipoLivro BuscarPorId(int id)
        {
            // retorna um usuario buscado através do seu ID
            return ctx.TipoLivros.FirstOrDefault(tu => tu.IdTipoLivro == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de livro
        /// </summary>
        /// <param name="novoLivro">objeto que sera cadastrado</param>
        public void Cadastrar(TipoLivro novoLivro)
        {
            //cadastra um novo tipo de livro
            ctx.TipoLivros.Add(novoLivro);

            ctx.SaveChanges();
        }

        /// <summary>
        /// deleta um  tipo de usuario
        /// </summary>
        /// <param name="id">id do tipo usuario de será deletado</param>
        public void Deletar(int id)
        {
            // remover um autor buscado
            ctx.TipoLivros.Remove(BuscarPorId(id));

            // salva como alteracoes
            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todos os tipos usuarios
        /// </summary>
        /// <returns>retorna uma lista de tipos usuarios</returns>
        public List<TipoLivro> Listar()
        {
            // retorna uma lista de autores
            return ctx.TipoLivros.ToList();
        }
    }
}
