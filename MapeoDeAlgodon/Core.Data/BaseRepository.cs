using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BaseRepository
    {
        public BaseRepository()
        {
            db = new BUS.UserBUS();
        }
        internal BUS.UserBUS db = null;
    }
}
