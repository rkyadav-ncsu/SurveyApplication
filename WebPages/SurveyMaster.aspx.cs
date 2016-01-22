using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPages_SurveyMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetArtifactList();
    }
    private void GetArtifactList()
    {
        DataAdapter dataAdapter = new DataAdapter();
        DataSet ds = new DataSet();
        ds=dataAdapter.ExecuteSelectQuery("Select * from Artifact");
        gv_SurveyMaster.DataSource = ds.Tables[0];
        gv_SurveyMaster.DataBind();
    }
}