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
    /// Controlador responsavel pelos LIVROS
    /// </summary>

    //define que será no formato JSON
    [Produces("application/json")]

    //define que será um controlador API
    [Route("api/[controller]")]

    // 
    [ApiController]
    public class LivrosController : ControllerBase
    {

        /// <summary>
        /// Objeto _livroRepository que irá receber todos os métodos definidos na interface ILivroRepository
        /// </summary>
        private ILivroRepository _livroRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _livroRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public LivrosController()
        {
            _livroRepository = new LivroRepository();
        }

        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns>retorna uma lista de autores com status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // tratamento de excessão
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_livroRepository.Listar());
            }
            catch (Exception erro)
            {
                // retorna uma status code 400
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um livro pelo seu id
        /// </summary>
        /// <param name="id">Id do livro buscado</param>
        /// <returns>livro buscado e um StatusCode 200 - Ok</returns>
        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //tratamento de excessao
            try
            {
                return Ok(_livroRepository.BuscarPorId(id));

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="novoLivro">objeto q será cadastrado</param>
        /// <returns>retorna um status code 201</returns>
        [HttpPost]
        public IActionResult Post(Livro novoLivro)
        {
            try
            {
                //faz a chamada para o metodo
                _livroRepository.Cadastrar(novoLivro);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza um livro existente
        /// </summary>
        /// <param name="id">id que será atualizado</param>
        /// <param name="livroUpdate">objeto que será atualizado</param>
        /// <returns>retorna um status code 204</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livroUpdate)
        {
            try
            {
                //faz a chamada para o metodo
                _livroRepository.Atualizar(id, livroUpdate);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um livro existente
        /// </summary>
        /// <param name="id">Id do livro a ser deletado</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // tratamento de excessao
            try
            {
                _livroRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // retorna um erro 400
                return BadRequest(erro);
            }
        }
    }
}
