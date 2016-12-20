    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainOrders.aspx.cs" Inherits="ChallengePapaBobsSi.MaintainOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="customerOrdersGridView" runat="server" CssClass="table table-striped table-condensed table-hover" gridlines="Horizontal" CellSpacing="-1" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenCustomerOrderId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CustomerOrderId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PizzaSizePrice" HeaderText="Pizza Size Price" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="PizzaCrustPrice" HeaderText="Pizza Crust Price" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PizzaToppingPrice_Sausage" HeaderText="Topping Price - Sausage" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PizzaToppingPrice_Pepperoni" HeaderText="Topping Price - Pepperoni" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PizzaToppingPrice_Onions" HeaderText="Topping Price - Onions" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="PizzaToppingPrice_GreenPeppers" HeaderText="Topping Price - Green Peppers" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" Readonly="true" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="CustomerAddress" HeaderText="Customer Address" Readonly="true" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="CustomerZIP" HeaderText="Customer ZIP" Readonly="true" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="CustomerPhone" HeaderText="Customer Phone" Readonly="true" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="CustomerOrderPrice" HeaderText="Order Price" DataFormatString="{0:c}" Readonly="true" ItemStyle-HorizontalAlign="Right" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Order Complete?
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="isOrderComplete" AutoPostBack="true" OnCheckedChanged="isOrderCompleteCheckBox_Click" HorizontalAlignment="Center"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <h2>
        <asp:Label ID="noCustomerOrdersLabel" runat="server" Text=""></asp:Label>
        </h2>
        <asp:Button ID="returnToOrderMenu" runat="server" Text="Return to Pizza Order Menu" CssClass="btn btn-lg btn-primary" OnClick="returnToOrderMenu_Click" />
        &nbsp;
        <asp:Button ID="maintainPrices" runat="server" Text="Maintain Prices" CssClass="btn btn-lg btn-primary" OnClick="maintainPrices_Click" />
    </div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
        
    </form>
</body>
</html>
