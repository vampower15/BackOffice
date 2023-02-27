using System.Data.SqlTypes;
using Dapper;
using WebApplication1.Interface;
using WebApplication1.Model;
using Test_Office.ConnectionContext;
using System.Data;

namespace WebApplication1.Repository
{
    public class OfficeRepo : IOffice
    {
        private readonly SqlConnectionContext _sqlConnectionContext;

        public OfficeRepo(SqlConnectionContext sqlConnectionContext)
        {
            _sqlConnectionContext = sqlConnectionContext;
        }


        //All//
        public async Task<IEnumerable<OfficeModel>> GetOfficeAllAsync()
        {
            string storeProcedure = "StpOfficeAll";
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                var names = await connection.QueryAsync<OfficeModel>(storeProcedure, commandType: CommandType.StoredProcedure); //กำหนดข้อมูลที่ Query
                return names;
            }
        }

        //ById//
        public async Task<OfficeModel> GetOfficeByIdAsync(int id)
        {
            string storeProcedure = "StpOfficeById";
            var parameters = new DynamicParameters();
            parameters.Add("IdOf", id, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                var name = await connection.QueryFirstOrDefaultAsync<OfficeModel>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                return name;
            }
        }


        //Insert//
        public async Task InsertOfficeAsync(OfficeModel model)
        {
            string storeProcedure = "StpInsertOffice";
            var parameters = new DynamicParameters();
            parameters.Add("NameOf", model.NameOf, DbType.String, ParameterDirection.Input);
            parameters.Add("PositionOf", model.PositionOf, DbType.String, ParameterDirection.Input);
            parameters.Add("SalaryOf", model.SalaryOf, DbType.Int32, ParameterDirection.Input);

            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure); //Execute ฐานข้อมูลโดยใช้ sql,ค่าพารามิเตอร์ที่รับเข้ามา ,กำหนดประเภทคำสั่งเป็น
            }
        }


        //Update//
        public async Task UpdateOfficeAsync(int id, OfficeModel model)
        {
            string storeProcedure = "StpUpdateOffice";
            var parameters = new DynamicParameters(); //กำหนดค่า พารามิเตอร์ ของ Dapper ORM
            parameters.Add("IdOf", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NameOf", model.NameOf, DbType.String, ParameterDirection.Input);
            parameters.Add("PositionOf", model.PositionOf, DbType.String, ParameterDirection.Input);
            parameters.Add("SalaryOf", model.SalaryOf, DbType.Int32, ParameterDirection.Input);

            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }


        //Delete//
        public async Task DeleteOfficeAsync(int id)
        {
            string storeProcedure = "StpDeleteOffice";
            var parameters = new DynamicParameters();
            parameters.Add("IdOf", id, DbType.Int32, ParameterDirection.Input);

            using (IDbConnection connection = _sqlConnectionContext.CreateSqlconnection())
            {
                await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }  
}
