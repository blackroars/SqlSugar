﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
namespace SqlSugar
{
    internal class DependencyManagement
    {
        private static bool IsTryJsonNet = false;
        private static bool IsTryMySqlData = false;
        private static bool IsTrySqlite = false;
        public static void TryJsonNet()
        {
            if (!IsTryJsonNet)
            {
                try
                {
                    Assembly asmb = Assembly.LoadFrom("Newtonsoft.Json.dll");
                    asmb = CheckAssembly(asmb);
                    IsTryJsonNet = true;
                }
                catch
                {
                    var message = ErrorMessage.GetThrowMessage(
                        " Some functions are used in newtonsoft ,Nuget references Newtonsoft.Json 9.0.0.1 + .",
                        " 部分功能用到Newtonsoft.Json.dll，需要在Nuget上安装 Newtonsoft.Json 9.0.0.1及以上版本，如果有版本兼容问题请先删除原有引用");
                    throw new Exception(message);
                }
            }
        }
        public static void TryMySqlData()
        {
            if (!IsTryMySqlData)
            {
                try
                {
                    Assembly asmb = Assembly.LoadFrom("MySql.Data.dll");
                    asmb = CheckAssembly(asmb);
                    IsTryMySqlData = true;
                }
                catch 
                {
                    var message = ErrorMessage.GetThrowMessage(
                     "You need to refer to MySql.Data.dll" ,
                     "需要引用MySql.Data.dll，请在Nuget安装最新稳定版本,如果有版本兼容问题请先删除原有引用");
                    throw new Exception(message);
                }
            }
        }

        public static void TrySqlite()
        {
            if (!IsTrySqlite)
            {
                try
                {
                    Assembly asmb = Assembly.LoadFrom("System.Data.SQLite.dll");
                    asmb = CheckAssembly(asmb);
                    IsTrySqlite = true;
                }
                catch (Exception ex)
                {
                    var message = ErrorMessage.GetThrowMessage(
                     "You need to refer to System.Data.SQLite.dll",
                    "你需要引用System.Data.SQLite.dll,如果有版本兼容问题请先删除原有引用");
                    throw new Exception(message);
                }
            }
        }

        private static Assembly CheckAssembly(Assembly asmb)
        {
            if (asmb == null) throw new Exception("");
            asmb = null;
            return asmb;
        }

    }
}
