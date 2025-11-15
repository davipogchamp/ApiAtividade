using Microsoft.AspNetCore.Mvc;
using Modelo.Application.Interfaces;
using Modelo.Domain;

namespace ApiAtividade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplication _alunoApplication;
        public AlunoController(IAlunoApplication alunoApplication)
        {
            _alunoApplication = alunoApplication;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarDadosAlunoID(int id)
        {
            var aluno = await _alunoApplication.BuscarDadosAlunoID(id);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }
            return Ok(aluno);
        }
        [HttpPost]
        public async Task<IActionResult> InserirAluno([FromBody] Aluno aluno)
        {
            var resultado = await _alunoApplication.InserirAluno(aluno);
            return Ok(resultado);
        }
        [HttpPut]
        public async Task<IActionResult> EditarAluno([FromBody] Aluno aluno)
        {
            var resultado = await _alunoApplication.EditarAluno(aluno);
            return Ok(resultado);
        }
        [HttpDelete]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            var resultado = await _alunoApplication.ExcluirAluno(id);
            return Ok(resultado);
        }
    }
}
