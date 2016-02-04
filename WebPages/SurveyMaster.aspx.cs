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
        ds=dataAdapter.ExecuteSelectQuery("Select * from Artifact where Datalength(ArtifactText) <> 0");
        gv_SurveyMaster.DataSource = ds.Tables[0];
        gv_SurveyMaster.DataBind();
    }

    protected void btn_UserCode_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try {
            string usercode = txt_UserCode.Text.ToString();
            DataAdapter da = new DataAdapter();
            DataSet userSet = da.ExecuteSelectQuery("Select * from Users where UserArchived=0 and UserToken='" + usercode.Replace("'", "''") + "'");
            if (userSet.Tables.Count > 0 && userSet.Tables[0].Rows.Count > 0)
            {
                //usercode is valid
                lbl_Message.Text = "Code accepted.";
                Session["UserToken"] = userSet.Tables[0].Rows[0]["UserId"];
            }
            else
            {
                Session["UserToken"] = null;
                lbl_Message.Text = "Invalid code.";
            }
            
        }
        catch(Exception ex)
        {
            lbl_Message.Text = "Error occured, contact administrator";
        }
    }
}