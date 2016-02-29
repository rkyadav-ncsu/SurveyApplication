using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPages_SurveyForm : System.Web.UI.Page
{
    long ReviewRefId = 0;
    long submissionId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserToken"]==null)
            Response.Redirect("surveyMaster");
        ReviewRefId = Request.QueryString["ReviewRefId"] == null ? 0 : Convert.ToInt64(Request.QueryString["ReviewRefId"]);
        submissionId = Request.QueryString["submissionId"] == null ? 0 : Convert.ToInt64(Request.QueryString["submissionId"]);
        if (!IsPostBack)
        {
            if (ReviewRefId != 0)
            {
                Session["ReviewRefId"] = ReviewRefId;
                repeater_Review.DataSource = getReviews(ReviewRefId);
                repeater_Review.DataBind();
                r_SurveyQuestions.DataSource = getQuestions();
                r_SurveyQuestions.DataBind();
            }
        }
    }
    private DataTable getReviews(long reviewRefId)
    {
        DataAdapter dataAdapter = new DataAdapter();

        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0]=new SqlParameter("@reviewRefId", reviewRefId);
        DataSet ds = dataAdapter.ExecuteStoredProcedure("sp_GetReviewDetails", parameters);
        return ds.Tables[0];
    }
    private DataTable getQuestions()
    {
        DataAdapter da = new DataAdapter();
        try
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@reviewId", Convert.ToInt64(Session["ReviewRefId"]));
            DataSet ds = da.ExecuteStoredProcedure("sp_GetSurveyQuestions", sqlParameter);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        catch
        {

        }
        return new DataTable();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataAdapter da = new DataAdapter();
        long artifactId = 0;
        //todo  this should be converted into a stored procedure. Check if review is already done by the user.
        if (Session["UserToken"] != null && Session["ReviewRefId"]!=null)
        {
            long surveyId = 0;
            DataSet ds = da.ExecuteSelectQuery("SELECT top 1 surveyId FROM SURVEYMASTER WHERE ReviewId=" + Session["ReviewRefId"] + "and UserId=" + Session["UserToken"]);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                surveyId = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            }
            if (surveyId == 0)
            {
                //new survey
                da.ExecuteInsertQuery("insert into SurveyMaster values(" + Session["ReviewRefId"] + "," + Session["UserToken"] + ", getdate())");
                surveyId = Convert.ToInt64(da.ExecuteSelectQuery("SELECT top 1 surveyId FROM SURVEYMASTER WHERE ReviewId=" + Session["ReviewRefId"] + "and UserId=" + Session["UserToken"]).Tables[0].Rows[0][0]);
                DataTable datatable = getQuestions();

                if (r_SurveyQuestions.Controls.Count > 0)
                {
                    List<RepeaterItem> listItem = r_SurveyQuestions.Controls.OfType<RepeaterItem>().ToList();
                    for (int i = 0; i < listItem.Count(); i++)
                    {
                        RadioButtonList rbl = listItem[i].Controls.OfType<RadioButtonList>().ToList()[0];
                        //DropDownList ddl = listItem[i].Controls.OfType<DropDownList>().ToList()[0];
                        long answerId = Convert.ToInt64(rbl.SelectedValue);
                        long questionId = Convert.ToInt64(datatable.Rows[i]["QuestionId"]);
                        artifactId = Convert.ToInt64(datatable.Rows[i]["ArtifactId"]);
                        DataTable dt = da.ExecuteSelectQuery("select * from SURVEYANSWER where questionId=" + questionId + " and surveyId= " + surveyId).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(" + questionId + "," + surveyId + "," + answerId + ",'',getdate())");
                        }

                    }
                }
            }
            else
            {
                //existing survey
                //to-do
            }
           
            Session["ReviewRefId"] = null;
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
        //else
        //Response.Redirect("surveyMaster");



    }
}