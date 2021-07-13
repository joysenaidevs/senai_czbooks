using senai_CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista de tiposUsuarios
        /// </summary>
        /// <returns>retorna uma lista de usuarios</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">objeto que será cadastrado</param>
        void Cadastrar(TiposUsuario novoTipoUsuario);


        /// <summary>
        /// Busca um tipo de usuario através do seu id
        /// </summary>
        /// <param name="id">id do tipo usuario buscado</param>
        /// <returns></returns>
        TiposUsuario BuscarPorId(int id);


        /// <summary>
        /// Atualiza um tipo de usuario existente através do seu id
        /// </summary>
        /// <param name="id">id do usuario existente</param>
        /// <param name="tipoUsuarioUpdate">objeto que será atualizado</param>
        void Atualizar(int id, TiposUsuario tipoUsuarioUpdate);

        /// <summary>
        /// Delta um tipo de usuario existente
        /// </summary>
        /// <param name="id">id do tipo de usuario deletado</param>
        void Deletar(int id);
    }
}
