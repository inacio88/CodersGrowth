using Dominio;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        public IRepositorioPessoa _repositorioPessoa;
        public IValidator<Pessoa> _validacao;
        public ClienteController(IRepositorioPessoa repositorio_pessoa, IValidator<Pessoa> validacao)
        {
            _repositorioPessoa = repositorio_pessoa;
            _validacao = validacao;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var pessoas = _repositorioPessoa.ObterTodasPessoas();

                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CriarPessoa([FromBody] Pessoa pessoa)
        {
            try 
            {
                _validacao.ValidateAndThrow(pessoa);
               
                _repositorioPessoa.CriarPessoa(pessoa);
                
                return Ok(pessoa.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult RemoverPessoa([FromRoute] int Id)
        {
            try 
            {
                if (_repositorioPessoa.ObterPessoaPorId(Id) != null)
                    _repositorioPessoa.RemoverPessoa(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Id);
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPessoaPorId([FromRoute] int Id)
        {
            try
            {
                var pessoa = _repositorioPessoa.ObterPessoaPorId(Id);
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarPessoa([FromRoute] int id, [FromBody] Pessoa pessoaAtualizada)
        {
            try
            {
                var pessoaValida = _validacao.Validate(pessoaAtualizada);

                if (pessoaAtualizada == null || !pessoaValida.IsValid || _repositorioPessoa.ObterPessoaPorId(id) == null)
                {
                    return BadRequest(pessoaValida.ToString());
                }
                pessoaAtualizada.Id = id;
                _repositorioPessoa.AtualizarPessoa(pessoaAtualizada);

                return Ok(pessoaAtualizada.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}