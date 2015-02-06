using System;
namespace Data
{
    interface IRepository
    {
        System.Collections.Generic.List<Core.Data.Lote> GetLoteList();
        Core.Data.Nudo GetNudoById(int id);
        System.Collections.Generic.List<Core.Data.Nudo> GetNudoList();
        Core.Data.Planta GetPlantaById(string id);
        System.Collections.Generic.List<Core.Data.Planta> GetPlantaList();
        System.Collections.Generic.List<Core.Data.State> GetStateList();
        void InsertLote(Core.Data.Lote lote);
        void InsertNudo(Core.Data.Nudo nudo);
        void InsertPlanta(Core.Data.Planta planta);
        System.Collections.Generic.List<Core.Data.Lote> Lotes();
        System.Collections.Generic.List<Core.Data.Nudo> SelectNudoAll();
        void UpdateNudo(Core.Data.Nudo nudo);
    }
}
