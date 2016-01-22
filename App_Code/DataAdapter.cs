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
        if(sconn==null)
        {
            sconn = new SqlConnection(ConnectionString.ConnectionString);
        }

        //todo: this can be replaced with newer construct to handle null
        if(sconn!= null && sconn.State == ConnectionState.Closed)
        {
            sconn.Open();
        }
    }
    private void closeConnection()
    {
        this.sconn.Close();
    }
    private string escapeSpecialCharacter(string query)
    {
        return query.Replace("'", "''");
    }
    #endregion
    #region Public

    public DataSet ExecuteSelectQuery(string query)
    {
        query = escapeSpecialCharacter(query);
        DataSet ds = new DataSet("ResultSet");
        openConnection();
        try
        {
            da.SelectCommand = new SqlCommand(query, sconn);
            da.SelectCommand.ExecuteNonQuery();
            da.Fill(ds);
        }
        catch(Exception ex) { }
        finally { this.closeConnection();}
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
        catch { }
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
        catch { }
        finally { this.closeConnection(); }
    }

    #endregion

}