using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace DataV2
{
    interface IRepositoryLote
    {
        List<Lote> SelectedLoteAll();
        Lote SelectedByLote(int id);
        void InsertLote(Lote lote);
        void UpdateLote(Lote lote);
        void DeleteLote(Lote lote);
    }
}
