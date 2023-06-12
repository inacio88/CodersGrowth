using Dominio;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
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
                var pessoaValida = _validacao.Validate(pessoa);
               
                if (pessoa == null || !pessoaValida.IsValid) 
                {
                    return BadRequest(pessoaValida.ToString()); 
                }
               
                _repositorioPessoa.CriarPessoa(pessoa);
                
                return Created($"{pessoa.Id}", pessoa);
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
                {
                    _repositorioPessoa.RemoverPessoa(Id);
                }
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
                return Ok(_repositorioPessoa.ObterPessoaPorId(Id));
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

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}