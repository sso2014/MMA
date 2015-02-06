using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapeoDeAlgodon
{
    interface IViewPlanta
    {
        event Action PlantaSelected;
        List<Core.Data.Planta> SelectedPlantas { get; }
        Core.Data.Planta SelectedPlanta { get; }
        void LoadPlanta(Core.Data.Planta planta);
        void LoadPlantas(List<Core.Data.Planta> planta);
    }
}
