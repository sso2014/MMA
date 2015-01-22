using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    public class BaseNudo:IDisposable
    {
        public BaseNudo() { 
        }
        public int Id { get; set; }
        public string Pos { get; set; }
        public string plantaID{get;set;}      
        public override string ToString()
        {
            return this.Id.ToString();
        }
        public bool Dead
        {
            get;
            set;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
