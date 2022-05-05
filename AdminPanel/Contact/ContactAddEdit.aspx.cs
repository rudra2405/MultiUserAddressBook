﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            FillDropDownForCountryList();
            //FillcblContactCategoryID();
            FillDropDownForContactCategoryList();
         
            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]),(Convert.ToInt32(Request.QueryString["UserID"])));
                FillDropDownForStateList();
                FillDropDownForCityList();
            }
            else
            {
                lblMessage.Text = "Add Mode";
                ddlCityID.Items.Insert(0, new ListItem("", "-1"));
                ddlStateID.Items.Insert(0, new ListItem("", "-1"));
            }

        }
    }

    #endregion Load Event

    #region Buttton : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        String ContactPhotoPath = "";
        if (fuContactPhotoPath.HasFile)
        {
            ContactPhotoPath = "~/UserContent/" + fuContactPhotoPath.FileName.ToString().Trim();
            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));
        }


        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        SqlInt32 StrCountryID = SqlInt32.Null;
        SqlInt32 StrStateID = SqlInt32.Null;
        SqlInt32 StrCityID = SqlInt32.Null;
        SqlInt32 StrContactCategoryID = SqlInt32.Null;
        SqlString StrContactName = SqlString.Null;
        SqlString StrContactPhotoPath = SqlString.Null;
        SqlString StrContactNo = SqlString.Null;
        SqlString StrWhatsAppNo = SqlString.Null;
        SqlString StrBirthDate = SqlString.Null;
        SqlString StrEmail = SqlString.Null;
        SqlInt32 StrAge = SqlInt32.Null;
        SqlString StrAddress = SqlString.Null;
        SqlString StrBloodGroup = SqlString.Null;
        SqlString StrFacebookID = SqlString.Null;
        SqlString StrLinkedINID = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region  Server Side Validation
            //Server Side Validation

            String StrErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                StrErrorMessage += "- Select Country <br />";

            if (ddlStateID.SelectedIndex == 0)
                StrErrorMessage += "- Select State <br />";

            if (ddlCityID.SelectedIndex == 0)
                StrErrorMessage += "- Select City <br />";

            if (ddlContactCategoryID.SelectedIndex == 0)
                StrErrorMessage += "- Select ContactCategory <br />";

            //if (cblContactCategoryID.SelectedIndex == 0)
            //    StrErrorMessage += "- Select ContactCategory <br />";

            if (txtContactName.Text.Trim() == "")
                StrErrorMessage += "- Enter Contact Name <br/>";

            if (ContactPhotoPath == "")
                StrErrorMessage += "- Upload Photo <br/>";

            if (txtContactNo.Text.Trim() == "")
                StrErrorMessage += "- Enter Contact No <br/>";

            if (txtEmail.Text.Trim() == "")
                StrErrorMessage += "- Enter Email <br/>";

            if (txtAddress.Text.Trim() == "")
                StrErrorMessage += "- Enter Address <br/>";


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
            if (ddlCityID.SelectedIndex > 0)
            {
                StrCityID = Convert.ToInt32(ddlCityID.SelectedValue);
            }
            if (ddlContactCategoryID.SelectedIndex > 0)
            {
                StrContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
            }
            //if (cblContactCategoryID.SelectedIndex > 0)
            //{
            //    StrContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
            //}
            if (txtContactName.Text.Trim() != "")
            {
                StrContactName = txtContactName.Text.Trim();
            }
            if (ContactPhotoPath != "")
            {
                StrContactPhotoPath = ContactPhotoPath;
            }
            if (txtContactNo.Text.Trim() != "")
            {
                StrContactNo = txtContactNo.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                StrEmail = txtEmail.Text.Trim();
            }
            if (txtAddress.Text.Trim() != "")
            {
                StrAddress = txtAddress.Text.Trim();
            }
            if (txtBirthDate.Text.Trim() != "")
            {
                StrBirthDate = txtBirthDate.Text.Trim();
            }
            if (txtWhatsAppNo.Text.Trim() != "")
            {
                StrWhatsAppNo = txtWhatsAppNo.Text.Trim();
            }
            if (txtAge.Text.Trim() != "")
            {
                StrAge = Convert.ToInt32(txtAge.Text.Trim());
            }
            if (txtBloodGroup.Text.Trim() != "")
            {
                StrBloodGroup = txtBloodGroup.Text.Trim();
            }
            if (txtFacebookID.Text.Trim() != "")
            {
                StrFacebookID = txtFacebookID.Text.Trim();
            }
            if (txtLinkedINID.Text.Trim() != "")
            {
                StrLinkedINID = txtLinkedINID.Text.Trim();
            }
            #endregion Gather Information

            #region Set Connection and Command Object

            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
            objCmd.Parameters.AddWithValue("@StateID", StrStateID);
            objCmd.Parameters.AddWithValue("@CityID", StrCityID);
            objCmd.Parameters.AddWithValue("@ContactCategoryID", StrContactCategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", StrContactName);
            objCmd.Parameters.AddWithValue("@ContactPhotoPath",StrContactPhotoPath);
            objCmd.Parameters.AddWithValue("@ContactNo", StrContactNo);
            objCmd.Parameters.AddWithValue("@WhatsAppNo", StrWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", StrBirthDate);
            objCmd.Parameters.AddWithValue("@Email", StrEmail);
            objCmd.Parameters.AddWithValue("@Age", StrAge);
            objCmd.Parameters.AddWithValue("@Address", StrAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", StrBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", StrFacebookID);
            objCmd.Parameters.AddWithValue("@LinkedinID", StrLinkedINID);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            #endregion Set Connection and Command Object

            if (Request.QueryString["ContactID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");

                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add mode
                objCmd.CommandText = "[dbo].[PR_Contact_Insert]";
                objCmd.ExecuteNonQuery();
                ddlCountryID.SelectedIndex = 0;

                ddlStateID.SelectedIndex = 0;
                ddlStateID.Items.Clear();

                ddlCityID.SelectedIndex = 0;
                ddlCityID.Items.Clear();

                //cblContactCategoryID.SelectedIndex = 0;
                //cblContactCategoryID.Items.Clear();

                txtContactName.Text = "";
                txtContactNo.Text = "";
                txtWhatsAppNo.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtFacebookID.Text = "";
                txtLinkedINID.Text = "";

                txtContactName.Focus();

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

    #endregion Buttton : Save

    #region Buttton : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
    }

    #endregion Buttton : Save

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
        //    objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
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
        //    objCmd.CommandText = "PR_State_SelectForDropDownListByUserID";
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
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

    #region Fill DropDownForCityList
    private void FillDropDownForCityList()
    {
        CommonDropDownFillMethods.FillDropDownForCityList(ddlCityID, Session["UserID"].ToString().Trim());
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        //try
        //{
        //    #region Set Connection and Command Object
        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "PR_City_SelectForDropDownListByUserID";
        //    if (Session["UserID"] != null)
        //    {
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
        //    }
        //    SqlDataReader objSDR = objCmd.ExecuteReader();
        //    #endregion Set Connection and Command Object

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCityID.DataSource = objSDR;
        //        ddlCityID.DataValueField = "CityID";
        //        ddlCityID.DataTextField = "CityName";
        //        ddlCityID.DataBind();

        //    }

        //    ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

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

    #endregion Fill DropDownForCityList

    #region FillcblContactCategoryID
    //private void FillcblContactCategoryID()
    //{
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //    try
    //    {
    //        objConn.Open();
    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "[dbo].[PR_ContactCategory_SelectForDropDownListByUserID]";

    //        if (Session["UserID"] != null)
    //            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows)
    //        {
    //            cblContactCategoryID.DataTextField = "ContactCategoryName";
    //            cblContactCategoryID.DataValueField = "ContactCategoryID";
    //            cblContactCategoryID.DataSource = objSDR;
    //            cblContactCategoryID.DataBind();
    //        }

    //        objConn.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        objConn.Close();

    //    }
    //}
    #endregion FillcblContactCategoryID()

    #region Fill DropDownForContactCategoryList
    private void FillDropDownForContactCategoryList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownListByUserID";
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection and Command Object

            if (objSDR.HasRows == true)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";
                ddlContactCategoryID.DataBind();

            }

            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

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

    #endregion Fill DropDownForContactCategoryList

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID,SqlInt32 UserID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Contact_SelectByPKUserID]";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            #endregion Set Connection and Command Object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region read the value and set the controls
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    }
                    //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    //{
                    //    cblContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                    //}
                    if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                    {
                        imgPhoto.ImageUrl = objSDR["ContactPhotoPath"].ToString().Trim();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                    }
                    if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                    {
                        txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"].ToString()).ToString("yyyy-MM-dd");
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString().Trim();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString().Trim();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString().Trim();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                    }
                    if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                    {
                        txtLinkedINID.Text = objSDR["LinkedINID"].ToString().Trim();
                    }

                    break;
                }

            }
            else
            {
                lblMessage.Text = "No Data available for the ContactID = " + ContactID.ToString();
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
                ddlCityID.Items.Clear();
                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

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
                ddlCityID.Items.Clear();
                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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

    #region Fill DropDownForCityByStateIDList
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 StrStateID = SqlInt32.Null;

        try
        {
            #region Server Side Validation
            String StrErrorMessge = "";

            if (ddlStateID.SelectedIndex == 0)
            {
                StrErrorMessge += "- Select State  <br />";
                ddlCityID.Items.Clear();
                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
            }
            if (StrErrorMessge != "")
            {
                lblMessage.Text = StrErrorMessge;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlStateID.SelectedIndex > 0)
            {
                StrStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            #endregion Gather Information

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@StateID", StrStateID);
            if (Session["UserID"] != null)
            {
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString().Trim());
            }
            objCmd.CommandText = "[dbo].[PR_City_SelectForDropDownListByStateID]";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            #endregion Set Connection & Command Object

            if (objSDR.HasRows == true)
            {
                ddlCityID.DataSource = objSDR;
                ddlCityID.DataValueField = "CityID";
                ddlCityID.DataTextField = "CityName";
                ddlCityID.DataBind();
            }

            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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
    #endregion Fill DropDownForCityByStateIDList
}