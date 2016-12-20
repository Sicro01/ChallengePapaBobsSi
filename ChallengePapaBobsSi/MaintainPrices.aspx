<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainPrices.aspx.cs" Inherits="ChallengePapaBobsSi.MaintainPrices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="container">
        <asp:GridView ID="pizzaSizeGridView" runat="server" CssClass="table table-striped table-condensed table-hover" gridlines="Horizontal" CellSpacing="-1" AutoGenerateColumns="false" 
            DataKeyNames="PizzaSizeId" OnRowEditing="pizzaSizeGridView_RowEditing" OnRowCancelingEdit="pizzaSizeGridView_RowCancelingEdit" OnRowUpdating="pizzaSizeGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="PizzaSizeName" HeaderText="Pizza 'Size' Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                <asp:BoundField DataField="PizzaSizeDesc" HeaderText="Pizza 'Size' Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                <asp:BoundField DataField="PizzaSizePrice" HeaderText="Pizza 'Size' Price" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
                <asp:CommandField ShowEditButton="true" />
            </Columns>
         </asp:GridView>
        </div>
        <div class="container">
        <asp:GridView ID="pizzaCrustGridView" runat="server" CssClass="table table-striped table-condensed table-hover" gridlines="Horizontal" CellSpacing="-1" AutoGenerateColumns="false" 
            DataKeyNames="PizzaCrustId" OnRowEditing="pizzaCrustGridView_RowEditing" OnRowCancelingEdit="pizzaCrustGridView_RowCancelingEdit" OnRowUpdating="pizzaCrustGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="PizzaCrustType" HeaderText="Pizza Crust Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" />
                <asp:BoundField DataField="PizzaCrustPrice" HeaderText="Pizza Crust Price" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" />
                <asp:CommandField ShowEditButton="true" />
            </Columns>
         </asp:GridView>
        </div>
         <div class="container">
        <asp:GridView ID="pizzaToppingGridView" runat="server" CssClass="table table-striped table-condensed table-hover" gridlines="Horizontal" CellSpacing="-1" AutoGenerateColumns="false" 
            DataKeyNames="PizzaToppingId" OnRowEditing="pizzaToppingGridView_RowEditing" OnRowCancelingEdit="pizzaToppingGridView_RowCancelingEdit" OnRowUpdating="pizzaToppingGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="PizzaToppingName" HeaderText="Pizza Topping Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" Readonly="true"/>
                <asp:BoundField DataField="PizzaToppingPrice" HeaderText="Pizza Topping Price" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" />
                <asp:CommandField ShowEditButton="true" />
            </Columns>
         </asp:GridView>
        </div>
         <div><asp:Button ID="maintainOrdersButton" runat="server" Text="Maintain Orders" CssClass="btn btn-lg btn-primary" OnClick="maintainOrdersButton_Click" CausesValidation="false" /></div>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    </form>
</body>
</html>
