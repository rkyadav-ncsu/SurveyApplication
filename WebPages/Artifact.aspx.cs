using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPages_Artifact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long id = Request.QueryString["id"] == null ? 0 : Convert.ToInt64(Request.QueryString["id"]);
        if (id != 0)
        {
            string url = readArtifact(id).Rows[0]["ArtifactText"].ToString();
            i_wiki.Attributes.Add("src", url);
            lv_Reviews.DataSource = getReviewStatus(id);
            lv_Reviews.DataKeyNames = new string[] { "ReviewRefId" };
            lv_Reviews.DataBind();

        }
    }

    /// <summary>
    /// get all the reviews for artifact
    /// </summary>
    /// <param name="id"></param>
    private DataTable getReviewStatus(long id)
    {
        DataTable dt = new DataTable();

        try
        {
            DataAdapter dataAdapter = new DataAdapter();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            //sqlParameter[0] = new SqlParameter("@userId", Session["UserToken"]);
            sqlParameter[0] = new SqlParameter("@artifactId", id);
            DataSet ds = dataAdapter.ExecuteStoredProcedure("usp_getTopRatedReviews", sqlParameter);
            dt = ds.Tables[0];
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    private DataTable getReviews(long reviewRefId)
    {
        DataAdapter dataAdapter = new DataAdapter();

        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0]=new SqlParameter("@reviewRefId", reviewRefId);
        DataSet ds = dataAdapter.ExecuteStoredProcedure("sp_GetReviewDetails", parameters);
        return ds.Tables[0];
    }
    private DataTable readArtifact(long id)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds = dataAdapter.ExecuteSelectQuery("SELECT ArtifactText, ArtifactHeader FROM ARTIFACT WHERE ARTIFACTID=" + id);
        return ds.Tables[0];
    }


    protected void lv_Reviews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewItem item = e.Item;
        {
            var repeater_Review = (Repeater)item.FindControl("repeater_Review");
            DataRowView drv = (DataRowView)item.DataItem;
            repeater_Review.DataSource = getReviews(Convert.ToInt64(drv["ReviewRefId"]));
            repeater_Review.DataBind();
        }
    }
}