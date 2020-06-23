using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ProjectOneApi.DataLogic
{
    public class DataBaseHandler
    {
        private Database projectOneDb;
        private DbCommand cmd;
        private string constr = "projectOneDb";
        DataTable dt = new DataTable();

        public DataBaseHandler()
        {
            //projectOneDb = DatabaseFactory.CreateDatabase(constr);
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            projectOneDb = factory.Create(constr);
        }

        public string ExecuteDataset(string procedure, object[] paras)
        {
            try
            {
                if (!paras.Length.Equals(0))
                {
                    cmd = projectOneDb.GetStoredProcCommand(procedure, paras);
                }
                else
                {
                    cmd = projectOneDb.GetStoredProcCommand(procedure);
                }
                cmd.CommandTimeout = 1000;
                int q = projectOneDb.ExecuteNonQuery(cmd);
                return Convert.ToString(q);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetData(string procedure, object[] paras)
        {
            try
            {
                if (!paras.Length.Equals(0))
                {
                    cmd = projectOneDb.GetStoredProcCommand(procedure, paras);
                }
                else
                {
                    cmd = projectOneDb.GetStoredProcCommand(procedure);
                }
                cmd = projectOneDb.GetStoredProcCommand(procedure, paras);
                cmd.CommandTimeout = 1000;
                dt = projectOneDb.ExecuteDataSet(cmd).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}