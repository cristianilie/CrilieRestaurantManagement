using Dapper;
using RMLibrary.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace RMLibrary.DataAcces
{
    public class SqlConnection
    {
        private const string dbName = "RMS";

        public  string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Creates a new Category in the database, in the Category Table
        /// </summary>
        /// <param name="model">The new Category model</param>
        /// <returns></returns>
        public CategoryModel CreateCategory(CategoryModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spCategory_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Company in the database
        /// </summary>
        /// <param name="model">The new Company model</param>
        /// <returns></returns>
        public CompanyModel CreateCompany(CompanyModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Data", model.Data);
                parameters.Add("@Adress", model.Adress);
                parameters.Add("@DeliveryAdress", model.DeliveryAdress);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spCompany_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Customer entity in the database
        /// </summary>
        /// <param name="model">The new Customer model</param>
        /// <returns></returns>
        public CustomerModel CreateCustomer(CustomerModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@DeliveryAdress", model.DeliveryAdress);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spCustomer_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Sales Price entity in the database
        /// </summary>
        /// <param name="model">The new Sales Price model</param>
        /// <returns></returns>
        public SalesPriceModel CreateSalesPrice(SalesPriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@SalesPrice", model.SalesPrice);
                parameters.Add("@CurrentlyActivePrice", model.CurrentlyActivePrice);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spSalesPrice_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Purchase Price entity in the database
        /// </summary>
        /// <param name="model">The new Purchase Price model</param>
        /// <returns></returns>
        public PurchasePriceModel CreatePurchasePrice(PurchasePriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@PurchasePrice", model.PurchasePrice);
                parameters.Add("@PurchaseDate", model.PurchaseDate);
                parameters.Add("@PurchaseOrderId", model.PurchaseOrderId);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPurchasePrice_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Product entity in the database
        /// </summary>
        /// <param name="model">The new Product model</param>
        /// <returns></returns>
        public ProductModel CreateProduct(ProductModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@RecipeId", model.RecipeId);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spProduct_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Product Recipe entity in the database
        /// </summary>
        /// <param name="model">The new Product Recipe model</param>
        /// <returns></returns>
        public RecipeModel CreateRecipe(RecipeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spRecipe_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Deletes a Product Recipe entry from the database
        /// </summary>
        /// <param name="model">The Product Recipe about to be deleted</param>
        /// <returns></returns>
        public void DeleteRecipe(RecipeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                connection.Execute("dbo.spRecipe_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Deletes a "Sales Order Product" entry from the database
        /// </summary>
        /// <param name="model">The "Sales Order Product" about to be deleted</param>
        /// <returns></returns>
        public void Delete_SO_Product(OrderProductModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                connection.Execute("dbo.spSalesOrderProduct_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Deletes a "Sales Order" entry from the database
        /// </summary>
        /// <param name="model">The "Sales Order" about to be deleted</param>
        /// <returns></returns>
        public void Delete_SalesOrder(SalesOrderModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                connection.Execute("dbo.spSalesOrder_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Deletes a Sales Price entry from the database
        /// </summary>
        /// <param name="model">The Sales Price about to be deleted</param>
        /// <returns></returns>
        public void DeleteSalesPrice(SalesPriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                connection.Execute("dbo.spSalesPrice_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Deletes a Purchase Price entry from the database
        /// </summary>
        /// <param name="model">The Purchase Price about to be deleted</param>
        /// <returns></returns>
        public void DeletePurchasePrice(PurchasePriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                connection.Execute("dbo.spPurchasePrice_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Gets a Purchase Price entry from the database by the PO Id & product Id 
        /// </summary>
        /// <param name="model">Purchase Order Id, Product Id</param>
        /// <returns></returns>
        public PurchasePriceModel GetPurchasePrice_By_Id(int poId, int productId)
        {
            PurchasePriceModel price = new PurchasePriceModel();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PurchaseOrderId", poId);
                parameters.Add("@ProductId", productId);
                price = connection.Query<PurchasePriceModel>("dbo.spGetPurchasePrice_ById", parameters, commandType: CommandType.StoredProcedure).Single();
            }
            return price;
        }

        /// <summary>
        /// Gets a Product Model entry from the database by product Id 
        /// </summary>
        /// <param name="model">Purchase Order Id, Product Id</param>
        /// <returns></returns>
        public ProductModel GetProductModel_By_Id(int productId)
        {
            ProductModel product = new ProductModel();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", productId);
                product = connection.Query<ProductModel>("dbo.spGetProductModel_ById", parameters, commandType: CommandType.StoredProcedure).Single();
            }
            return product;
        }

        /// <summary>
        /// Gets a Purchase Order Product List from the database by the PO Id 
        /// </summary>
        /// <param name="model">Purchase Order Id</param>
        /// <returns></returns>
        public List<OrderProductModel> GetPurchaseOrderProductList_ByPO_Id(int poId)
        {
            List<OrderProductModel> output = new List<OrderProductModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", poId);
                output = connection.Query<OrderProductModel>("dbo.spGetPurchaseOrderProduct_ByPOId", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Creates a new Recipe Content entry in the database
        /// Recipe Content represents the ingredients of the recipe associated by RecipeId, and ProductId + ProductQuantity
        /// </summary>
        /// <param name="model">The Recipe - Recipe Content association</param>
        /// <returns></returns>
        public RecipeContentModel CreateRecipeContent(RecipeContentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecipeId", model.RecipeId);
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@ProductQuantity", model.ProductQuantity);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spRecipeContent_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Deletes a  Recipe Content entry in the database by RecipeId, and ProductId
        /// Recipe Content represents the ingredients of the recipe associated by RecipeId, and ProductId + ProductQuantity
        /// </summary>
        /// <param name="model">The Recipe - Recipe Content association</param>
        /// <returns></returns>
        public RecipeContentModel RemoveRecipeContent(RecipeContentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecipeId", model.RecipeId);
                parameters.Add("@ProductId", model.ProductId);

                connection.Execute("dbo.spRecipeContent_RemoveItem", parameters, commandType: CommandType.StoredProcedure);


                return model;
            }
        }

        /// <summary>
        /// Creates a new Table(table where people sit & eat/drink) entity in the database
        /// </summary>
        /// <param name="model">The new Table model</param>
        /// <returns></returns>
        public TableModel CreateTable(TableModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTable_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Tax entity in the database
        /// </summary>
        /// <param name="model">The new Tax model</param>
        /// <returns></returns>
        public TaxModel CreateTax(TaxModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Percent", model.Percent);
                parameters.Add("@DefaultSelectedTax", model.DefaultSelectedTax);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTax_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Product Category association in the database
        /// </summary>
        /// <param name="model">The new Product Category model</param>
        /// <returns></returns>
        public ProductCategoryModel CreateProductCategory(ProductCategoryModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@CategoryId", model.CategoryId);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spProductCategory_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Retrieves a list of Product Category items that match the id of the product model we filter by
        /// </summary>
        /// <param name="model">The Product  model we filter by </param>
        /// <returns></returns>
        public List<ProductCategoryModel> GetRecord_ProductCategory(ProductModel model)
        {
            List<ProductCategoryModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.Id);

                output = connection.Query<ProductCategoryModel>("dbo.spProductCategory_GetRecords", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all Product Category items 
        /// </summary>
        /// <returns></returns>
        public List<ProductCategoryModel> GetProductCategories_All()
        {
            List<ProductCategoryModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<ProductCategoryModel>("dbo.spProductCategory_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all sales prices 
        /// </summary>
        /// <returns></returns>
        public List<SalesPriceModel> GetSalesPrices_All()
        {
            List<SalesPriceModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<SalesPriceModel>("dbo.spSalesPrices_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all purchase prices ordered by newest entry
        /// </summary>
        /// <returns></returns>
        public List<PurchasePriceModel> GetPurchasePrices_All()
        {
            List<PurchasePriceModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<PurchasePriceModel>("dbo.spPurchasePrices_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all Tax entries 
        /// </summary>
        /// <returns></returns>
        public List<TaxModel> GetTaxes_All()
        {
            List<TaxModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<TaxModel>("dbo.spTaxes_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all Sales Order Product entries/associations 
        /// </summary>
        /// <returns></returns>
        public List<OrderProductModel> Get_SO_Products_BySO_Id(int salesOrderId)
        {
            List<OrderProductModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", salesOrderId);

                output = connection.Query<OrderProductModel>("dbo.spSalesOrderProduct_GetBySO_Id", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all Purchase Orders entries/associations 
        /// </summary>
        /// <returns></returns>
        public List<PurchaseOrderModel> GetPurchaseOrders_All()
        {
            List<PurchaseOrderModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<PurchaseOrderModel>("dbo.spPurchaseOrders_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a list of all Purchase Invoice entries 
        /// </summary>
        /// <returns></returns>
        public List<PurchaseInvoiceModel> GetPurchaseInvoices_All()
        {
            List<PurchaseInvoiceModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<PurchaseInvoiceModel>("dbo.spPurchaseInvoices_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        /// <summary>
        /// Retrieves a a single ProductStock entry
        /// </summary>
        /// <returns></returns>
        public ProductStockModel GetProductStock_Single(int productId)
        {
            ProductStockModel product;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", productId);
                product =  connection.Query<ProductStockModel>("dbo.spProductStock_GetSingle", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            return product;
        }

        /// <summary>
        /// Retrieves a a single Product Sales Price entry
        /// </summary>
        /// <returns></returns>
        public List<SalesPriceModel> GetProduct_SalesPrice_ByProductId(int productId)
        {
            List<SalesPriceModel> productPrices = new List<SalesPriceModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", productId);
                productPrices = connection.Query<SalesPriceModel>("dbo.spSalesPrice_GetByProductId", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return productPrices;
        }

        /// <summary>
        /// Creates a new Product Stock association in the database
        /// Reflects the "quantity in stock" of a product
        /// </summary>
        /// <param name="model">The new Product Stock model</param>
        /// <returns></returns>
        public ProductStockModel CreateProductStock(ProductStockModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@Quantity", model.Quantity);
                parameters.Add("@AvailableQuantity", model.AvailableQuantity);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spProductStock_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Sales Order in the database
        /// </summary>
        /// <param name="model">The new Sales Order model</param>
        /// <returns></returns>
        public SalesOrderModel CreateSalesOrder(SalesOrderModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", model.Status);
                parameters.Add("@TableId", model.TableId);
                parameters.Add("@CustomerId", model.CustomerId);
                parameters.Add("@CompanyId", model.CompanyId);
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spSalesOrder_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }



        /// <summary>
        /// Creates a new Purchase Order in the database
        /// </summary>
        /// <param name="model">The new Purchase Order model</param>
        /// <returns></returns>
        public PurchaseOrderModel CreatePurchaseOrder(PurchaseOrderModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", model.Status);
                parameters.Add("@SupplierId", model.SupplierId);
                parameters.Add("@SupplierName", model.SupplierName);
                parameters.Add("@PostingDate", model.PostingDate);
                parameters.Add("@DueDate", model.DueDate);
                parameters.Add("@DocumentDate", model.DocumentDate);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPurchaseOrder_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Purchase Invoice in the database
        /// </summary>
        /// <param name="model">The new Purchase Invoice model</param>
        /// <returns></returns>
        public PurchaseInvoiceModel CreatePurchaseInvoice(PurchaseInvoiceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RelatedPurchaseOrderId", model.RelatedPurchaseOrderId);
                parameters.Add("@Status", model.Status);
                parameters.Add("@SupplierId", model.SupplierId);
                parameters.Add("@SupplierName", model.SupplierName);
                parameters.Add("@PostingDate", model.PostingDate);
                parameters.Add("@DueDate", model.DueDate);
                parameters.Add("@DocumentDate", model.DocumentDate);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPurchaseInvoice_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new Payment Term association in the database
        /// </summary>
        /// <param name="model">The new Payment Term model</param>
        /// <returns></returns>
        public PaymentTermsModel CreatePaymentTerm(PaymentTermsModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PaymentTerm_Days", model.PaymentTerm_Days);
                parameters.Add("@IsDefaultPaymentTerm", model.IsDefaultPaymentTerm);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPaymentTerm_Days_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

                return model;
            }
        }

        /// <summary>
        /// Returns a list with all the products in the Product table, ordered by name
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts_All()
        {
            List<ProductModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<ProductModel>("dbo.spProducts_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Returns a list with all the Payment Term days in the  PaymentTerms table
        /// </summary>
        /// <returns></returns>
        public List<PaymentTermsModel> GetPaymentTerms_All()
        {
            List<PaymentTermsModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<PaymentTermsModel>("dbo.spPaymentTerms_GetAll").ToList();
            }
            return output;
        }



        /// <summary>
        /// Returns a list with all the recipes in the Recipe table, ordered by name
        /// </summary>
        /// <returns></returns>
        public List<RecipeModel> GetRecipes_All()
        {
            List<RecipeModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<RecipeModel>("dbo.spRecipes_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Returns a list with all the Products asociated with a recipe
        /// </summary>
        /// <returns></returns>
        public List<RecipeContentModel> GetRecipe_Content(RecipeModel model)
        {
            List<RecipeContentModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecipeId", model.Id);

                output = connection.Query<RecipeContentModel>("dbo.spRecipeContent_GetAll", parameters,commandType: CommandType.StoredProcedure).ToList();

            }
            return output;
        }

        /// <summary>
        /// Returns a list with Product/Recipe/RecipeContent atributes joined
        /// </summary>
        /// <returns></returns>
        public List<RecipeAndContentModel> GetRecipeAndContent(RecipeModel model)
        {
            List<RecipeAndContentModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecipeId", model.Id);

                output = connection.Query<RecipeAndContentModel>("dbo.spRecipeContentProduct_GetJoined", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }


        /// <summary>
        /// Returns a list with all the product categories in the Categories table, ordered by name
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetCategories_All()
        {
            List<CategoryModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<CategoryModel>("dbo.spCategories_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Returns a list with all the Sales Orders in the SalesOrder table, ordered by name
        /// </summary>
        /// <returns></returns>
        public List<SalesOrderModel> GetSalesOrders_All()
        {
            List<SalesOrderModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<SalesOrderModel>("dbo.spSalesOrder_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Returns a list with all the tables(tables to sit @ restaurant in the "Table" table) in database ordered by name
        /// </summary>
        /// <returns></returns>
        public List<TableModel> GetTables_All()
        {
            List<TableModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<TableModel>("dbo.spTables_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Returns a list with all the tables(tables to sit @ restaurant in the "Table" table) in database ordered by name
        /// </summary>
        /// <returns></returns>
        public List<CompanyModel> GetCompanies_All()
        {
            List<CompanyModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<CompanyModel>("dbo.spCompanies_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Returns a a single Company entry, matchind the id passed as a parameter
        /// </summary>
        /// <returns></returns>
        public CompanyModel GetCompany_Single(int companyId)
        {
            CompanyModel output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", companyId);
                output = connection.Query<CompanyModel>("dbo.spCompany_GetSingle", parameters, commandType: CommandType.StoredProcedure).Single();
            }
            return output;
        }


        /// <summary>
        /// Returns a list with all the entries in the Customer table, ordered by first name
        /// </summary>
        /// <returns></returns>
        public List<CustomerModel> GetCustomers_All()
        {
            List<CustomerModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                output = connection.Query<CustomerModel>("dbo.spCustomers_GetAll").ToList();
            }
            return output;
        }

        /// <summary>
        /// Creates a new Sales Order product association in the database
        /// </summary>      
        /// <param name="opModel">The Order Product that is about to get inserted to the database and associated with the Sales/Purchase Order</param>
        public void Create_SO_Product(OrderProductModel opModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", opModel.ProductId);
                parameters.Add("@ProductName", opModel.ProductName);
                parameters.Add("@OrderId", opModel.OrderId);
                parameters.Add("@OrderedQuantity", opModel.OrderedQuantity);
                parameters.Add("@TaxId", opModel.TaxId);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spSalesOrderProduct_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Creates a new Purchase Order product association in the database
        /// </summary>      
        /// <param name="">The database connection</param>
        /// <param name="opModel">The Order Product that is about to get inserted to the database and associated with the Sales/Purchase Order</param>
        public void Create_PO_Product(OrderProductModel opModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", opModel.ProductId);
                parameters.Add("@ProductName", opModel.ProductName);
                parameters.Add("@OrderId", opModel.OrderId);
                parameters.Add("@OrderedQuantity", opModel.OrderedQuantity);
                parameters.Add("@TaxId", opModel.TaxId);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPurchaseOrderProduct_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        /// <summary>
        /// Updates category details in the database
        /// </summary>
        /// <param name="model">the category item we want to update</param>
        /// <returns></returns>
        public void UpdateCategoryModel(CategoryModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spCategory_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        /// <summary>
        /// Updates a recipes details in the database
        /// </summary>
        /// <param name="model">The recipe item we want to update</param>
        /// <returns></returns>
        public void UpdateRecipeModel(RecipeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spRecipe_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a Purchase Order entry details in the database
        /// </summary>
        /// <param name="model">The Purchase Order we want to update</param>
        /// <returns></returns>
        public void UpdatePurchaseOrderModel(PurchaseOrderModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", model.Status);
                parameters.Add("@SupplierId", model.SupplierId);
                parameters.Add("@SupplierName", model.SupplierName);
                parameters.Add("@PostingDate", model.PostingDate);
                parameters.Add("@DueDate", model.DueDate);
                parameters.Add("@DocumentDate", model.DocumentDate);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spPurchaseOrder_Update", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// Updates a Purchase Invoice details in the database
        /// </summary>
        /// <param name="model">The Purchase Invoice we want to update</param>
        /// <returns></returns>
        public void UpdatePurchaseInvoiceModel(PurchaseInvoiceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RelatedPurchaseOrderId", model.RelatedPurchaseOrderId);
                parameters.Add("@Status", model.Status);
                parameters.Add("@SupplierId", model.SupplierId);
                parameters.Add("@SupplierName", model.SupplierName);
                parameters.Add("@PostingDate", model.PostingDate);
                parameters.Add("@DueDate", model.DueDate);
                parameters.Add("@DocumentDate", model.DocumentDate);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spRecipe_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a Sales Order's details in the database
        /// </summary>
        /// <param name="model">The Sales Order entry we want to update</param>
        /// <returns></returns>
        public void UpdateSalesOrderModel(SalesOrderModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", model.Status);
                parameters.Add("@TableId", model.TableId);
                parameters.Add("@CustomerId", model.CustomerId);
                parameters.Add("@CompanyId", model.CompanyId);
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spSalesORder_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        /// <summary>
        /// Updates a ProductStock details in the database
        /// </summary>
        /// <param name="model">The ProductStock entry we want to update</param>
        /// <returns></returns>
        public void UpdateProductStockModel(ProductStockModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@Quantity", model.Quantity);
                parameters.Add("@BookedQuantity", model.BookedQuantity);
                parameters.Add("@AvailableQuantity", model.AvailableQuantity);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spProductStock_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a Payment Term in the database
        /// </summary>
        /// <param name="model">The Payment Term we want to update</param>
        /// <returns></returns>
        public void UpdatePaymentTermModel(PaymentTermsModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PaymentTerm_Days", model.PaymentTerm_Days);
                parameters.Add("@IsDefaultPaymentTerm", model.IsDefaultPaymentTerm);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spPaymentTerm_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }



        /// <summary>
        /// Updates a "Sales Order Product" entry in the database
        /// </summary>
        /// <param name="model">The "Sales Order Product" we want to update</param>
        /// <returns></returns>
        public void Update_SO_Product(OrderProductModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@ProductName", model.ProductName);
                parameters.Add("@OrderId", model.OrderId);
                parameters.Add("@OrderedQuantity", model.OrderedQuantity);
                parameters.Add("@TaxId", model.TaxId);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spSalesOrderProduct_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        /// <summary>
        /// Updates a a product Sales Price entry in the database
        /// </summary>
        /// <param name="model">The product Sales Price we want to update</param>
        /// <returns></returns>
        public void UpdateSalesPriceModel(SalesPriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@SalesPrice", model.SalesPrice);
                parameters.Add("@CurrentlyActivePrice", model.CurrentlyActivePrice);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spSalesPrice_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a a product Purchase Price entry in the database
        /// </summary>
        /// <param name="model">The product Purchase Price we want to update</param>
        /// <returns></returns>
        public void UpdatePurchasePriceModel(PurchasePriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@PurchasePrice", model.PurchasePrice);
                parameters.Add("@PurchaseOrderId", model.PurchaseOrderId);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spPurchasePrice_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        /// <summary>
        /// Updates a recipes details in the database
        /// </summary>
        /// <param name="model">The recipe item we want to update</param>
        /// <returns></returns>
        public void UpdateTaxModel(TaxModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Percent", model.Percent);
                parameters.Add("@DefaultSelectedTax", model.DefaultSelectedTax);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spTax_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a company's details in the database
        /// </summary>
        /// <param name="model">The company entry we want to update</param>
        /// <returns></returns>
        public void UpdateCompanyModel(CompanyModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Data", model.Data);
                parameters.Add("@Adress", model.Adress);
                parameters.Add("@DeliveryAdress", model.DeliveryAdress);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spCompany_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a customer's details in the database
        /// </summary>
        /// <param name="model">The customer entry we want to update</param>
        /// <returns></returns>
        public void UpdateCustomerModel(CustomerModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@DeliveryAdress", model.DeliveryAdress);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spCustomer_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a table's details in the database
        /// </summary>
        /// <param name="model">The table item we want to update</param>
        /// <returns></returns>
        public void UpdateTableModel(TableModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spTable_Update", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// Updates a products details in the database
        /// </summary>
        /// <param name="model">The products  we want to update</param>
        /// <returns></returns>
        public void UpdateProductModel(ProductModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.Name);
                parameters.Add("@RecipeId", model.RecipeId);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spProduct_Update", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// Updates a products category entry in the database
        /// </summary>
        /// <param name="model">The product category we want to update</param>
        /// <returns></returns>
        public void UpdateProductCategoryModel(ProductCategoryModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CategoryId", model.CategoryId);
                parameters.Add("@Id", model.Id);

                connection.Execute("dbo.spProductCategory_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Updates a recipes content entry in the database
        /// </summary>
        /// <param name="model">the recipe content entry we want to update</param>
        /// <returns></returns>
        public void UpdateRecipeContentModel(RecipeContentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RecipeId", model.RecipeId);
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@ProductQuantity", model.ProductQuantity);

                connection.Execute("dbo.spRecipeContent_Update", parameters, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
