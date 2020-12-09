using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.MongoDB.Settings
{
    public class MongoDBSettings
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
