using senai_CZBooks_webApi.Contexts;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        CZBooksContext ctx = new CZBooksContext();


        /// <summary>
        /// Atualiza uma biblioteca existente
        /// </summary>
        /// <param name="id">id da biblioteca que será atualizada</param>
        /// <param name="bibliotecaUpdate">objeto que será atualizado</param>
        public void Atualizar(int id, Biblioteca bibliotecaUpdate)
        {
            Biblioteca bibliotecaBuscada = ctx.Bibliotecas.Find(id);

            // verifica se o nome da biblioteca foi informada
            if (bibliotecaUpdate.NomeBiblioteca != null)
            {
                bibliotecaBuscada.NomeBiblioteca = bibliotecaUpdate.NomeBiblioteca;
            }

            // verifica se os livros foram informados
            if (bibliotecaUpdate.Livros != null)
            {
                bibliotecaBuscada.Livros = bibliotecaUpdate.Livros;
            }

            // verifica se o endenreco foi informado
            if (bibliotecaUpdate.Endereco != null)
            {
                bibliotecaBuscada.Endereco = bibliotecaUpdate.Endereco;
            }

            //Atualiza o autor que foi buscado
            ctx.Bibliotecas.Update(bibliotecaBuscada);

            //salva as alteracoes
            ctx.SaveChanges();
        }

        /// <summary>
        /// busca uma biblioteca através do seu ID
        /// </summary>
        /// <param name="id">id da biblioteca buscada</param>
        /// <returns>retorna todas as bibliotecas buscadas</returns>
        public Biblioteca BuscarPorId(int id)
        {
            //retorna um livro buscado através do seu ID
            return ctx.Bibliotecas.FirstOrDefault(b => b.IdBiblioteca == id);
        }

        /// <summary>
        /// Cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca">objeto da nova biblioteca que será cadastrada</param>
        public void Cadastrar(Biblioteca novaBiblioteca)
        {
            ctx.Bibliotecas.Add(novaBiblioteca);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma biblioteca através do seu ID
        /// </summary>
        /// <param name="id">id da biblioteca que será deletada</param>

        public void Deletar(int id)
        {
            // remove uma biblioteca através do seu ID
            ctx.Bibliotecas.Remove(BuscarPorId(id));

            // salva como alteracoes
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as bibliotecas
        /// </summary>
        /// <returns> retorna uma lista de bibliotecas</returns>
        public List<Biblioteca> Listar()
        {
            return ctx.Bibliotecas.ToList();
        }
    }
}
