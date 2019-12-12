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

    }
}
