using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPages_Artifact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long id = Request.QueryString["id"]== null?0:Convert.ToInt64(Request.QueryString["id"]);
        if (id != 0)
        {
            string url = readArtifact(id).Rows[0]["ArtifactText"].ToString();
            i_wiki.Attributes.Add("src", url);
            lv_Reviews.DataSource = getReviewStatus(id);
            lv_Reviews.DataKeyNames =new string[]{ "ReviewRefId" };
            lv_Reviews.DataBind();

        }
    }
    
    /// <summary>
    /// get all the reviews for artifact
    /// </summary>
    /// <param name="id"></param>
    private DataTable getReviewStatus(long id)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds = dataAdapter.ExecuteSelectQuery("SELECT  distinct ReviewRefId,case when userid is null then 'Not Done' else 'Done' end as Status, R.ReviewArtifactMapId  FROM REVIEW R INNER JOIN Artifact A ON a.ArtifactId = r.ReviewArtifactMapId LEFT JOIN SurveyMaster SM ON SM.SurveyReviewMapId = R.ReviewId LEFT JOIN[User] U ON SM.SurveyUserMapId = U.UserId where reviewartifactmapid = "+id+" order by ReviewRefId");
        return ds.Tables[0];
    }
    private DataTable getReviews(long reviewRefId)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds = dataAdapter.ExecuteSelectQuery("SELECT  ReviewId,ReviewContent, ReviewRefId, R.ReviewArtifactMapId FROM REVIEW R INNER JOIN Artifact A ON a.ArtifactId = r.ReviewArtifactMapId where ReviewRefId = " + reviewRefId);
        return ds.Tables[0];
    }
    private DataTable readArtifact(long id)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds=dataAdapter.ExecuteSelectQuery("SELECT ArtifactText, ArtifactHeader FROM ARTIFACT WHERE ARTIFACTID=" + id);
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