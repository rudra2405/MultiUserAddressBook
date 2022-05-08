using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_login : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    #region login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString StrUserName = SqlString.Null;
        SqlString StrPassword = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation
        String StrErrorMessage = "";

        if (txtUserNameLogin.Text.Trim() == "")
        {
            StrErrorMessage += "- Enter UserName <br>";
        }
        if (txtPasswordLogin.Text.Trim() == "")
        {
            StrErrorMessage += "- Enter Password <br>";
        }
        if (StrErrorMessage != "")
        {
            lblMessage.Text = "Kindly solve following Error(s) <br/>" + StrErrorMessage;
            return;
        }
        #endregion server Side Validation

        #region Assign the Value

        if (txtUserNameLogin.Text.Trim() != "")
            StrUserName = txtUserNameLogin.Text.Trim();


        if (txtPasswordLogin.Text.Trim() != "")
            StrPassword = txtPasswordLogin.Text.Trim();

        #endregion Assign the Value

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_User_SelectByUserNamePassword]";

            objCmd.Parameters.AddWithValue("@UserName", StrUserName);
            objCmd.Parameters.AddWithValue("@Password", StrPassword);

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                lblMessage.Text = "Valid User";

                while(objSDR.Read())
                { 
                    if(!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/AdminPanel/Default.aspx", true);
            }
            else
            {
                lblMessage.Text = "Either UserName or Password is not valid, Try Again with different details ";
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion login

    #region Register
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Register.aspx", true);
    }
    #endregion Register
}