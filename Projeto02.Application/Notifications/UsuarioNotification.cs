using MediatR;
using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Notifications
{
    public class UsuarioNotification : INotification
    {
        public UsuarioEntity Usuario { get; set; } //dados
        public ActionNotification Action { get; set; } //ação
    }
}
