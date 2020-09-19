using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPractice.SqlContext
{
    public class DapperHelper
    {
        static IDbConnection _dbConnection = new SqlConnection();

        // 其實就是get{ return... }
        public string ConnectionString => ConnectionOptions.ConnectionString;
        public DapperHelper()
        {
            _dbConnection.ConnectionString = ConnectionString;
        }

        /// <summary>
        /// 單筆查詢
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql語法</param>
        /// <param name="param">參數</param>
        /// <param name="transaction">sql transaction</param>
        /// <param name="commandTimeout">超時時間</param>
        /// <param name="commandType">command類型</param>
        /// <returns></returns>
        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, 
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.QueryFirst<T>(sql, param, transaction,commandTimeout, commandType);
        }

        /// <summary>
        /// 多筆查詢
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql語法</param>
        /// <param name="param">參數</param>
        /// <param name="transaction">sql transaction</param>
        /// <param name="buffered">緩存</param>
        /// <param name="commandTimeout">超時時間</param>
        /// <param name="commandType">command類型</param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return _dbConnection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
    }
}
