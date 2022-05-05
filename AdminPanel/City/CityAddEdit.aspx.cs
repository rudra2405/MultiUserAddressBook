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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            FillDropDownForCountryList();

            if (Request.QueryString["CityID"] != null)
            {
                lblMessage.Text = "Edit Mode | CityID = " + Request.QueryString["CityID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]),(Convert.ToInt32(Request.QueryString["UserID"])));
                FillDropDownForStateList();
            }
            else
            {
                lblMessage.Text = "Add Mode";
                ddlStateID.Items.Insert(0, new ListItem("", "-1"));
             }

        }
    }

    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        SqlInt32 StrCountryID = SqlInt32.Null;
        SqlInt32 StrStateID = SqlInt32.Null;
        SqlString StrCityName = SqlString.Null;
        SqlString StrSTDCode = SqlString.Null;
        SqlString StrPinCode = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region  Server Side Validation
            //Server side Validation

            String StrErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                StrErrorMessage += "- Select Country <br />";

            if (ddlStateID.SelectedIndex == 0)
                StrErrorMessage += "- Select State <br />";

            if (txtCityName.Text.Trim() == "")
                StrErrorMessage += "- Enter City Name <br/>";

            if (txtSTDCode.Text.Trim() == "")
                StrErrorMessage += "- Enter STD Code <br/>";

            if (txtPinCode.Text.Trim() == "")
                StrErrorMessage += "- Enter Pin Code <br/>";


            if (StrErrorMessage.Trim() != "")
            {
                lblMessage.Text = StrErrorMessage;
                return;
            }
            #endregion  Server Side Validation

            #region Gather Information
            //Gather the Information
            if (ddlCountryID.SelectedIndex > 0)
            {
                StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (ddlStateID.SelectedIndex > 0)
            {
                StrStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                StrCityName = txtCityName.Text.Trim();
            }

            if (txtSTDCode.Text.Trim() != "")
            {
                StrSTDCode = txtSTDCode.Text.Trim();
            }
            if (txtPinCode.Text.Trim() != "")
            {
                StrPinCode = txtPinCode.Text.Trim();
            }

            #endregion Gather Information

            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
            objCmd.Parameters.AddWithValue("@StateID", StrStateID);
            objCmd.Parameters.AddWithValue("@CityName", StrCityName);
            objCmd.Parameters.AddWithValue("@STDCode", StrSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", StrPinCode);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }

            #endregion Set Connection and Command Object


            if (Request.QueryString["CityID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");

                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add mode
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();
                txtCityName.Text = "";

                ddlCountryID.SelectedIndex = 0;

                ddlStateID.SelectedIndex = 0;
                ddlStateID.Items.Clear();

                txtSTDCode.Text = "";
                txtPinCode.Text = "";

                txtCityName.Focus();

                lblMessage.Text = "Data Inserted Succsessfully";
                #endregion Insert Record

            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");

    }

    #endregion Button : Cancel

    #region Fill DropDownForStateList
    private void FillDropDownForStateList()
    {
        CommonDropDownFillMethods.FillDropDownForStateList(ddlStateID, Session["UserID"].ToString().Trim());
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        //try
        //{
        //    #region Set Connection and Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
        //    objCmd.CommandText = "PR_State_SelectForDropDownListByUserID";
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    #endregion Set Connection and Command Object

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlStateID.DataSource = objSDR;
        //        ddlStateID.DataValueField = "StateID";
        //        ddlStateID.DataTextField = "StateName";
        //        ddlStateID.DataBind();

        //    }

        //    ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
    }

    #endregion Fill DropDownForStateList

    #region Fill DropDownForCountryList
    private void FillDropDownForCountryList()
    {
        CommonDropDownFillMethods.FillDropDownForCountryList(ddlCountryID, Session["UserID"].ToString().Trim());
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        //try
        //{
        //    #region Set Connection and Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
        //    objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    #endregion Set Connection and Command Object

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCountryID.DataSource = objSDR;
        //        ddlCountryID.DataValueField = "CountryID";
        //        ddlCountryID.DataTextField = "CountryName";
        //        ddlCountryID.DataBind();

        //    }

        //    ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
    }

    #endregion Fill DropDownForCountryList

    #region Fill Controls
    private void FillControls(SqlInt32 CityID, SqlInt32 UserID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_City_SelectByPKUserID]";
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            #endregion Set Connection and Command Object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region read the value and set the controls
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }

            }
            else
            {
                lblMessage.Text = "No Data available for the CityID = " + CityID.ToString();
            }
            #endregion read the value and set the controls

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill Controls

    #region Fill DropDownForStateByCountryIDList
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 StrCountryID = SqlInt32.Null;

        try
        {
            #region Server Side Validation
            String StrErrorMessge = "";

            if (ddlCountryID.SelectedIndex == 0)
            {
                    StrErrorMessge += "- Select Country  <br />";
                    ddlStateID.Items.Clear();
                    ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
            }
            if (StrErrorMessge != "")
            {
                lblMessage.Text = StrErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlCountryID.SelectedIndex > 0)
            {
                StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownListByCountryID]";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();
            }
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill DropDownForStateByCountryIDList

}