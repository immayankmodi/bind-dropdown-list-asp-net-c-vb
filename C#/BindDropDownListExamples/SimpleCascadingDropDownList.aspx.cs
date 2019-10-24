using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BindDropDownListExamples {

    public partial class SimpleCascadingDropDownList : System.Web.UI.Page {

        //specify your connection string here..
        public static string strConn = @"Data Source=datasource;Integrated Security=true;Initial Catalog=database";
        
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindCountryList();
            }
        }

        //bind countries to country dropdownlist
        private void BindCountryList() {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT CountryId,CountryName FROM Country";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlCountry.DataSource = dt;
                        ddlCountry.DataValueField = "CountryId";
                        ddlCountry.DataTextField = "CountryName";
                        ddlCountry.DataBind();
                        sqlConn.Close();

                        //Adding "Please select country" option in dropdownlist
                        ddlCountry.Items.Insert(0, new ListItem("Please select country", "0"));

                        //Adding initially value to "state" and "city" dropdownlist
                        ddlState.Items.Insert(0, new ListItem("Please select state", "0"));
                        ddlCity.Items.Insert(0, new ListItem("Please select city", "0"));
                    }
                }
            } catch { }
        }

        //bind states to state dropdownlist on country change event
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT StateId,StateName FROM State WHERE CountryId=@CountryId";
                        sqlCmd.Parameters.AddWithValue("@CountryId", ddlCountry.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlState.DataSource = dt;
                        ddlState.DataValueField = "StateId";
                        ddlState.DataTextField = "StateName";
                        ddlState.DataBind();
                        sqlConn.Close();

                        //Adding "Please select state" option in dropdownlist
                        ddlState.Items.Insert(0, new ListItem("Please select state", "0"));

                        //also clear city dropdownlist because we are changing country
                        ddlCity.Items.Clear();
                        ddlCity.Items.Insert(0, new ListItem("Please select city", "0"));
                    }
                }
            } catch { }
        }

        //bind cities to city dropdownlist on state change event
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT CityId,CityName FROM City WHERE StateId=@StateId";
                        sqlCmd.Parameters.AddWithValue("@StateId", ddlState.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlCity.DataSource = dt;
                        ddlCity.DataValueField = "CityId";
                        ddlCity.DataTextField = "CityName";
                        ddlCity.DataBind();
                        sqlConn.Close();

                        //Adding "Please select city" option in dropdownlist
                        ddlCity.Items.Insert(0, new ListItem("Please select city", "0"));
                    }
                }
            } catch { }
        }
    }
}