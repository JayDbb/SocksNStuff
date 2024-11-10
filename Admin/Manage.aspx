<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SocksNStuff.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="d-flex">
            <h2>Products</h2>
            <asp:LinkButton runat="server" OnClick="AddModal" class="ml-3 text-white text-center rounded-2" 
                style="text-decoration:none;margin-left: 15px; margin-top: 5px; width: 30px; height: 30px; background-color: cadetblue;">+</asp:LinkButton>
        </div>

        <div class="row">
            <asp:Repeater ID="ProductsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="product-card">
                            <img src='<%# Eval("Url") %>' alt='<%# Eval("Name") %>' class="img-fluid" />

                            <!-- Product details -->
                            <div class="mx-3 mt-2">
                                <h3><%# Eval("Name") %></h3>
                                <h5>ID: <%# Eval("Id") %></h5>
                                <p>Category: <%# Eval("Category") %></p>
                                <p>Price: <%# String.Format("{0:C}", Eval("Price")) %></p>
                                <hr />
                                <p><i>Description:</i></p>
                                <p><%# Eval("Description") %></p>
                                <asp:Button class="py-2 my-2 text-white btn btn-info" CommandArgument='<%# Eval("Id") %>' 
                                    runat="server" Text="Edit" OnClick="Edit" />
                                <asp:Button class="py-2 my-2  text-white btn btn-danger"  data-toggle="modal" data-target="#delProductModal"  CommandArgument='<%# Eval("Id") %>' 
                                    runat="server" Text="Delete" OnClick="Delete" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!-- Bootstrap Modal -->
            <div class="modal fade" id="editProductModal" tabindex="-1" role="dialog" aria-labelledby="editProductModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content" style="color: black">
                        <div class="modal-header">
                            <h5 class="modal-title" id="editProductModalLabel">Edit Product</h5>
                            <button type="button" class="close bg-transparent border-0" data-dismiss="modal" aria-label="Close">
                                <span class="text-black" aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="ProductIdHiddenField" runat="server" />

                            <!-- Row for Name and Category -->
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="productName">Name</label>
                                    <asp:TextBox ID="ProductNameTextBox" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="productCategory">Category</label>
                                    <asp:TextBox ID="ProductCategoryTextBox" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <!-- Row for Price and Amount Left -->
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="productPrice">Price</label>
                                    <asp:TextBox ID="ProductPriceTextBox" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="productAmountLeft">Amount Left</label>
                                    <asp:TextBox ID="ProductAmountLeftTextBox" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <!-- Row for Description (full width) -->
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label for="productDescription">Description</label>
                                    <asp:TextBox ID="ProductDescriptionTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                                </div>
                            </div>

                            <!-- Row for Image URL (full width) -->
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label for="productUrl">Image URL</label>
                                    <asp:TextBox ID="ProductUrlTextBox" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="modal-footer">
                                <asp:Button ID="SaveProductButton" runat="server" CssClass="btn btn-primary" Text="Save Changes" OnClick="SaveChangesEdit" />
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Add Product Modal -->
            <div class="modal fade" id="addProductModal" tabindex="-1" role="dialog" aria-labelledby="addProductModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content" style="color: black">
                        <div class="modal-header">
                            <h5 class="modal-title" id="addProductModalLabel">Add Product</h5>
                            <button type="button" class="close bg-transparent border-0" data-dismiss="modal" aria-label="Close">
                                <span class="text-black" aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />

                            <!-- Row for Name and Category -->
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="name">Name</label>
                                    <asp:TextBox ID="name" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="category">Category</label>
                                    <asp:TextBox ID="category" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <!-- Row for Price and Amount Left -->
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="price">Price</label>
                                    <asp:TextBox ID="price" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="amount">Amount Left</label>
                                    <asp:TextBox ID="amount" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <!-- Row for Description (full width) -->
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label for="desc">Description</label>
                                    <asp:TextBox ID="desc" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                                </div>
                            </div>

                            <!-- Row for Image URL (full width) -->
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label for="url">Image URL</label>
                                    <asp:TextBox ID="url" runat="server" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="modal-footer">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Save Changes" OnClick="SaveChanges" />
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



              <!-- Add Product Modal -->
  <div class="modal fade" id="delProductModal" tabindex="-1" role="dialog" aria-labelledby="addProductModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-sm" role="document">
          <div class="modal-content" style="color: black">
              <div class="modal-header">
                  <asp:Label runat="server" class="modal-title" ID="delProductModalLabel"></asp:Label>
                  <button type="button" class="close bg-transparent border-0" data-dismiss="modal" aria-label="Close">
                      <span class="text-black" aria-hidden="true">&times;</span>
                  </button>
              </div>
              
                  <div class="modal-footer">
                      <asp:Button ID="del" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="SaveChangesDel" />
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                  </div>
              </div>
          </div>
      </div>
  </div>





        </div>
    </div>
</asp:Content>
