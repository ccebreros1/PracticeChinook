using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Security Namespace
using ChinookSystem.Security;
#endregion
public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RefreshAll(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void UnregisteredUsersGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //position the gridview to the selected index (row) that caused the postback
        UnregisteredUsersGridView.SelectedIndex = e.NewSelectedIndex;

        //Setup a variabnle that will be the physiscal pointer to the selected row
        GridViewRow agvrow = UnregisteredUsersGridView.SelectedRow;

        //You can always check a pointer to see if something has been obtained
        if (agvrow != null)
        {
            //access information contained in a textbox on the gridview row
            //use the method (without single quotes)'.FindControl("ControlIdName") as controltype'
            //once you have a pointer to the control you can access the data content of the control using the control's access method

            string assignedUserName = "";
            TextBox inputControl = agvrow.FindControl("AssignedUserName") as TextBox;
            if(inputControl!=null)
            {
                assignedUserName = inputControl.Text;
            }
            string assignedEmail = (agvrow.FindControl("AssignedEmail") as TextBox).Text;

            //Create the unregistered user instance
            //During the creation I will pass to it the needed data to load the instance attributes
            //Accessing bound fields on a GridView row uses '.Cells[index].Text'
            //index represents the column of the grid
            //columns are indexed (starting at 0)
            UnregisteredUserProfile user = new UnregisteredUserProfile()
            {
                UserId = int.Parse(UnregisteredUsersGridView.SelectedDataKey.Value.ToString()),
                UserType = (UnregisteredUserType)Enum.Parse(typeof(UnregisteredUserType), agvrow.Cells[1].Text),
                FirstName = agvrow.Cells[2].Text,
                LastName = agvrow.Cells[3].Text,
                UserName = assignedUserName,
                Email = assignedEmail
            };

            UserManager sysmgr = new UserManager();
            sysmgr.RegisteredUser(user);

            //Assume successful creation of user
            //Refresh the form
            DataBind();
        }
    }
}