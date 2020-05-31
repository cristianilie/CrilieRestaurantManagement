using System.Linq;

namespace RMLibrary.RMS_Logic
{
    public class TableManagementLogic
    {
        /// <summary>
        /// Checks if the name of the table we are trying to create already exists
        /// </summary>
        public bool CheckIfTableNameExists(string tableName)
        {
            return GlobalConfig.Connection.GetTables_All().Where(c => c.Name == tableName).Count() > 0;
        }
    }
}