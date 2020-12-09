using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Entities
{
    public class UsuarioEntity
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        #endregion

        #region Navigations

        public ICollection<TarefaEntity> Tarefas { get; set; }

        #endregion
    }
}
