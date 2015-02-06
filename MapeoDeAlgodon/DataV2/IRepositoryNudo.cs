using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace DataV2
{
    interface IRepositoryNudo
    {
        List<Nudo> SelectedNudoAll();
        Nudo SelectedByNudo(int id);
        void InsertNudo(Nudo nudo);
        void UpdateNudo(Nudo nudo);
        void DeleteNudo(Nudo nudo);
    }
}
