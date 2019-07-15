using AireSpringTest.Core;
using AireSpringTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AireSpringTest.Web
{
    public partial class Employees : System.Web.UI.Page
    {
        private EmployeeRepository db = new EmployeeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        #region Editing

        //Calling repository method (Edit) to update employee data
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = employeesGrid.Rows[e.RowIndex];
                int employeeID = Convert.ToInt32(employeesGrid.DataKeys[e.RowIndex].Values[0]);
                string employeeLastName = (row.FindControl("txtEmployeeLastName") as TextBox).Text;
                var aa = (row.FindControl("txtEmployeeFirstName") as TextBox);
                string employeeFirstName = (row.FindControl("txtEmployeeFirstName") as TextBox).Text;
                string employeePhone = (row.FindControl("txtEmployeePhone") as TextBox).Text;
                string employeeZip = (row.FindControl("txtEmployeeZip") as TextBox).Text;
                DateTime hireDate = DateTime.ParseExact((row.FindControl("txtHireDate") as TextBox).Text, "MM/dd/yyyy", null);

                if (employeeLastName.Length == 0 ||
                    employeeFirstName.Length == 0 ||
                    (row.FindControl("txtHireDate") as TextBox).Text.Length == 0)
                {
                    ShowMessage("Please fill required fields!");
                    return;
                }

                db.Edit(
                    new Employee
                    {
                        EmployeeID = employeeID,
                        EmployeeFirstName = employeeFirstName,
                        EmployeeLastName = employeeLastName,
                        EmployeePhone = employeePhone,
                        EmployeeZip = employeeZip,
                        HireDate = hireDate
                    });

                employeesGrid.EditIndex = -1;
                ShowMessage("Employee updated successfully!");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            employeesGrid.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            employeesGrid.EditIndex = -1;
            this.BindGrid();
        }
        #endregion

        #region New Employee

        //Calling repository method (Add) to add a new employee
        protected void Insert(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                string employeeLastName = txtLastName.Text;
                string employeeFirstName = txtFirstName.Text;
                string employeePhone = txtPhone.Text;
                string employeeZip = txtZip.Text;
                DateTime hireDate = DateTime.ParseExact(txtHireDate.Text, "MM/dd/yyyy", null);

                db.Add(
                    new Employee
                    {
                        EmployeeFirstName = employeeFirstName,
                        EmployeeLastName = employeeLastName,
                        EmployeePhone = employeePhone,
                        EmployeeZip = employeeZip,
                        HireDate = hireDate
                    });

                CleanForm();
                ShowMessage("Employee added successfully!");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            this.BindGrid();
        }
        #endregion

        #region Deleting
        //Calling repository method (Remove) to remove employee
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int employeeID = Convert.ToInt32(employeesGrid.DataKeys[e.RowIndex].Values[0]);
            db.Remove(employeeID);
            this.BindGrid();
        }

        //Adding an alert dialog to confirm removing employee
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != employeesGrid.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
        #endregion

        #region Search
        protected void Search(object sender, EventArgs e)
        {
            var phoneSearch = txtPhoneSearch.Text.Replace("_", "");
            phoneSearch = (phoneSearch.Length < 14) ? phoneSearch.Replace("-", "") : phoneSearch;

            var employees = db.FindEmployees(txtLastNameSearch.Text, phoneSearch);
            employeesGrid.DataSource = employees.ToList();
            employeesGrid.DataBind();
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            employeesGrid.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void BindGrid()
        {
            var employees = db.GetEmployees();
            employeesGrid.DataSource = employees.ToList();
            employeesGrid.DataBind();
        }
        #endregion

        private bool ValidateForm()
        {
            if (txtLastName.Text.Length == 0 || txtFirstName.Text.Length == 0 || txtHireDate.Text.Length == 0)
            {
                ShowMessage("Please fill required fields!");
                return false;
            }
            return true;
        }

        private void CleanForm()
        {
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtZip.Text = string.Empty;
            txtHireDate.Text = string.Empty;
        }

        private void ShowMessage(string message)
        {
            lblMessage.Text = message;
        }
    }
}