using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataV2;
using Core.Data;

namespace GUI
{
    class Presentador
    {
        public Presentador(IView view, Repository repository)
        {

            this.view = view;
            this.repository = repository;

            view.CampoSelected += SelectedCampo;
            view.PlantaSelected += SelectedPlanta;
            view.NudoSelected += SelectedNudo;
            view.NudoCreated += CreatedNudo;
            view.Actualizar+=Actualizar;
            view.LoteCreated += CreateLote;

            view.LoadCampos(repository.SelectedCampoAll());
            view.LoadLotes(repository.SelectedLoteAll());            
        }
        private IView view;
        private Repository repository;
        private void SelectedCampo()
        {           

            Campo campo = view.SelectedCampo;

            List<Lote> lotes = repository.SelectedLoteAll()
              .FindAll(l => l.CampoId == campo.Id);

            foreach (Lote l in lotes)
            {
                l.Plantas = new List<Planta>();

                foreach (Planta p in repository.SelectedPlantaAll())
                {
                    if (l.LoteID == p.LoteID)
                    {
                        l.Plantas.Add(p);
                    }
                }
            }

            view.LoadLotes(lotes);
          

        }
        private void CreateLote()
        {
            repository.InsertLote(view.SelectedLote);
            view.LoadLotes(repository.SelectedLoteAll());
        }
        private void Actualizar()
        {
            view.LoadLotes(repository.SelectedLoteAll()); 
        }
        private void CreatedNudo()
        {
            Nudo n = view.SelectedNudo;
            repository.InsertNudo(n);
            view.LoadPlanta(repository.SelectedByPlanta(Convert.ToInt32(n.plantaID)));
        }
        private void SelectedPlanta()
        {                     
            Planta planta = view.SelectedPlanta;
            if (planta !=null)
            view.LoadPlanta(repository.SelectedByPlanta(Convert.ToInt32(planta.Id)));
        }
        private void SelectedNudo()
        {
            Nudo n  = view.SelectedNudo;

            if (n != null)
            {               
                n.Estado = new List<State>();

                List<State> estados = this.repository.SelectedStateAll().FindAll(s => s.NudoID == n.Id);

                foreach (State s in estados)
                {
                    n.Estado.Add(s);
                }
            }
            //view.LoadStates(n.Estado);
            view.LoadNudo(n);
        }
    }
}