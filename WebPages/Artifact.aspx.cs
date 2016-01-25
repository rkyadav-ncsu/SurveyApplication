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
            div_ArtifactTitle.InnerHtml = readArtifact(id).Rows[0]["ArtifactHeader"].ToString();
            div_ArtifactText.InnerHtml = readArtifact(id).Rows[0]["ArtifactText"].ToString();

            lv_Reviews.DataSource = getReview(id);
            lv_Reviews.DataKeyNames =new string[]{ "ReviewId" };
            lv_Reviews.DataBind();

        }
    }
    /// <summary>
    /// get all the reviews for artifact
    /// </summary>
    /// <param name="id"></param>
    private DataTable getReview(long id)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds = dataAdapter.ExecuteSelectQuery("SELECT  ReviewId,ReviewContent,case when userid is null then 'Not Done' else 'Done' end as Status FROM REVIEW R  INNER JOIN Artifact A ON a.ArtifactId = r.ReviewArtifactMapId  LEFT JOIN SurveyMaster SM ON SM.SurveyReviewMapId = R.ReviewId  LEFT JOIN[User] U ON SM.SurveyUserMapId = U.UserId where reviewartifactmapid = " + id);
        return ds.Tables[0];
    }
    private DataTable readArtifact(long id)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds=dataAdapter.ExecuteSelectQuery("SELECT ArtifactText, ArtifactHeader FROM ARTIFACT WHERE ARTIFACTID=" + id);
        return ds.Tables[0];
    }
  

}