using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class BaseLote
    {
        public string  LoteID { get; set; }
        public string Nombre { get; set; }
        public string CampoId { get; set; }
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
