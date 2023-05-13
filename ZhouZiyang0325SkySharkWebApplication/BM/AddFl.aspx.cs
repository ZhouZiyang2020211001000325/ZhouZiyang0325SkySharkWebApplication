using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZhouZiyang0325SkySharkWebApplication.BM
{
    public partial class AddFl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDataBaseConnectionString"].ConnectionString;
            SqlConnection conn=new SqlConnection(ConnectionString);
            conn.Open();
            string selectSql = "SELECT FltNo FROM dtFltDetails";
            SqlCommand cmd =new SqlCommand(selectSql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet,"FlightNo");
            conn.Close();
            foreach (DataRow row in dataSet.Tables["FlightNo"].Rows)
            {
                if (row[0].ToString().Trim() == txtFlightNumber.Text.Trim())
                {
                    lblMessage.Text = "The Flight already exists.Please try another fligh number";
                    return;
                }
            }
            TimeSpan deptime, arrtime;
            String DepDateTime, ArrDateTime;
            try
            {
                deptime = Convert.ToDateTime(txtDepartureTime.Text).TimeOfDay;
                arrtime =Convert.ToDateTime(txtAircraftType.Text).TimeOfDay;
                DepDateTime = Calendar1.SelectedDate.ToShortDateString() + "" + deptime.ToString();
                ArrDateTime = Calendar2.SelectedDate.ToShortDateString() + "" + arrtime.ToString();
                if (deptime >= arrtime)
                {
                    lblMessage.Text = "Departure Time cant be greater than or equal to arrival time";
                    return;
                }
            }
            catch
            {
                lblMessage.Text = "Invalid departure or arrival time";
                return;
            }
            try
            {
                conn.Open();
                string updateSql = "INSERT INTO [dtFltDetails] ([FltNo],[Origin],[Destination],[Deptime],[Arrtime]," + "" +
                    "[AircraftType],[SeatsExec],[SeatsBn],[FareExec],[FareBn],[LaunchDate])"+
                    "VALUES(@FltNo,@Origin,@Destination,@Deptime,@Arrtime,@AircraftType" +
                    "@SeatsExec,@SeatsBn,@FareExec,@FareBn,@LaunchDate)";
                SqlCommand cmd2= new SqlCommand(updateSql, conn);
                cmd2.Parameters.AddWithValue("@FltNo",txtFlightNumber.Text.Trim());
                cmd2.Parameters.AddWithValue("@Origin",txtOriginPlace.Text.Trim());
                cmd2.Parameters.AddWithValue("@Destinatiom",txtDestination.Text.Trim());
                cmd2.Parameters.AddWithValue("@Deptime",DepDateTime);
                cmd2.Parameters.AddWithValue("@Arrtime",ArrDateTime);
                cmd2.Parameters.AddWithValue("@AircraftType",txtAircraftType.Text.Trim());
                cmd2.Parameters.AddWithValue("@SeatsExec",Convert.ToInt32(txtNoOfExecSeats.Text.Trim()));
                cmd2.Parameters.AddWithValue("@SeatsBn",Convert.ToInt32(txtNoOfBusiSeats.Text.Trim()));
                cmd2.Parameters.AddWithValue("@FareExec",Convert.ToInt32(txtExecFare.Text.Trim()));
                cmd2.Parameters.AddWithValue("@FareBn",Convert.ToInt32(txtBusiClassFare.Text.Trim()));
                cmd2.Parameters.AddWithValue("@LaunchDate",DateTime.Today.Date.ToShortDateString());
                int n =cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
                conn.Close();
                return;

            }
            conn.Close();
            lblMessage.Text = "Flight add Successfully";
            txtFlightNumber.Text = "";
            txtOriginPlace.Text = "";
            txtAircraftType.Text = "";
            txtArrivalTime.Text = "";
            txtBusiClassFare.Text = "";
            txtDepartureTime.Text = "";
            txtDestination.Text = "";
            txtExecFare.Text = "";
            txtFlightNumber.Text = "";
            txtNoOfBusiSeats.Text = "";
            txtNoOfExecSeats.Text = "";
            txtOriginPlace.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtFlightNumber.Text = "";
            txtOriginPlace.Text = "";
            txtAircraftType.Text = "";
            txtArrivalTime.Text = "";
            txtBusiClassFare.Text = "";
            txtDepartureTime.Text = "";
            txtDestination.Text = "";
            txtExecFare.Text = "";
            txtFlightNumber.Text = "";
            txtNoOfBusiSeats.Text = "";
            txtNoOfExecSeats.Text = "";
            txtOriginPlace.Text = "";
        }
    }
}