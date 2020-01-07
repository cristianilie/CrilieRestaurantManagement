using Dapper;
using RMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Creates a new Price entity in the database
        /// </summary>
        /// <param name="model">The new Price model</param>
        /// <returns></returns>
        public PriceModel CreatePrice(PriceModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@Cost", model.Cost);
                parameters.Add("@SalesPrice", model.SalesPrice);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrice_Insert", parameters, commandType: CommandType.StoredProcedure);

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
        /// Deletes a Product Recipe entity from the database
        /// </summary>
        /// <param name="model">The Product Recipe about to be deleted</param>
        /// <returns></returns>
        public RecipeModel DeleteRecipe(RecipeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.Id);
                connection.Execute("dbo.spRecipe_Delete", parameters, commandType: CommandType.StoredProcedure);

                return model;
            }
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
                parameters.Add("@CategoryId", model.Quantity);
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
            string storeProcedureName = "dbo.spSalesOrderProduct_Insert";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", model.Status);
                parameters.Add("@TableId", model.TableId);
                parameters.Add("@CustomerId", model.CustomerId);

                foreach (OrderProductModel orderProduct in model.OrderProductsList)
                {
                    Create_Order_ProductList(storeProcedureName, connection, orderProduct);
                }

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
            string storeProcedureName = "dbo.spPurchaseOrderProduct_Insert";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString(dbName)))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", model.Status);
                parameters.Add("@TableId", model.SuplierId);

                foreach (OrderProductModel orderProduct in model.OrderProductsList)
                {
                    Create_Order_ProductList(storeProcedureName, connection, orderProduct);
                }

                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spSalesOrder_Insert", parameters, commandType: CommandType.StoredProcedure);

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
        /// Creates a new Sales/Purchase Order product association in the database
        /// </summary>      
        /// <param name="connection">The database connection</param>
        /// <param name="opModel">The Order Product that is about to get inserted to the database and associated with the Sales/Purchase Order</param>
        private void Create_Order_ProductList(string storedProcedureName, IDbConnection connection, OrderProductModel opModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", opModel.ProductId);
            parameters.Add("@OrderId", opModel.OrderId);
            parameters.Add("@OrderedQuantity", opModel.OrderedQuantity);
            parameters.Add("@TaxId", opModel.TaxId);

            parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
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
                //var parameters = new DynamicParameters();
                //parameters.Add("@Name", model.Name);
                //parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //connection.Execute("dbo.spCategory_Update", parameters, commandType: CommandType.StoredProcedure);
                //TODO - try to update the method to use the update stored procedure
                var sqlUpdateStatement = $@"UPDATE Category 
                                            SET  Name = @Name
                                            WHERE Id = @Id";
                connection.Execute(sqlUpdateStatement, model);
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
