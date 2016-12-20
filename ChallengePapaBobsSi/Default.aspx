<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengePapaBobsSi.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="shadowbox">
        <div class="page-header">
        <div class="container">
            <div>
                <h2 class="text-danger">Bob's Pizza </h2> 
                <p class="lead"> Pizza to Code By</p>
            </div>

            <div class="form-group">
                <label>Size:</label>
                <asp:DropDownList ID="pizzaSizeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="pizzaSizeDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            
            <div class="form-group">
                <label>Crust:</label>
                <asp:DropDownList ID="pizzaCrustDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="pizzaCrustDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            
            <div class="checkbox"><label><asp:CheckBox ID="sausageCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="sausageCheckBox_CheckedChanged"></asp:CheckBox> Sausage</label>
            </div>
            <div class="checkbox"><label><asp:CheckBox ID="pepperoniCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="pepperoniCheckBox_CheckedChanged"></asp:CheckBox> Pepperoni</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="onionsCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="onionsCheckBox_CheckedChanged"></asp:CheckBox> Onions</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="greenPeppersCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="greenPeppersCheckBox_CheckedChanged"></asp:CheckBox> Green Peppers</label></div>
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

            <div class="form-group">
                <label>Name:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTextBox" Display="Dynamic" ErrorMessage="Please enter your name.">*
                </asp:RequiredFieldValidator>
                &nbsp;
                <asp:RegularExpressionValidator ID="nameLengthValidator" runat="server" ControlToValidate="nameTextBox"></asp:RegularExpressionValidator>
                &nbsp;
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox> 
            </div>

            <div class="form-group">
                <label>Address:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="addressTextBox" Display="Dynamic" ErrorMessage="Please enter your address.">*
                </asp:RequiredFieldValidator>
                &nbsp;
                <asp:RegularExpressionValidator ID="addressLengthValidator" runat="server" ControlToValidate="addressTextBox"></asp:RegularExpressionValidator>
                &nbsp;
                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox>          
            </div>
            <div class="form-group">
                <label>Zip:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="zipTextBox" Display="Dynamic" ErrorMessage="Please enter your ZIP code.">*
                </asp:RequiredFieldValidator>
                &nbsp;
                <asp:RegularExpressionValidator ID="zipLengthValidator" runat="server" ControlToValidate="zipTextBox"></asp:RegularExpressionValidator>
                &nbsp;
                <asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control"></asp:TextBox>          
            </div>
            <div class="form-group">
                <label>Phone:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="phoneTextBox" Display="Dynamic" ErrorMessage="Please enter your phone number.">*
                </asp:RequiredFieldValidator>
                &nbsp;
                <asp:RegularExpressionValidator ID="phoneNumberValidator" runat="server" ControlToValidate="phoneTextBox"></asp:RegularExpressionValidator>
                &nbsp;
                <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>          
            </div>
            
            <div class="radio">
                <label><asp:RadioButton ID="cashPaymentRadioButton" runat="server" GroupName="PaymentGroup" Checked="True"></asp:RadioButton> Cash</label>
            </div>
            <div class="radio">
                <label><asp:RadioButton ID="creditPaymentRadioButton" runat="server" GroupName="PaymentGroup"></asp:RadioButton> Credit</label>
            </div>
             
            <div><asp:Button ID="orderButton" runat="server" Text="Order" CssClass="btn btn-lg btn-primary" OnClick="orderButton_Click" /></div>
            
            <asp:Label ID="totalCostDescLabel" runat="server" Text="Total Cost: "></asp:Label>
            <asp:Label ID="totalCostValueLabel" runat="server" Text="Hello"></asp:Label>
            
            <div><asp:Button ID="maintainOrdersButton" runat="server" Text="Maintain Orders" CssClass="btn btn-lg btn-primary" OnClick="maintainOrdersButton_Click" CausesValidation="false" /></div>
            
          </div>
          </div>
            </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    </form>    
</body>
</html>
