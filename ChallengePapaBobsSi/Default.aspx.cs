using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChallengePapaBobsSi.DTO;
using ChallengePapaBobsSi.Domain;


namespace ChallengePapaBobsSi
{
    public partial class Default : System.Web.UI.Page
    {
        public OrderController orderController;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initialisePageandCustomerOrder();
                setFormFieldValidationExpressions();
            }
        }

        private void initialisePageandCustomerOrder()
        {
            //Create new Order Controller and Initialise all DTO's - which also creates a new Customer Order
            orderController = new OrderController();
            //Populate DTO's and DropDowns
            orderController.GetPizzaSizesDTO();
            orderController.GetPizzaCrustsDTO();
            orderController.GetPizzaToppingsDTO();
            OrderController.customerOrderDTO.PizzaSizePrice = setupPizzaSizeDropDown();
            OrderController.customerOrderDTO.PizzaCrustPrice = setupPizzaCrustDropDown();
            //Initialise forms fields
            initialiseFormFields();
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }

        private void setFormFieldValidationExpressions()
        {
            //Input Field Validation Settings
            nameLengthValidator.ValidationExpression = RegularExpression.MaxLength(50);
            nameLengthValidator.ErrorMessage = ValidationMessages.MaxLength(50);
            addressLengthValidator.ValidationExpression = RegularExpression.MaxLength(50);
            addressLengthValidator.ErrorMessage = ValidationMessages.MaxLength(50);
            zipLengthValidator.ValidationExpression = RegularExpression.MaxLength(10);
            zipLengthValidator.ErrorMessage = ValidationMessages.MaxLength(10);
            phoneNumberValidator.ValidationExpression = RegularExpression.PhoneNumber;
            phoneNumberValidator.ErrorMessage = ValidationMessages.PhoneNumber;
        }

        private decimal setupPizzaSizeDropDown()
        {
            //Prep a Display Field which combines the Pizza Size and Pizza Size Desc
            var pizzaSizeDescQuery = OrderController.pizzaSizesDTO.Select
                (p => new {
                    PizzaSizeId = p.PizzaSizeId,
                    PizzaSizePrice = p.PizzaSizePrice,
                    DisplayText = p.PizzaSizeName.ToString() +
                " - " + p.PizzaSizeDesc
                });

            pizzaSizeDropDownList.DataSource = pizzaSizeDescQuery;
            pizzaSizeDropDownList.DataTextField = "DisplayText";
            pizzaSizeDropDownList.DataValueField = "PizzaSizePrice";
            pizzaSizeDropDownList.DataBind();
            pizzaSizeDropDownList.SelectedIndex = 2;
            return Convert.ToDecimal(pizzaSizeDropDownList.SelectedValue);
        }

        private decimal setupPizzaCrustDropDown()
        {
            pizzaCrustDropDownList.DataSource = OrderController.pizzaCrustsDTO;
            pizzaCrustDropDownList.DataTextField = "PizzaCrustType";
            pizzaCrustDropDownList.DataValueField = "PizzaCrustPrice";
            pizzaCrustDropDownList.DataBind();
            pizzaCrustDropDownList.SelectedIndex = 1;
            return Convert.ToDecimal(pizzaCrustDropDownList.SelectedItem.Value);
        }

        private void initialiseFormFields()
        {
            //Default Settings for form fields
            sausageCheckBox.Checked = false;
            pepperoniCheckBox.Checked = false;
            onionsCheckBox.Checked = false;
            greenPeppersCheckBox.Checked = false;
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            phoneTextBox.Text = "";
            zipTextBox.Text = "";
        }

        private void calcOrderPriceAndDisplay()
        {
            OrderController.customerOrderDTO.CustomerOrderPrice = OrderController.PriceOrder();
            totalCostValueLabel.Text = OrderController.customerOrderDTO.CustomerOrderPrice.ToString("c");
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            OrderController.customerOrderDTO.CustomerOrderId = Guid.NewGuid();
            OrderController.customerOrderDTO.CustomerName = nameTextBox.Text;
            OrderController.customerOrderDTO.CustomerAddress = addressTextBox.Text;
            OrderController.customerOrderDTO.CustomerZIP = zipTextBox.Text;
            OrderController.customerOrderDTO.CustomerPhone = phoneTextBox.Text;
            OrderController.customerOrderDTO.CustomerOrderTimeStamp = DateTime.Now;
            //Insert new row into database here and refesh DTO object
            OrderController.CustomerDTOAddARow(OrderController.customerOrderDTO);
            //Reinitialise the form
            Response.Redirect("~/Default.aspx");
        }

        protected void maintainOrdersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MaintainOrders.aspx");
        }

        protected void pizzaSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderController.customerOrderDTO.PizzaSizePrice = Convert.ToDecimal(pizzaSizeDropDownList.SelectedValue);
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }

        protected void pizzaCrustDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderController.customerOrderDTO.PizzaCrustPrice = Convert.ToDecimal(pizzaCrustDropDownList.SelectedValue);
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }

        protected void sausageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sausageCheckBox.Checked)
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_Sausage =
                OrderController.pizzaToppingsDTO
                .Single(p => p.PizzaToppingName == "Sausage").PizzaToppingPrice;
            }
            else
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_Sausage = 0.0m;
            }
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }

        protected void pepperoniCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pepperoniCheckBox.Checked)
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_Pepperoni =
                OrderController.pizzaToppingsDTO
                .Single(p => p.PizzaToppingName == "Pepperoni").PizzaToppingPrice;
            }
            else
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_Pepperoni = 0.0m;
            }
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }

        protected void onionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (onionsCheckBox.Checked)
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_Onions =
                OrderController.pizzaToppingsDTO
                .Single(p => p.PizzaToppingName == "Onions").PizzaToppingPrice;
            }
            else
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_Onions = 0.0m;
            }
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }

        protected void greenPeppersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (greenPeppersCheckBox.Checked)
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_GreenPeppers =
                OrderController.pizzaToppingsDTO
                .Single(p => p.PizzaToppingName == "Green Peppers").PizzaToppingPrice;
            }
            else
            {
                OrderController.customerOrderDTO.PizzaToppingPrice_GreenPeppers = 0.0m;
            }
            //Price and display default Pizza price
            calcOrderPriceAndDisplay();
        }
    }
}