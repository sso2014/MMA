using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data
{
    public class State
    {
        public int Id { get; set; }
        public int StateID { get; set; }
        public int NudoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Convert.ToDateTime(this.Fecha).ToLongDateString() + " " + this.Descripcion;
        }
    }
}
