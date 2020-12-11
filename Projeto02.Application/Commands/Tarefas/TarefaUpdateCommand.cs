using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto02.Application.Commands.Tarefas
{
    public class TarefaUpdateCommand : IRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id da tarefa.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de inicio da tarefa.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe a hora de início da tarefa.")]
        public string HoraInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de término da tarefa.")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Por favor, informe a hora de término da tarefa.")]
        public string HoraFim { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do usuário.")]
        public Guid UsuarioId { get; set; }
    }
}
