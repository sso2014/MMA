using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace GUI
{
    interface IView
    {
        #region Loading
        void LoadCampos(List<Campo> campos);
        void LoadCampo(Campo campo);
        void LoadLotes(List<Lote> lotes);
        void LoadLote(Lote lote);
        void LoadPlantas(List<Planta> plantas);
        void LoadPlanta(Planta planta);
        void LoadNudos(List<Nudo>nudos);
        void LoadNudo(Nudo nudo);
        void LoadStates(List<State> states);
        void LoadSatate(Nudo state);
        #endregion
        #region Select
        Campo SelectedCampo { get; }
        Lote SelectedLote { get; }
        Planta SelectedPlanta { get; }
        Nudo SelectedNudo { get; }
        State SelectedState { get; }
        #endregion
        #region Event Action
        event Action CampoSelected;
        event Action LoteSelected;
        event Action PlantaSelected;
        event Action NudoSelected;
        event Action StateSelected;
        event Action NudoCreated;
        event Action Actualizar;
        event Action LoteCreated;
        #endregion
    }
}
