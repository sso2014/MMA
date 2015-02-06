using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    class Client
    {
        public void LoadGroups() {
         
        }
        private DrawableFactory f = new DrawableFactory();
   
        private Data.BUS.UserBUS db = new Data.BUS.UserBUS();
        public void PaintPlanta(object sender, PaintEventArgs e){
            foreach(Core.Data.Nudo n in db.GetNudos()){
                 f[0].Display(e.Graphics, n);              
            }
        }
    }
}
