<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ListProduct.aspx.cs" Inherits="DemoDotNet.Webform.ListProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%if (Session["Message"] != null){%>
            <div class="alert alert-<%Response.Write(Session["Status"].ToString());%>">
               <%
                   Response.Write(Session["Message"].ToString());
                   Session["Message"] = null;
               %>
            </div>
        <%}%>
        <asp:HiddenField ID="txtID" runat="server"/>
        <div class="form-group">
          <label>Tên sản phẩm</label>
             <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="">Tên danh mục</label>
          <asp:DropDownList ID="DDLCategory" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
          <label for="">Hình ảnh</label>
          <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
          <label>Mô tả</label>
          <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Giá</label>
          <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Số lượng</label>
          <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label>Trạng thái</label>
          <asp:CheckBox ID="cboxStatus" runat="server" />
        </div>
        <asp:Button ID="btnAdd" runat="server" Text="Thêm" CssClass="btn btn-default" OnClick="btnAdd_Click"/>
    </div>
    <h3>Danh sách sản phẩm</h3>
     <input class="form-control" id="txtSearch" type="text" placeholder="Tìm kiếm..."><br />
    <asp:Repeater ID="RepeaterList" runat="server">
    <HeaderTemplate>          
          <table class="table table-bordered table-striped">
            <thead>
              <tr>
                <th>Hình ảnh</th>
                <th>Tên sản phẩm</th>
                <th>Giá</th>
                <th>Số lượng</th>
                <th>Trang thái</th>
                <th></th>
              </tr>
            </thead> 
            <tbody id="myTable">
        </HeaderTemplate>
       <ItemTemplate>        
          <tr>
            <td>
                <asp:Label ID="lbID" runat="server" Text='<%# Eval("ID")%>' Visible ="false"></asp:Label>
                <img width="200" src="Images/<%#Eval("Image")%>"/>
            </td>
            <td><%#Eval("Name")%></td>
            <td><%#Eval("Price")%></td>
            <td><%#Eval("Quantity")%></td>
            <td><%#Eval("Status").ToString().Equals("True") ? "Hiển thị":"Ẩn" %></td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server"  OnClick="OnSelect">Chọn |</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server"  OnClick="OnDelete"> Xóa</asp:LinkButton>
            </td>
          </tr>          
        </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
    </asp:Repeater>
    <script>
        $(document).ready(function(){
            $("#txtSearch").on("keyup", function() {
                var value = $(this).val().toLowerCase();
                $("#myTable tr").filter(function() {
                  $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>
</asp:Content>
