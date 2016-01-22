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
        }
    }
    private DataTable readArtifact(long id)
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds=dataAdapter.ExecuteSelectQuery("SELECT ArtifactText, ArtifactHeader FROM ARTIFACT WHERE ARTIFACTID=" + id);
        return ds.Tables[0];
    }

}