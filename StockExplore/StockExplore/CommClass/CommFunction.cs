﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StockExplore
{
    internal class CommFunction
    {
        /// <summary>出提示
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="logFileFullName">日志文件全名，如有则写日志</param>
        /// <param name="isWrap">是否换行写入</param>
        /// <param name="addTime">是否添加时间标记</param>
        public static void WriteMessage(string message, string logFileFullName = "", bool isWrap = true, bool addTime = true)
        {
            string strTime = addTime ? "(" + DateTime.Now.ToString("MM-dd HH:mm:ss") + ") " : "";
            string strMsg = strTime + message + ( isWrap ? Environment.NewLine : "" );

            try
            {
                Console.Write(strMsg);

                if (logFileFullName != string.Empty)
                    File.AppendAllText(logFileFullName, strMsg, Encoding.UTF8);
            }
            catch (Exception) {}
        }

        #region 本程序专用

        private const string ConsDatabaseConfig = "DatabaseConfig";

        /// <summary>从配置文件中加载DatabaseConfig信息至CommProp中
        /// </summary>
        public static void LoadDatabaseConfig()
        {
            CommProp.ConnectionString = SysConfig.GetConfigData(ConsDatabaseConfig, "ConnectionString", "");
        }

        /// <summary>从配置文件中加载所有配置信息至CommProp中
        /// </summary>
        public static void LoadAllConfig()
        {
            LoadDatabaseConfig();
        }

        /// <summary>检测文件的写权限
        /// </summary>
        /// <param name="fileFullName">文件名全名</param>
        /// <returns></returns>
        public static bool CheckFileWritPermission(string fileFullName)
        {
            string fileEnd = Guid.NewGuid().ToString().Substring(0, 8);
            fileFullName += fileEnd;

            try
            {
                File.WriteAllText(fileFullName, "");
                File.Delete(fileFullName);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>检测文件夹的写权限
        /// </summary>
        /// <param name="folderName">文件夹全名</param>
        /// <returns></returns>
        public static bool CheckFolderWritPermission(string folderName)
        {
            string fileEnd = Guid.NewGuid().ToString().Substring(0, 8);
            string fileName = folderName.TrimEnd('\\') + "\\" + fileEnd;

            return CheckFileWritPermission(fileName);
        }

        #endregion 本程序专用
    }
}