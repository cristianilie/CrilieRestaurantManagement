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
                parameters.Add("@ProductId", model.ProductId);
                parameters.Add("@ProductQuantity", model.ProductQuantity);
                parameters.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spRecipe_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@Id");

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
    }
}
