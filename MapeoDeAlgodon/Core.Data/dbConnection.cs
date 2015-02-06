using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Core.Data;

namespace Data
{
    public class dbConnection
    {
        public dbConnection()
        {
            myAdapter = new SqlDataAdapter();
            //conn = new SqlConnection(ResourceConnection.StringConnection2);
            conn = new SqlConnection(ResourceConnection.Local);           
        }       
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;
        //private string StringConnection = @"Data Source=uagrres00012\RIEGO;Initial Catalog=Visor2;Integrated Security=True";  
        //private string StringConnection = @"Data Source=SSO-PC\WINCC;Initial Catalog=Visor2;Integrated Security=True";  
        private SqlConnection openConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }

                return conn;
            }
            catch (Exception exp)
            {
                return null;
            }
        }
        public bool executeUpdateQuery(String _query, SqlParameter[] parameters)
        {
            SqlCommand myCommand = new SqlCommand();

            try
            {
                myCommand.CommandText = _query;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Connection = openConnection();
                myCommand.Parameters.AddRange(parameters);
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exp)
            {
                string msg = exp.Message;
                return false;
            }
            catch (ArgumentException ae)
            {
                string str = ae.Message;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return true;
        }
        public DataTable executeSelectQuery(string _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable datatable = new DataTable();
            //datatable = null;
            DataSet ds = new DataSet();

            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                if (sqlParameter != null)
                    myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                datatable = ds.Tables[0];
            }
            catch (SqlException Exp)
            {
                string m = Exp.Message;
            }
            finally
            {
            }
            return datatable;
        }
        public int executeDeleteQuery(String _query, SqlParameter[] sqlParameter) { 
                        
            SqlCommand myCommand = new SqlCommand();            
            try
            {
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                int Rows = myCommand.ExecuteNonQuery();
                return Rows;
            }
            catch (SqlException exp)
            {
                string ms = exp.Message;
                return 0;
            }
            catch (ArgumentException ae)
            {
                string str = ae.Message;
                return 0;
            }
            finally
            {
            }                    
        }
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exp)
            {
                string ms = exp.Message;
                return false;
            }
            catch (ArgumentException ae)
            {
                string str = ae.Message;
            }
            catch (Exception exp)
            {
                string ms = exp.Message;
            }
            finally
            {
            }
            return true;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
