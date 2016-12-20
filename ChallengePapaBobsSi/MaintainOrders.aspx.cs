using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChallengePapaBobsSi.DTO;
using ChallengePapaBobsSi.Domain;
using System.Diagnostics;


namespace ChallengePapaBobsSi
{
    public partial class MaintainOrders : System.Web.UI.Page
    {
        public OrderMaintenanceController orderMaintenanceController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Initialise DataGrid
                initialiseMaintainOrdersController();
                bindDataToGridView();
            }
        }
        private void initialiseMaintainOrdersController()
        {
            orderMaintenanceController = new OrderMaintenanceController();
            orderMaintenanceController.customerOrdersDTO = orderMaintenanceController.GetCustomerOrdersDTO();
        }

        private void bindDataToGridView()
        {
            noCustomerOrdersLabel.Text = "";
            if (orderMaintenanceController.customerOrdersDTO.Count != 0)
            {
                customerOrdersGridView.DataSource = orderMaintenanceController.customerOrdersDTO;
                customerOrdersGridView.DataBind();
            }
            else
            {
                noCustomerOrdersLabel.Text = "Your work is done - have a break!";
                customerOrdersGridView.DataSource = orderMaintenanceController.customerOrdersDTO;
                customerOrdersGridView.DataBind();
            }
        }
        
        protected void isOrderCompleteCheckBox_Click(object sender, EventArgs e)
        {
            //Update OrderComplete 'Flag'
            CheckBox chk = sender as CheckBox;
            int customerOrderComplete = (chk.Checked) ? 1 : 0;
            //Gran the Grid View Row
            GridViewRow gvRow = (GridViewRow)chk.NamingContainer;
            //Parse the Customer Order GUID
            HiddenField hiddenCustomerOrderId = (HiddenField)gvRow.FindControl("hiddenCustomerOrderId");
            Guid customerOrderId;
            Guid.TryParse(hiddenCustomerOrderId.Value, out customerOrderId);
            //Update the Order
            OrderMaintenanceController.CustomerDTOUpdateARow(customerOrderId, customerOrderComplete);
            //Re-bind the data to the grid
            initialiseMaintainOrdersController();
            bindDataToGridView();
        }

        protected void returnToOrderMenu_Click(object sender, EventArgs e)
        {
            //Return to the Pizza order form
            Response.Redirect("~/Default.aspx");
        }

        protected void maintainPrices_Click(object sender, EventArgs e)
        {
            //Return to the Pizza order form
            try
            {
                Response.Redirect("~/MaintainPrices.aspx");
            }
            catch (Exception exp)
            {
                System.Diagnostics.Trace.TraceInformation($"Error: {exp.InnerException}");
            }            
        }
    }
}