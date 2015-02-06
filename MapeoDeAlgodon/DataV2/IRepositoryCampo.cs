using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace DataV2
{
    interface IRepositoryCampo
    {
        List<Campo> SelectedCampoAll();
        Campo SelectedByCampo(int id);
        void InsertCampo(Campo campo);
        void UpdateCampo(Campo campo);
        void DeleteCampo(Campo campo);
    }
}
