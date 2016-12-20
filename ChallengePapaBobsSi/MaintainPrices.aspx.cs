using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChallengePapaBobsSi.Domain;
using ChallengePapaBobsSi.DTO;

namespace ChallengePapaBobsSi
{
    public partial class MaintainPrices : System.Web.UI.Page
    {
        public OrderController orderController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initialisePage();
            }
        }
        private void initialisePage()
        {
            //Reuse Order Controller and Initialise all DTO's
            orderController = new OrderController();
            //Populate DTO's and Grids
            orderController.GetPizzaSizesDTO();
            pizzaSizeGridView.DataSource = orderController.GetPizzaSizesDTO();
            pizzaSizeGridView.DataBind();

            orderController.GetPizzaCrustsDTO();
            pizzaCrustGridView.DataSource = orderController.GetPizzaCrustsDTO();
            pizzaCrustGridView.DataBind();
            
            orderController.GetPizzaToppingsDTO();
            pizzaToppingGridView.DataSource = orderController.GetPizzaToppingsDTO();
            pizzaToppingGridView.DataBind();
        }

        protected void pizzaSizeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pizzaSizeGridView.EditIndex = e.NewEditIndex;
            initialisePage();
        }

        protected void pizzaSizeGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            pizzaSizeGridView.EditIndex = -1;
            initialisePage();
        }

        protected void pizzaSizeGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PizzaSizeDTO pizzaSizeDTO = new PizzaSizeDTO();
            GridViewRow gvRow = pizzaSizeGridView.Rows[e.RowIndex];
            pizzaSizeDTO.PizzaSizeId = (Guid)pizzaSizeGridView.DataKeys[e.RowIndex].Values[0];
            pizzaSizeDTO.PizzaSizeName = ((TextBox)(gvRow.Cells[0].Controls[0])).Text;
            pizzaSizeDTO.PizzaSizeDesc = ((TextBox)(gvRow.Cells[1].Controls[0])).Text;
            pizzaSizeDTO.PizzaSizePrice = Convert.ToDecimal(((TextBox)(gvRow.Cells[2].Controls[0])).Text);
            PriceMaintenanceController.PizzaSizeDTOUpdateARow(pizzaSizeDTO);
            pizzaSizeGridView.EditIndex = -1;
            initialisePage();
        }

        protected void pizzaCrustGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pizzaCrustGridView.EditIndex = e.NewEditIndex;
            initialisePage();
        }

        protected void pizzaCrustGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            pizzaCrustGridView.EditIndex = -1;
            initialisePage();
        }

        protected void pizzaCrustGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PizzaCrustDTO pizzaCrustDTO = new PizzaCrustDTO();
            GridViewRow gvRow = pizzaCrustGridView.Rows[e.RowIndex];
            pizzaCrustDTO.PizzaCrustId = (Guid)pizzaCrustGridView.DataKeys[e.RowIndex].Values[0];
            pizzaCrustDTO.PizzaCrustType = ((TextBox)(gvRow.Cells[0].Controls[0])).Text;
            pizzaCrustDTO.PizzaCrustPrice = Convert.ToDecimal(((TextBox)(gvRow.Cells[1].Controls[0])).Text);
            PriceMaintenanceController.PizzaCrustDTOUpdateARow(pizzaCrustDTO);
            pizzaCrustGridView.EditIndex = -1;
            initialisePage();
        }

        protected void pizzaToppingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pizzaToppingGridView.EditIndex = e.NewEditIndex;
            initialisePage();
        }

        protected void pizzaToppingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            pizzaToppingGridView.EditIndex = -1;
            initialisePage();
        }

        protected void pizzaToppingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PizzaToppingDTO pizzaToppingDTO = new PizzaToppingDTO();
            GridViewRow gvRow = pizzaToppingGridView.Rows[e.RowIndex];
            pizzaToppingDTO.PizzaToppingId = (Guid)pizzaToppingGridView.DataKeys[e.RowIndex].Values[0];
            pizzaToppingDTO.PizzaToppingPrice = Convert.ToDecimal(((TextBox)(gvRow.Cells[1].Controls[0])).Text);
            PriceMaintenanceController.PizzaToppingDTOUpdateARow(pizzaToppingDTO);
            pizzaToppingGridView.EditIndex = -1;
            initialisePage();
        }
        protected void maintainOrdersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MaintainOrders.aspx");
        }
    }
}