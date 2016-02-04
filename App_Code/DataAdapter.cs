using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DataAdapter
/// </summary>
public class DataAdapter
{
    private ConnectionStringSettings ConnectionString;
    SqlConnection sconn;
    SqlDataAdapter da;
    public DataAdapter()
    {
        //
        // TODO: Add constructor logic here
        //
        ConnectionStringSettings ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"];
        sconn = new SqlConnection(ConnectionString.ConnectionString);
        da = new SqlDataAdapter();
    }
    #region Private
    private void openConnection()
    {
        if (sconn == null)
        {
            sconn = new SqlConnection(ConnectionString.ConnectionString);
        }

        //todo: this can be replaced with newer construct to handle null
        if (sconn != null && sconn.State == ConnectionState.Closed)
        {
            sconn.Open();
        }
    }
    private void closeConnection()
    {
        this.sconn.Close();
    }

    #endregion
    #region Public

    public DataSet ExecuteSelectQuery(string query)
    {
        DataSet ds = new DataSet("ResultSet");
        openConnection();
        try
        {
            da.SelectCommand = new SqlCommand(query, sconn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
        }
        finally { this.closeConnection(); }
        return ds;
    }
    public void ExecuteInsertQuery(string query)
    {
        openConnection();
        try
        {
            da.InsertCommand = new SqlCommand(query, sconn);
            da.InsertCommand.ExecuteNonQuery();
        }
        catch(Exception ex) { }
        finally { this.closeConnection(); }
    }
    public void ExecuteUpdateQuery(string query)
    {
        openConnection();
        try
        {
            da.UpdateCommand = new SqlCommand(query, sconn);
            da.UpdateCommand.ExecuteNonQuery();
        }
        catch (Exception ex) { }
        finally { this.closeConnection(); }
    }
    public DataSet ExecuteStoredProcedure(string procedure, SqlParameter[] parameters)
    {
        DataSet ds = new DataSet();
        using (var command = new SqlCommand(procedure, sconn))
        {
            command.CommandType = CommandType.StoredProcedure;
            foreach(SqlParameter param in parameters)
            {
                command.Parameters.Add(param);
            }
            
            sconn.Open();
            da.SelectCommand = command;
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(ds);
            sconn.Close();
        }
        return ds;

    }

    #endregion

}