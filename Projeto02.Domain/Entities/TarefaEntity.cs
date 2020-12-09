using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Entities
{
    public class TarefaEntity
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeSpan HoraFim { get; set; }
        public Guid UsuarioId { get; set; }

        #endregion

        #region Navigations

        public UsuarioEntity Usuario { get; set; }

        #endregion
    }
}
