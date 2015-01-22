using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class BasePlanta:IDisposable
    {
        public BasePlanta() { 
        }
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string LoteID { get; set; }
        public override string ToString()
        {
            return this.Codigo;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
