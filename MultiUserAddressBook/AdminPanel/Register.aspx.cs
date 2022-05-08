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

public partial class AdminPanel_Register : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    #region Register
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlString StrUserName = SqlString.Null;
        SqlString StrPassword = SqlString.Null;
        SqlString StrDisplayName = SqlString.Null;
        SqlString StrMobileNo = SqlString.Null;
        SqlString StrEmail = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation
            String StrErrorMessge = "";

            if (txtUserName.Text.Trim() == "")
            {
                StrErrorMessge += "- Enter UserName  <br />";
            }

            if (txtPassword.Text.Trim() == "")
            {
                StrErrorMessge += "- Enter Password  <br />";
            }
            if (txtDisplayName.Text.Trim() == "")
            {
                StrErrorMessge += "- Enter DisplayName  <br />";
            }
            if (txtMobileNo.Text.Trim() == "")
            {
                StrErrorMessge += "- Enter MobileNo  <br />";
            }
            if (txtEmail.Text.Trim() == "")
            {
                StrErrorMessge += "- Enter Email  <br />";
            }

            if (StrErrorMessge != "")
            {
                lblMassage.Text = StrErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (txtUserName.Text.Trim() != "")
            {
                StrUserName = txtUserName.Text.Trim();
            }
            if (txtPassword.Text.Trim() != "")
            {
                StrPassword = txtPassword.Text.Trim();
            }
            if (txtDisplayName.Text.Trim() != "")
            {
                StrDisplayName = txtDisplayName.Text.Trim();
            }
            if (txtMobileNo.Text.Trim() != "")
            {
                StrMobileNo = txtMobileNo.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                StrEmail = txtEmail.Text.Trim();
            }
            #endregion Gather Information

            #region Set Conection and Command 
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmdd = objConn.CreateCommand();
            objCmdd.CommandType = CommandType.StoredProcedure;
            objCmdd.Parameters.AddWithValue("@UserName", StrUserName);
            objCmdd.Parameters.AddWithValue("@Password", StrPassword);
            objCmdd.Parameters.AddWithValue("@DisplayName", StrDisplayName);
            objCmdd.Parameters.AddWithValue("@MobileNo", StrMobileNo);
            objCmdd.Parameters.AddWithValue("@Email", StrEmail);
            #endregion Set Connection and Command Object

            #region InsertUser
            objCmdd.CommandText = "[dbo].[PR_User_Insert]";
            objCmdd.ExecuteNonQuery();
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtDisplayName.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            txtUserName.Focus();
            lblMassage.Text = "User Registered Sucessfully";
            #endregion InsertUser

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMassage.Text = "User already exist Kindly Use Diffrent Name!!";
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
   }
    #endregion Register

    #region Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Login.aspx", true);
    }
    #endregion Cancel
}