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
        public Point point { get; set; }
        public Size size { get; set; }
        public int Id { get; set; }
        public string Pos { get; set; }
        public string plantaID{get;set;}      
        public override string ToString()
        {
            return this.Id.ToString();
        }

        public delegate void NudoHandler(object obj, EventArgs e);
        public event NudoHandler FocoEvent;

        public void OnFoco(int X, int Y)
        {
            if (X >= this.point.X && X <= (this.point.X + this.size.Width) && Y >= this.point.Y && Y <= (this.point.Y + this.size.Height))
            {

                this.trigger(null);
            }
        }       
        private void trigger(EventArgs e) {
            if (this.FocoEvent != null)
            {
                this.FocoEvent(this, e);
            }            
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
