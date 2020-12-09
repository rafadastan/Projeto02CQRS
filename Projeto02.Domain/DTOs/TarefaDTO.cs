using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.DTOs
{
    public class TarefaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeSpan HoraFim { get; set; }

        public UsuarioDTO Usuario { get; set; }
    }
}
