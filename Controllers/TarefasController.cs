using Aula02_09.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aula02_09.Models.DTOs;
using Aula02_09.Models;

namespace Aula02_09.Controllers
{
    [Route("/")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private static List<Tarefas> lsTarefas = new List<Tarefas> 
        {
            new Tarefas(){Id = 1, Descricao = "Estudar APIs", DtInicio = new DateOnly(2025, 09, 02),
            DtFechamento = new DateOnly(2025, 09, 03)}
        };

        private static int nextId = 2;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(lsTarefas);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            var tarefa = lsTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }


        [HttpPost("/cadastro")]
        public IActionResult Cadastro([FromBody] TarefaDto novaTarefa)
        {
            var tarefa = new Tarefas() { Descricao = novaTarefa.Descricao, DtInicio = novaTarefa.DtInicio, DtFechamento = novaTarefa.DtFechamento }; 

            tarefa.Id = nextId++;
            tarefa.Situacao = "Aberta";
           

            lsTarefas.Add(tarefa);

            return Created("", lsTarefas);
        }

        [HttpDelete("/delete/{id}/delete-tarefa")]
        public IActionResult Remover(int id)
        {
            var tarefa = lsTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }
            lsTarefas.Remove(tarefa);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] TarefaDto novaTarefa)
        {
            var tarefa = lsTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Descricao = novaTarefa.Descricao;
            tarefa.DtInicio = novaTarefa.DtInicio;
            tarefa.DtFechamento = novaTarefa.DtFechamento;

            return Ok(tarefa);
        }

        [HttpPut("{id}/fechar")]
        public IActionResult Fechar(int id)
        {

            var tarefa = lsTarefas.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Situacao = "Fechada";

            return Ok(tarefa);

        }

    }
}
