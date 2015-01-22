using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class BaseUsuario:IDisposable
    {
        public BaseUsuario() { 
        }
        public string UsuarioID { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
