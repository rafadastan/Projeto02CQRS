using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Exceptions
{
    public class EmailDeveSerUnicoException : Exception
    {
        private readonly string email;

        public EmailDeveSerUnicoException(string email)
        {
            this.email = email;
        }

        //sobrescrita do método Exception.Message
        public override string Message 
            => $"O email '{email}' informado já encontra-se cadastrado.";
    }
}
