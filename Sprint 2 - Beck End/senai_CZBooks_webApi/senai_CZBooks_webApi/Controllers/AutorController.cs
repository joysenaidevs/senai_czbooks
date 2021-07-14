using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_CZBooks_webApi.Domains;
using senai_CZBooks_webApi.Interfaces;
using senai_CZBooks_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks_webApi.Controllers
{
    /// <summary>
    /// Controlador responsavel pelo autor
    /// </summary>

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class AutorController : ControllerBase
    {
        /// <summary>
        /// Objeto _autorRepository que irá receber todos os métodos definidos na interface IAutorRepository
        /// </summary>
        private IAutorRepository _autorRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _autorRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public AutorController()
        {
            _autorRepository = new AutorRepository();
        }

        /// <summary>
        /// Lista todos os autores
        /// </summary>
        /// <returns>retorna uma lista de autores com status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // tratamento de excessão
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_autorRepository.Listar());
            }
            catch (Exception erro)
            {
                // retorna uma status code 400
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_autorRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo autor
        /// </summary>
        /// <param name="novoAutor">objeto que será cadastrado</param>
        /// <returns>retorna um novo autor cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Autor novoAutor)
        {
            try
            {
                //faz a chamada para o metodo
                _autorRepository.Cadastrar(novoAutor);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um autor existente
        /// </summary>
        /// <param name="id">ID do autor que será atualizado</param>
        /// <param name="autorUpdate">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "1")
        public IActionResult Put(int id, Autor autorUpdate)
        {
            try
            {
                // Faz a chamada para o método
                _autorRepository.Atualizar(id, autorUpdate);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // retorna um erro 400
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um autor existente
        /// </summary>
        /// <param name="id">Id do autor a ser deletado</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // tratamento de excessao
            try
            {
                _autorRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // retorna um erro 400
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista todos os livros de um determinado usuário
        /// </summary>
        /// <returns>Uma lista de presenças e um status code 200 - Ok</returns>
        /// dominio/api/autor/minhas
        // Define que somente o usuário autor  pode acessar o método
        [Authorize(Roles = "3")]
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_autorRepository.ListarMeus(idUsuario));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os livros se o usuário não estiver logado!",
                    error
                });
            }
        }

    }
}
