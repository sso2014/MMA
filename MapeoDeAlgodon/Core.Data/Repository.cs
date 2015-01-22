using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;

namespace Data
{
    public class Repository : BaseRepository
    {
        private List<Lote> loteList;
        private List<Planta> plantaList;
        private List<Nudo> nudoList;
        private List<State> stateList;
        public List<Lote> GetLoteList()
        {
            if (loteList == null)
                CreateLists();
            return loteList;
        }
        public List<Planta> GetPlantaList()
        {
            if (plantaList == null)
                CreateLists();
            return plantaList;
        }
        public List<Nudo> GetNudoList()
        {
            if (nudoList == null)
                CreateLists();
            return nudoList;
        }
        public List<State> GetStateList()
        {
            if (stateList == null)
                CreateLists();
            return stateList;
        }
        public List<Lote> Lotes()
        {

            CreateLists();

            foreach (Lote l in loteList)
            {
                foreach (Planta p in plantaList)
                {
                    if (l.LoteID == p.LoteID)
                    {
                        if (l.Plantas == null)
                            l.Plantas = new List<Planta>();
                        l.Plantas.Add(p);
                        foreach (Nudo n in nudoList)
                        {
                            if (p.Id == n.plantaID)
                            {
                                if (p.Nudo == null)
                                    p.Nudo = new List<Nudo>();
                                p.Nudo.Add(n);
                                foreach (State s in stateList)
                                {
                                    if (n.Id == s.NudoID)
                                    {
                                        n.Estado.Add(s);
                                    }
                                }
                            }
                            //foreach (State s in stateList)
                            //{
                            //    if (n.Id == s.NudoID)
                            //    {
                            //        n.Estado.Add(s);
                            //    }
                            //}
                        }
                    }
                }
            }
            return this.loteList;
        }
        private void CreateLists()
        {
            nudoList = db.GetNudos();
            plantaList = db.GetPlantas();
            loteList = db.GetLotes();
            stateList = db.GetState();
        }
        public void InsertLote(Lote lote)
        {
            db.InsertLote(lote);
            loteList.Add(lote);
        }
        public Planta GetPlantaById(string id)
        {
            return plantaList.Find(p => p.Id == id);
        }
        public Nudo GetNudoById(int id)
        {
            return nudoList.Find(n => n.Id == id);
        }
        public void UpdateNudo(Nudo nudo)
        {
            db.UpdateNudo(nudo);
        }
        public List<Nudo> SelectNudoAll()
        {

            nudoList = db.GetNudos().ToList();

            List<State> estados = db.GetState();

            for (int i = 0; i < nudoList.Count; i++)
            {
                foreach (State s in estados)
                {
                    if (s.NudoID == nudoList[i].Id)
                    {

                        nudoList[i].Estado[0] = s;
                    }
                }
            }
            return nudoList;
        }
        public void InsertPlanta(Planta planta)
        {
            db.InsertPlanta(planta);
            foreach (Lote l in loteList)
            {
                if (planta.LoteID == l.LoteID)
                {
                    l.Plantas.Add(planta);
                }
            }

        }
        public void InsertNudo(Nudo nudo)
        {
            if (nudo != null)
            {
                if (nudo.Dead)
                {
                    db.DeleteNudo(nudo);
                    db.DeleteNudoState(nudo);
                }
                else
                {
                    if (nudo != null)
                    {
                        #region Old Code!
                        // * la lista contiene aun los objetos antiguos 
                        //*/
                        //bool nuevo = true;
                        //if (Nudos != null ){
                        //}
                        //        if (nudo != null)
                        //        {
                        //            for(int i= 0; i < Nudos.Count;i++){
                        //                if (nudo.Id == Nudos[i].Id) {
                        //                    db.UpdateNudo(nudo);
                        //                    nuevo = false;
                        //                } 
                        //         }   
                        //        if (nuevo)
                        //        {
                        //            db.InsertNudo(nudo);
                        //            int id = db.GetUltimoNudo();
                        //            nudo.Id = id;
                        //            nudo.Estado.NudoID = id;
                        //            db.InsertNodoState(nudo);
                        //        }
                        //    }                 /*err:
                        #endregion
                        if (nudo.Id == 0)
                        {
                            db.InsertNudo(nudo);
                            nudo.Id = db.GetUltimoNudo();
                            nudoList.Add(nudo);
                            nudo.Estado = db.GetStateByNudoId(nudo);
                            #region Old Core!
                            //var rl = from l in this.loteList
                            //         join p in plantaList on
                            //         l.LoteID equals p.LoteID
                            //         join n in nudoList on
                            //         p.Id equals n.plantaID
                            //         join s in stateList on
                            //         n.Id equals s.NudoID
                            //         select new
                            //         {
                            //             NudoKey = n.Id,
                            //             estads = s
                            //         };              

                            #endregion

                        }
                        else
                        {
                            db.UpdateNudo(nudo);
                            List<State> s = db.GetStateByNudoId(nudo);
                            foreach (Nudo n in nudoList)
                            {
                                if (nudo.Id == n.Id)
                                {
                                    n.Estado = s;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}