using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Crud_GrirView
{
    public partial class PhoneBook : System.Web.UI.Page
    {
        string connectionString = @"Data Source=LAPTOP-B710EAPP;Integrated Security=true;Initial Catalog=PhoneBookDatabase";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateGridView();
        } 
        void PopulateGridView()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from tblPhone", connection);
                sqlDataAdapter.Fill(table);
            }
            if (table.Rows.Count > 1)
            {
                myPhoneBook.DataSource = table;
                myPhoneBook.DataBind();
            }
            else
            {
                    table.Rows.Add(table.NewRow());
                    myPhoneBook.DataSource = table;
                    myPhoneBook.DataBind();
                    myPhoneBook.Rows[0].Cells.Clear();
                    myPhoneBook.Rows[0].Cells.Add(new TableCell());
                    myPhoneBook.Rows[0].Cells[0].ColumnSpan = table.Columns.Count;
                    myPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..!";
                    myPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
      

       

      

        protected void myPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
                try

                {
                    if (e.CommandName.Equals("Add"))
                    {
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            string query = "INSERT INTO tblPhone (FirstName,LastName,Contact,Email) VALUES (@FirstName,@LastName,@Contact,@Email)";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@FirstName", (myPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@LastName", (myPhoneBook.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@Contact", (myPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@Email", (myPhoneBook.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                            sqlCmd.ExecuteNonQuery();
                        PopulateGridView();
                            lblSuccessMsg.Text = "New Record Added";
                            lblErrorMsgFailed.Text = "";
                        }
                    }
                }
            catch (Exception ex)
                {
                    lblSuccessMsg.Text = "";
                    lblErrorMsgFailed.Text = ex.Message;
                }
            }
        protected void myPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridView();
            
        }

        protected void myPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            myPhoneBook.EditIndex = -1;
            PopulateGridView();
        }

        protected void myPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE tblPhone SET FirstName=@FirstName,LastName=@LastName,Contact=@Contact,Email=@Email WHERE Id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (myPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (myPhoneBook.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (myPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (myPhoneBook.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(myPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    myPhoneBook.EditIndex = -1;
                    PopulateGridView();
                    lblSuccessMsg.Text = "Selected Record Updated";
                    lblErrorMsgFailed.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMsg.Text = "";
                lblErrorMsgFailed.Text = ex.Message;
            }
        }

        protected void myPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM tblPhone WHERE ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(myPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    lblSuccessMsg.Text = "Selected Record Deleted";
                    lblErrorMsgFailed.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMsg.Text = "";
                lblErrorMsgFailed.Text = ex.Message;
            }
        }
    }
}
