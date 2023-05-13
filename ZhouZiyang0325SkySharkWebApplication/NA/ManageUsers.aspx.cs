using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZhouZiyang0325SkySharkWebApplication.NA
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddSubmit_Click(object sender, EventArgs e)
        {
            string username, password, role;
            int selection;
            role = lstAddRole.SelectedValue;
            username = txtAddUserName.Text;
            password = txtAddPassword.Text;
            selection = lstAddRole.SelectedIndex;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string queryString = "Select UserName,Password, from dtUsers where UserName='" + username + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(queryString, conn);
            DataSet dsl = new DataSet();
            adapter.Fill(dsl,"dtUsers");
            if (dsl.Tables["dtUsers"].Rows.Count == 0)
            {
                string insertQquertString = "INSERT INTO [dtUsers]([Username],[Password],[Role]) VALUES('"+username+"','"+password+"','"+role+"')";
                SqlCommand insterCommand = new SqlCommand(insertQquertString, conn);
                insterCommand.ExecuteNonQuery();
            }
            else
            {
                lblMessage.Text = "The user name already exists.Please try another user name";
                return;
            }
        }

        protected void btnDelDelete_Click(object sender, EventArgs e)
        {

        }
    }
}