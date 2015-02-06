using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core.Data;

namespace Data.BUS
{
   public  class UserBUS
    {
        public UserBUS()
        {
            dao = new DAO.userDAO();
        }
        private DAO.userDAO dao;

        public void DeleteNudoState(Nudo n) {
            dao.deleteNudoState(n.Id);
        }
        public Lote SelectUltimoLote()
        {
            Lote lote = null;
            foreach(DataRow dr in dao.getUltimoLote().Rows){
                lote = new Lote()
                {
                    LoteID = dr["LOTEID"].ToString(),
                    Nombre = dr["NOMBRE"].ToString(),
                    CampoId = dr["CAMPOID"].ToString()
                };
            }
            return lote;
            
        }

        public void InsertPlanta(Planta planta)
        {
            if (planta != null)
            {
                dao.insertIntoPlanta(planta.Codigo, Convert.ToInt32(planta.LoteID));
            }
        }
        public void DeleteNudo(Nudo nudo) {
            dao.deleteNudo(nudo.Id);   
        }
        public void InsertIntoCampo(Campo campo) { 
        }
        public void UpdateCampo(Campo campo) { 
        
        }
        public void DeleteCampo(Campo campo) { 
            
        }
        public void UpdateNudo(Nudo nudo) {
            if (nudo != null)
            {
                //DateTime t = nudo.Estado[0].Fecha;
                //dao.updateNudo(nudo.Id, nudo.Estado[0].StateID);   
                dao.InsertEstado(nudo.Id.ToString(),
                    nudo.Estado[nudo.Estado.Count - 1].Fecha,
                    nudo.Estado[nudo.Estado.Count - 1].StateID.ToString());
            }
        }
        public void InsertNudo(Nudo nudo)    {  

            if (nudo != null)
            {
                dao.insertIntoNudo(nudo.plantaID, nudo.Pos,nudo.Estado[0].Fecha, nudo.Estado[0].StateID);
                //dao.InsertEstado(this.GetUltimoNudo().ToString(), nudo.Estado[nudo.Estado.Count-1].StateID.ToString());
             
            }
        }
        public List<State> GetStateByNudoId(Nudo nudo)
        {

            List<State> estados = new List<State>();

            foreach (DataRow dr in dao.selectedStateByNudoId(nudo.Id).Rows)
            {

                estados.Add(new State()
                {
                    Id = (int)dr["NUDOSTATEID"],
                    NudoID = (int)dr["NUDOID"],
                    Fecha = (DateTime)dr["FECHA"],
                    StateID = (int)dr["ESTADOID"]
                });
            }
            return estados;
        }
        public void InsertLote(Lote lote)
        {
            dao.insertIntoLote(lote.Nombre, lote.CampoId);
        }
        public List<Planta> GetPlantas()
        {
            List<Planta> plantas = new List<Planta>();
            foreach (DataRow dr in dao.getPlantas().Rows)
            {
                plantas.Add(new Planta()
                {
                    Id = dr["PLANTAID"].ToString(),
                    Codigo = dr["CODIGO"].ToString(),
                    LoteID = dr["LOTEID"].ToString(),
                    Nudo = new List<Nudo>()
                });
            }
            return plantas;
        }
        public Nudo SelectUltimoNudo()
        {
            Nudo nudo = null;
            foreach (DataRow dr in this.dao.getUltimoNudoAndState().Rows)
            {
                if (nudo == null)
                {
                    nudo = new Nudo()
                    {
                        Id = Convert.ToInt32(dr["NUDOID"]),
                        plantaID = dr["PLANTAID"].ToString(),
                        Pos = dr["POS"].ToString(),
                        Estado = new List<State>(){
                            new State(){
                                NudoID = Convert.ToInt32(dr["NUDOID"]),
                                Fecha = Convert.ToDateTime(dr["fecha"]),
                                StateID = Convert.ToInt32(dr["ESTADOID"]),
                                Descripcion = dr["DESCRIPCION"].ToString()
                            }
                        }
                    };
                }
                else
                {
                    nudo.Estado.Add(new State()
                    {
                        NudoID = Convert.ToInt32(dr["NUDOID"]),
                        Fecha = Convert.ToDateTime(dr["fecha"]),
                        StateID = Convert.ToInt32(dr["ESTADOID"]),
                        Descripcion = dr["DESCRIPCION"].ToString()
                    });
                }
            }

            return nudo;
        }        
        public List<Nudo> GetNudos()
        {
            List<Nudo> nudos = new List<Nudo>();
            foreach (DataRow dr in dao.getNudos().Rows)
            {
                nudos.Add(new Nudo()
                {
                    Id = Convert.ToInt32(dr["NUDOID"]),
                    plantaID = dr["PLANTAID"].ToString(),
                    Pos = dr["POS"].ToString(),
                    //Estado = new List<State>()         
                
                });
            }
            return nudos;
        }
        public List<State> GetState()
        {
            List<State> estados = new List<State>();
            foreach(DataRow dr in dao.getStateNudos().Rows){
                estados.Add(new State()
                {
                    Id = (int)(dr["NUDOSTATEID"]),
                    Fecha = (DateTime)(dr["FECHA"]),
                    NudoID = (int)dr["NUDOID"],
                    Descripcion = (string)dr["DESCRIPCION"],
                    StateID = (int)dr["ESTADOID"]
                });  
            }
            return estados;
        }
        public List<Lote> GetLotes()
        {
            List<Lote> lotes = new List<Lote>();
            foreach (DataRow dr in dao.getlotes().Rows)
            {
                lotes.Add(
                    new Lote()
                    {
                        LoteID = dr["LOTEID"].ToString(),
                        CampoId = dr["CAMPOID"].ToString(),
                        Nombre = dr["NOMBRE"].ToString(),
                        Plantas = new List<Planta>()
                    });
            }
            return lotes;
        }
        public int GetUltimoNudo() {
              DataRow dr = dao.selectedUltimoNudo().Rows[0];
              return Convert.ToInt32(dr["ULTIMO_NUDO"]);
        }      
        public List<Campo> GetCampos()
        {
            List<Campo> campos = new List<Campo>();
            foreach (DataRow dr in dao.getCampos().Rows)
            {
                campos.Add(new Campo()
                {
                    Id = dr["CAMPOID"].ToString(),
                    Nombre = dr["NOMBRE"].ToString()
                });
            }
            return campos;
        }
        public void SetUsuario(Usuario usuario)
        {
            string StringConnection =
                @"Data Source=TELEMETRIA\WINCC;Initial Catalog=AGRICULTURA;User ID=" + usuario.Nombre + ";Password=" + usuario.Pasword;
        }
    }
}