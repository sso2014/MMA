using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace MapeoDeAlgodon
{
    class Presentador
    {
        public Presentador(IView view, Repository repositorio)
        {
            this.view = view;
            this.repositorio = repositorio;

            this.view.CreatedLote += CreateLote;
            this.view.SelectedPlanta += OnSelectedPlanta;
            this.view.CreatedPlanta += OnCreatePlanta;
            this.view.SelectedLote += OnSelectedLote;
            this.view.SelectedNudo += SelectNudo;
            this.view.CreatedNudo += OnCreateNudo;

            this.view.LoadLotes(repositorio.Lotes());          
        }
        private IView view;
        private Repository repositorio;
        void SelectNudo()
        {
            view.LoadNudo(view.SelectNudo);
            //view.LoadNudos()
        }
        void CreateLote()
        {
            repositorio.InsertLote(this.view.CreateLote);
            view.LoadLotes(repositorio.Lotes());
        }
        private void OnSelectedLote()
        {
            this.view.LoadLote(this.view.SelectLote);
        }
        private void OnCreateNudo()
        {
            if (this.view.CreateNudo != null)
            {
                this.repositorio.InsertNudo(view.CreateNudo);
                //this.view.LoadLotes(repositorio.Lotes());
            }
        }
        private void OnSelectedPlanta()
        {
            if (view.SelectPlanta != null)
            {
                view.LoadPlanta(repositorio.GetPlantaById(view.SelectPlanta.Id));
            }
        }
        private void OnCreatePlanta()
        {
            repositorio.InsertPlanta(view.CreatePlanta);
            view.LoadLotes(repositorio.Lotes());
        }
    }
}