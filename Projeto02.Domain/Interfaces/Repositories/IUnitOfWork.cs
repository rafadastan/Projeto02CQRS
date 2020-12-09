using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories

        ITarefaRepository TarefaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }        

        #endregion

        #region Transactions

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion
    }
}
