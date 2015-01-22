using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class BaseCampo
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return this.Nombre;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
