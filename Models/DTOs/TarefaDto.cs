namespace Aula02_09.Models.DTOs
{
    public class TarefaDto
    {
        public required string Descricao { get; set; }
        public required DateOnly DtInicio { get; set; }
        public required DateOnly DtFechamento { get; set; }

    }
}
