using AlunosAPI.Models;
using AlunosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunosService _alunoService;

        public AlunosController(IAlunosService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByNome([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                if (alunos == null)
                    return NotFound($"Não existe alunos com o critério {nome}");

                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno == null)
                    return NotFound($"Não existe aluno com o id =  {id}");

                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {

            try

            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido");

            }
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {

            try
            {
                if(aluno.Id== id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Foi atualizado o aluno {id}");

                }
                else
                {
                    return BadRequest("Dados incorretos");
                }
            }
            catch
            {
                return BadRequest("Request inválido");

            }
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                            
                var aluno = await _alunoService.GetAluno(id);

                if (aluno.Id != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Foi Excluido o aluno {id}");

                }
                else
                {
                    return NotFound("Dados incorretos, aluno não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido");

            }
        }
    }
}
