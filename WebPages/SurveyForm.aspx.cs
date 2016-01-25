using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPages_SurveyForm : System.Web.UI.Page
{
    long reviewId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        reviewId = Request.QueryString["ReviewId"] == null ? 0 : Convert.ToInt64(Request.QueryString["ReviewId"]);
        if (reviewId != 0)
        {
            Session["ReviewId"] = reviewId;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("artifact.aspx\\?id=" + reviewId);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataAdapter da = new DataAdapter();
        //todo  this should be converted into a stored procedure. Check if review is already done by the user.
        da.ExecuteInsertQuery("insert into SurveyMaster values(" + Session["ReviewId"] + "," + Session["UserId"]+")");
        long surveyId = Convert.ToInt64(da.ExecuteSelectQuery("SELECT * FROM SURVEYMASTER WHERE SURVEYREVIEWMAPID=" + Session["ReviewId"] + "and SURVERYUSERMAPID=" + Session["UserId"]).Tables[0].Rows[0][0]);

        //insert answers
        string answer1 = DropDownList1.SelectedValue;
        string answer2 = DropDownList2.SelectedValue;
        string answer3 = DropDownList3.SelectedValue;
        string answer4 = DropDownList4.SelectedValue;
        string answer5 = DropDownList5.SelectedValue;
        string answer6 = DropDownList6.SelectedValue;
        string answer7 = DropDownList7.SelectedValue;
        string answer8 = DropDownList8.SelectedValue;
        string answer9 = DropDownList9.SelectedValue;
        string answer10 = DropDownList10.SelectedValue;

        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(1," + answer1 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(2," + answer2 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(3," + answer3 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(4," + answer4 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(5," + answer5 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(6," + answer6 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(7," + answer7 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(8," + answer8 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(9," + answer9 + ",'')");
        da.ExecuteInsertQuery("INSERT INTO SURVEYANSWER VALUES(10," + answer10 + ",'')");
        Response.Redirect("artifact.aspx\\?id=" + reviewId);




    }
}