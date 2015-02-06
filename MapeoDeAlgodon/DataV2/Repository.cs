using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;
using Data;


namespace DataV2
{
    public  class Repository:BaseRepository, IRepositoryState, IRepositoryNudo, IRepositoryPlanta, IRepositoryLote, IRepositoryCampo
    {
        public Repository() {
            CreateLists();
        }
        private void CreateLists()
        {
            nudoList = db.GetNudos();
            plantaList = db.GetPlantas();
            loteList = db.GetLotes();
            stateList = db.GetState();
        }

        private List<State> stateList;
        private List<Nudo> nudoList;
        private List<Planta> plantaList;
        private List<Lote> loteList;
        private List<Campo> campoList;
        private List<Lote> GetLoteList()
        {
            if (loteList == null)
                CreateLists();
            return loteList;
        }
        private List<Planta> GetPlantaList()
        {
            if (plantaList == null)
                CreateLists();
            return plantaList;
        }
        private List<Nudo> GetNudoList()
        {
            if (nudoList == null)
                CreateLists();
            return nudoList;
        }
        private List<State> GetStateList()
        {
            if (stateList == null)
                CreateLists();
            return stateList;
        }
        //private List<Campo> GetStateList()
        //{
        //    if (campoList == null)
        //        CreateLists();
        //    return campoList;
        //}     

        #region interface repository State
        public List<State> SelectedStateAll()
        {
            return this.GetStateList().ToList();
        }
        public State SelectedByState(int id)
        {
            throw new NotImplementedException();
        }
        public void InsertState(State state)
        {
            throw new NotImplementedException();
        }
        public Lote GetUltimoLote()
        {
            return db.SelectUltimoLote();
        }

        public Nudo GetUltimoNudo()
        {
            return db.SelectUltimoNudo();
        }
        public void UpdateState(State state)
        {
            throw new NotImplementedException();
        }

        public void DeleteState(State state)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region interface repository Nudo
        public List<Core.Data.Nudo> SelectedNudoAll()
        {

           return db.GetNudos();

         //   return nudoList.ToList();
         //   List<Nudo> nudos = GetNudoList();
         //   List<State> estados = GetStateList();

         //   var nudoStateQuery =
         //       from n in nudoList
         //       join s in stateList on n.Id equals s.NudoID into ns
         //       select new { Key = n.Id, Estado = ns };

         //foreach(Nudo n in nudos){
         //    n.Estado = new List<State>();
         //    foreach (var item in nudoStateQuery)
         //    {
         //        if (n.Id == item.Key)
         //        {
         //            n.Estado.Add(item.Estado);
         //        }
         //    }
        

        }
        public Core.Data.Nudo SelectedByNudo(int id)
        {
 	        throw new NotImplementedException();
        }
        public void InsertNudo(Core.Data.Nudo nudo)
        {
            if (nudo != null)
            {
                if (nudo.Id == 0)
                {
                    db.InsertNudo(nudo);
                    Nudo n = db.SelectUltimoNudo();
                    nudoList.Add(n);
                    foreach (State s in nudo.Estado)
                    {
                        stateList.Add(s);
                    }
                }
            }
        }
        public void UpdateNudo(Core.Data.Nudo nudo)
        {
 	        throw new NotImplementedException();
        }
        public void DeleteNudo(Core.Data.Nudo nudo)
        {
 	        throw new NotImplementedException();
        }
        #endregion
        #region interface repository Planta
        public List<Core.Data.Planta> SelectedPlantaAll()
        {
            return db.GetPlantas().ToList();
        }
        public Core.Data.Planta SelectedByPlanta(int id)
        {
            Planta planta = this.plantaList.Find(p => p.Id == id.ToString());

            List<Core.Data.Nudo>nudos = db.GetNudos().FindAll(n => n.plantaID == planta.Id);

            List<State> estados = db.GetState();

            planta.Nudo = nudos;

            foreach(Nudo n in planta.Nudo){
                n.Estado = new List<State>();

                foreach (State s in estados)
                {
                    if (n.Id == s.NudoID)
                    {
                        n.Estado.Add(s);
                    }
                }
            }

            return planta;

        }
        public void InsertPlanta(Core.Data.Planta planta)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlanta(Core.Data.Planta planta)
        {
            throw new NotImplementedException();
        }

        public void DeletePlanta(Core.Data.Planta planta)
        {
            throw new NotImplementedException();
        }
        #endregion      
        #region interface repository Lote
        public List<Lote> SelectedLoteAll()
        {
            return loteList.ToList();
        }
        public Lote SelectedByLote(int id)
        {
            return loteList.Find(l => l.LoteID == id.ToString());
        }
        public void InsertLote(Lote lote)
        {
            db.InsertLote(lote);
            this.loteList.Add(db.SelectUltimoLote());

        }
        public void UpdateLote(Lote lote)
        {
           
        }
        public void DeleteLote(Lote lote)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region interface repository Campo
        public List<Campo> SelectedCampoAll()
        {
           return  db.GetCampos().ToList();
        }
        public Core.Data.Campo SelectedByCampo(int id)
        {
           return campoList.Find(c => c.Id == id.ToString());
        }
        public void InsertCampo(Campo campo)
        {
            db.InsertIntoCampo(campo);
        }
        public void UpdateCampo(Campo campo)
        {
            db.UpdateCampo(campo);
        }
        public void DeleteCampo(Campo campo)
        {
            db.DeleteCampo(campo);
        }
        #endregion
    }
}
