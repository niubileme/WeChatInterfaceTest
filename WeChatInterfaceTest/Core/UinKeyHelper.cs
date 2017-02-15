using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatInterfaceTest.Core
{
    public class UinKeyHelper
    {
        //VBang  Market
        public static string DB_Name = "Market";

        #region Market
        public static string GetOneByMarket()
        {
            string sql = $"select id,uinkey  from  [Market].[dbo].[UinKey] where DATEDIFF(minute,time,GETDATE())<=60 order by time desc";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    var id = reader.GetInt64(0);
                    var uinkey = reader.GetString(1);
                    return uinkey;
                }
            }
            return "";
        }

        public static List<string> GetByMarket(int num)
        {
            var list = new List<string>();
            var maxid = 0;
            string sql = $"select top {num} id,uinkey  from  [Market].[dbo].[UinKey] where DATEDIFF(minute,time,GETDATE())<=60 and id>@maxid order by time desc";
            SqlParameter[] pms = {
                                 new SqlParameter("@maxid",maxid)
                                 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var uinkey = reader.GetString(1);
                        list.Add(uinkey);
                    }
                }
            }
            return list;
        }

        public static List<string> GetByMarket()
        {
            var list = new List<string>();
            var maxid = 0;
            string sql = $"select id,uinkey  from  [Market].[dbo].[UinKey] where DATEDIFF(minute,time,GETDATE())<=60 and id>@maxid order by time desc";
            SqlParameter[] pms = {
                                 new SqlParameter("@maxid",maxid)
                                 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var uinkey = reader.GetString(1);
                        list.Add(uinkey);
                    }
                }
            }
            return list;
        }
        #endregion


        #region VBang
        public static string GetOneByVBang()
        {
            string sql = $"select id,uin  from  [VBang].[dbo].[UinKey] where DATEDIFF(minute,time,GETDATE())<=60 order by time desc";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    var id = reader.GetInt32(0);
                    var uinkey = reader.GetString(1);
                    return uinkey;
                }
            }
            return "";
        }

        public static List<string> GetByVBang(int num)
        {
            var list = new List<string>();
            var maxid = 0;
            string sql = $"select top {num} id,uin  from  [VBang].[dbo].[UinKey] where DATEDIFF(minute,time,GETDATE())<=60 and id>@maxid order by time desc";
            SqlParameter[] pms = {
                                 new SqlParameter("@maxid",maxid)
                                 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var uinkey = reader.GetString(1);
                        list.Add(uinkey);
                    }
                }
            }
            return list;
        }

        public static List<string> GetByVBang()
        {
            var list = new List<string>();
            var maxid = 0;
            string sql = $"select id,uin  from  [VBang].[dbo].[UinKey] where DATEDIFF(minute,time,GETDATE())<=10 and id>@maxid order by time desc";
            SqlParameter[] pms = {
                                 new SqlParameter("@maxid",maxid)
                                 };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var uinkey = reader.GetString(1);
                        list.Add(uinkey);
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
