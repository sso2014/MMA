using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace DataV2
{
    interface IRepositoryPlanta
    {
        List<Planta> SelectedPlantaAll();
        Planta SelectedByPlanta(int id);
        void InsertPlanta(Planta planta);
        void UpdatePlanta(Planta planta);
        void DeletePlanta(Planta planta);
    }
}
