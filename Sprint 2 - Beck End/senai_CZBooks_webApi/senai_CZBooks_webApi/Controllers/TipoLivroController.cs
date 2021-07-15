using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using senai_CZBooks_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Controllers
{
    /// <summary>
    /// Controlador responsavel pelos tipos de livros
    /// </summary>
    
    // define que a api sera no formato json
    [Produces("application/json")]

    // define a rota da api
    [Route("api/[controller]")]

    // define que é um controlador api
    [ApiController]
    public class TipoLivroController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoLivroRepository que irá receber todos os métodos definidos na interface ITipoLivroRepository
        /// </summary>
        private ITipoLivroRepository _tipoLivroRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoLivroRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public TipoLivroController()
        {
            _tipoLivroRepository = new TipoLivroRepository();
        }

        /// <summary>
        /// Lista todos os tipos de livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //tratamento de excessao
            try
            {
                // retorna uma lista com status code 200
                return Ok(_tipoLivroRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tipo de livroa través do seu id
        /// </summary>
        /// <param name="id">id do tipo de livro buscado</param>
        /// <returns>retorna um status code 200 e o tipo de livro buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // tratamento de excessao
            try
            {
                return Ok(_tipoLivroRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                // retorna um status code 400 caso de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de livro
        /// </summary>
        /// <param name="novoTipoLivro">objet que sera cadastrado</param>
        /// <returns>retorna um status code 201</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(TipoLivro  novoTipoLivro)
        {
            // tratamento de excessao
            try
            {
                // faz a chamada para o método
                _tipoLivroRepository.Cadastrar(novoTipoLivro);

                // retorna um status code 201, de cadastrar
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um tipo de livro existente
        /// </summary>
        /// <param name="id">id do tipo de livro atualizado</param>
        /// <param name="tipoLivroUpdate">objeto que sera atualizado</param>
        /// <returns>retorna um status code 204</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoLivro tipoLivroUpdate)
        {
            try
            {
                // faz a chamada para o método
                _tipoLivroRepository.Atualizar(id, tipoLivroUpdate);

                //retorna um status code 204
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //retorna um erro 400
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de livro existente
        /// </summary>
        /// <param name="id">id do tipo de livro deletado</param>
        /// <returns>retorna um tipo de lvro deletado e um status code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // tratamento de excessao
            try
            {
                // faz a chamada para o método
                _tipoLivroRepository.Deletar(id);

                // retorna um status code 204
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
               
            }
        }



    }
}
