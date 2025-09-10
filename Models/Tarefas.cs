using System.Reflection.Metadata;

namespace Aula02_09.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public required string Descricao {  get; set; }
        public required DateOnly DtInicio { get; set; }
        public required DateOnly DtFechamento {  get; set; }
        public string Situacao { get; set; } = "Aberta";

    }
}
