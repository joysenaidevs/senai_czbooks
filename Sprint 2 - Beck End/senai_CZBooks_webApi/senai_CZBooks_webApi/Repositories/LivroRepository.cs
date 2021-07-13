using senai_CZBooks_webApi.Contexts;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// Atualiza todos os livros existentes
        /// </summary>
        /// <param name="id">id do livro atualizado</param>
        /// <param name="livroUpdate">objeto que será atualizado</param>
        public void Atualizar(int id, Livro livroUpdate)
        {
            // busca um livro através do seu id
            Livro livroBuscado = ctx.Livros.Find(id);

            //verifica se o id do livro foi informado
            if (livroUpdate.NomeLivro != null)
            {
                // atribui novos valores aos campos existentes
                livroBuscado.NomeLivro = livroUpdate.NomeLivro;
            }

            // verifica se a sinopse do livro foi informado
            if (livroUpdate.Sinopse != null)
            {
                livroBuscado.Sinopse = livroUpdate.Sinopse;
            }

            // verifica se o preçoo foi informado
            if (livroUpdate.Preco == 90)
            {
                livroBuscado.Preco = livroUpdate.Preco;
            }

            // verifica se a biblioteca foi informada
            if (livroUpdate.IdBiblioteca != null)
            {
                livroBuscado.IdBiblioteca = livroUpdate.IdBiblioteca;
            }

            // verifica se o tipo do livro foi informado
            if (livroUpdate.IdTipoLivro != null)
            {
                livroBuscado.IdTipoLivro = livroUpdate.IdTipoLivro;
            }

            // verifica se a categoria foi informada
            if (livroUpdate.Categoria != null)
            {
                livroBuscado.Categoria = livroBuscado.Categoria;
            }

            //Atualiza o autor que foi buscado
            ctx.Livros.Update(livroBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um livro através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Livro BuscarPorId(int id)
        {
            //retorna um livro buscado através do seu ID
            return ctx.Livros.FirstOrDefault(l => l.IdLivro == id);
        }

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="novoLivro">retorna o novo livro e um status code 200</param>
        public void Cadastrar(Livro novoLivro)
        {
            ctx.Livros.Add(novoLivro);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um livro através do seu ID
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            // remover um autor buscado
            ctx.Livros.Remove(BuscarPorId(id));

            // salva como alteracoes
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns>status code 200 com todos os livros listados</returns>

        public List<Livro> Listar()
        {
            return ctx.Livros.ToList();
        }
    }
}
