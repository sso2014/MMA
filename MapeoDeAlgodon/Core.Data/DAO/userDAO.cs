using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Core.Data;

namespace Data.DAO
{
    class userDAO
    {
        public userDAO()
        {
            conn = new dbConnection();
        }
        public userDAO(Usuario usuario) {             
        }        
        private dbConnection conn = null;
        public DataTable getPlantas() {
            return conn.executeSelectQuery(Query.Read_all_Planta, null);
        }
        public void deleteNudo(int nudoId) { 

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@NUDOID", SqlDbType.Int);
            parameters[0].Value = nudoId;
            conn.executeDeleteQuery(Query.Delete_Nudo, parameters);
        }
        public void deleteNudoState(int nudoId) {

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@NUDOID", SqlDbType.Int);
            parameters[0].Value = nudoId;
            conn.executeDeleteQuery(Query.Delete_Nudo_State, parameters);
        }
        public DataTable selectedStateByNudoId(int nudoid) {

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@NUDOID", SqlDbType.Int);
            parameters[0].Value = nudoid;
            return conn.executeSelectQuery(Query.Read_State, parameters);
        }
        public void updateNudo(int NudoId, int State) {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@NUDOID", SqlDbType.Int);
            parameters[0].Value = NudoId;
            parameters[1] = new SqlParameter("@ESTADOID", SqlDbType.Int);
            parameters[1].Value = State;
            conn.executeUpdateQuery(Query.Update_Nudo, parameters);
        }
        public void insertIntoLote(string nombre, string campoid) { 

             SqlParameter [] parameters = new SqlParameter[2];
             parameters[0] = new SqlParameter("@NOMBRE",SqlDbType.NChar);
             parameters[0].Value = nombre;
             parameters[1] = new SqlParameter("@CAMPOID",SqlDbType.Int);
             parameters[1].Value = campoid;
             conn.executeInsertQuery(Query.Save_Lote, parameters);
        }
        public DataTable selectedUltimoNudo() {
           return conn.executeSelectQuery(Query.Ultimo_Nudo, null);
        }
        public DataTable getStateNudos()
        {
            return  conn.executeSelectQuery(Query.Read_All_Nudo_State, null);
        } 
        public void insertIntoPlanta(string code, int loteid)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@CODIGO", SqlDbType.NChar);
            parameters[0].Value = code;
            parameters[1] = new SqlParameter("@LOTEID", SqlDbType.Int);
            parameters[1].Value = loteid;
            conn.executeInsertQuery(Query.Save_Planta, parameters);
        }
        public void InsertEstado(string nudoID, DateTime fecha, string estadoid)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@NUDOID", SqlDbType.Int);
                parameters[0].Value = nudoID;
                parameters[1] = new SqlParameter("@FECHA", SqlDbType.SmallDateTime);
                parameters[1].Value = fecha;
                parameters[2] = new SqlParameter("@ESTADOID", SqlDbType.Int);
                parameters[2].Value = estadoid;
                conn.executeInsertQuery(Query.Save_Estado, parameters);
            }
            catch (Exception e) {
                string message = e.Message;
            }
        }
        public void insertIntoNudo(string PlantaID, string pos, DateTime fecha, int estadoId) {

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@PLANTAID", SqlDbType.Int);
            parameters[0].Value = PlantaID;
            parameters[1] = new SqlParameter("@POS", SqlDbType.NChar);
            parameters[1].Value = pos;
            parameters[2] = new SqlParameter("@FECHA", SqlDbType.DateTime);
            parameters[2].Value = fecha;
            //parameters[3] = new SqlParameter("@NUDOID", SqlDbType.Int);
            //parameters[3].Value = nudoId;
            parameters[3] = new SqlParameter("@ESTADOID", SqlDbType.Int);
            parameters[3].Value = estadoId;         
            conn.executeInsertQuery(Query.Save_Nudo2, parameters);
        }      
        public void insertIntoCampo(string Nombre, int Campo)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@nombre", SqlDbType.NChar);
            parameters[0].Value = Nombre;
            parameters[1] = new SqlParameter("@CampoID", SqlDbType.Int);
            parameters[1].Value = Nombre;
            conn.executeInsertQuery(Query.Save_Lote, parameters);
        }
        public DataTable getCampos() {
           return conn.executeSelectQuery(Query.Read_all_Campo, null);
        }
        public DataTable getNudos() {
            return conn.executeSelectQuery(Query.Read_all_Nudo, null);
        }
        public DataTable getlotes() {
            return conn.executeSelectQuery(Query.Read_all_Lote, null);
        }
    }
}