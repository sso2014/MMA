using System;
namespace MapeoDeAlgodon
{
    interface IMain
    {
        event Action CreatedLote;
        event Action CreatedNudo;
        event Action CreatedPlanta;
        Core.Data.Lote CreateLote { get; }
        Core.Data.Planta CreatePlanta { get; }
        void LoadLote(Core.Data.Lote lote);
        void LoadLotes(System.Collections.Generic.IList<Core.Data.Lote> lotes);
        void LoadNudo(Core.Data.Nudo nudo);
        void LoadNudos(System.Collections.Generic.List<Core.Data.Nudo> nudos);
        void LoadPlanta(Core.Data.Planta p);
        void LoadPlantas(System.Collections.Generic.List<Core.Data.Planta> plantas);
        event Action SelectedLote;
        event Action SelectedNudo;
        event Action SelectedPlanta;
        Core.Data.Lote SelectLote { get; }
        Core.Data.Nudo SelectNudo { get; }
        Core.Data.Planta SelectPlanta { get; }
    }
}
