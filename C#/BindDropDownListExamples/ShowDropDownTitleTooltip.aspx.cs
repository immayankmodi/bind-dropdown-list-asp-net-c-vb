using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BindDropDownListExamples {

    public partial class ShowDropDownTitleTooltip : System.Web.UI.Page {
    
        //specify your connection string here..
        public static string strConn = @"Data Source=datasource;Integrated Security=true;Initial Catalog=database";
        
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindDropDownList();
            }
        }

        //bind subject names to dropdownlist
        private void BindDropDownList() {
            try {
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT SubjectId,SubjectName FROM SubjectDetails";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSubjects.DataSource = dt;
                        ddlSubjects.DataValueField = "SubjectId";
                        ddlSubjects.DataTextField = "SubjectName";
                        ddlSubjects.DataBind();
                        sqlConn.Close();

                        //Adding "Please select" option in dropdownlist
                        ddlSubjects.Items.Insert(0, new ListItem("Please select", "0"));
                    }
                }
            } catch { }
        }

        //OnDataBound event to bound title tooltip
        protected void ddlSubjects_OnDataBound(object sender, EventArgs e) {
            DropDownList dd = sender as DropDownList;
            if (dd != null) {
                foreach (ListItem li in dd.Items) {
                    li.Attributes["title"] = li.Text;
                }
            }
        }
    }
}