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
    /// repositório responsavel por TipoUsuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto que será chamado o EF Core
        /// </summary>       
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// Atualiza um tipo usuario existente
        /// </summary>
        /// <param name="id">id do TIPO usuario atualizado</param>
        /// <param name="tipoUsuarioUpdate">objeto que será atualizado</param>
        public void Atualizar(int id, TiposUsuario tipoUsuarioUpdate)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            if (tipoUsuarioUpdate.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioUpdate.TituloTipoUsuario;
            }

            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um tipo de usuario através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">objeto que será cadastrado</param>
        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            //ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.TiposUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// deleta um tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            // remove a consulta buscada
            ctx.TiposUsuarios.Remove(BuscarPorId(id));

            // salva as alteracoes
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>retorna uma lista de tipos usuarios</returns>
        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
