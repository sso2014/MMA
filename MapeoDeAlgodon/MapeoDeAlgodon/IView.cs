using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace MapeoDeAlgodon
{
    interface IView
    {
        event Action CreatedLote;
        event Action SelectedLote;
        event Action CreatedPlanta;
        event Action SelectedPlanta;
        event Action CreatedNudo;
        event Action SelectedNudo;
     

        Planta SelectPlanta { get; }
        Lote CreateLote { get; }
        Planta CreatePlanta { get; }
        Core.Data.Nudo CreateNudo { get; }
        Planta SelectNewPlanta { get; }
        void LoadPlanta(Planta p);
        void LoadLotes(IList<Lote> lotes);
        void LoadLote(Lote lote);
        void LoadPlantas(List<Planta> plantas);
        void LoadNudo(Core.Data.Nudo nudo);
        void LoadNudos(List<Core.Data.Nudo> nudos);
        Core.Data.Nudo SelectNudo { get; }
        Lote SelectLote { get; }
    }
}
