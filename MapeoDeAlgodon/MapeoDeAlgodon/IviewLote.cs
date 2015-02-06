using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapeoDeAlgodon
{
    interface IviewLote
    {
        event Action LoteSelected;
        List<Core.Data.Planta> Selectedlotes { get; }
        Core.Data.Planta SelectedLote { get; }
        void LoadLote(Core.Data.Planta lote);
        void LoadLotes(List<Core.Data.Planta> lotes);
    }
}
