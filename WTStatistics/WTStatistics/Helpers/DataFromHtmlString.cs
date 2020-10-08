using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using WTStatistics.Models;

namespace WTStatistics.Helpers
{
    class DataFromHtmlString
    {
        Player player;
        List<string> listTableMain;
        List<string> listTableAvia;
        List<string> listTableTanks;
        List<string> listTableShips;
        List<string> listTableVehicle;
        List<string> signUpDate;
        List<string> squadron;

        #region Constructor

        public DataFromHtmlString(string datastring)
        {
            player = new Player();
            listTableMain = GetTableData(datastring, "AllStatTable-TableData");
            listTableAvia = GetTableData(datastring, "AviationTable-TableData");
            listTableTanks = GetTableData(datastring, "GroundTable-TableData");
            listTableShips = GetTableData(datastring, "FleetTable-TableData");
            listTableVehicle = GetTableData(datastring, "GeoStatTable-TableData");
            squadron = GetTableData(datastring, "community/claninfo");
            signUpDate = GetTableData(datastring, "regDate");
        }
        #endregion

        /// <summary>
        /// Put info from html table to list
        /// </summary>
        /// <param name="htmlString">HTML string</param>
        /// <param name="tableName">Name of HTML table</param>
        /// <param name="startTrim">Count of symbol to cut</param>
        /// <returns></returns>
        private List<string> GetTableData(string htmlString, string tableName)
        {
            var listString = new List<string>();
            string[] splittedString = htmlString.Split(new string[] { "u003" }, StringSplitOptions.None);

            foreach (var s in splittedString)
            {
                if (s.Contains(tableName))
                {
                    var trimStart = s.Substring(s.IndexOf('>') + 1);
                    var trimEnd = trimStart.Substring(0, trimStart.Length - 1);
                    listString.Add(trimEnd);
                }
            }
            return listString;
        }

        /// <summary>
        ///  Returrn Int32 value from string with null check
        /// </summary>
        /// <param name="subjectString">HTML string</param>
        /// <returns>Int32 value</returns>
        private int KeepDigits(string subjectString)
        {
            if (string.IsNullOrEmpty(subjectString))
                return 0;

            var stringWithLetter = string.Concat(subjectString.Where(Char.IsDigit));
            return Convert.ToInt32(stringWithLetter);
        }


        /// <summary>
        /// Return players data
        /// </summary>
        /// <returns>Players data</returns>
        public Player PlayerInfo()
        {
            DateConverter date= new DateConverter();
            var totalTime = date.GetSpendTime(listTableMain[29]) + date.GetSpendTime(listTableMain[30]) + date.GetSpendTime(listTableMain[31]);

            player.LionEarned = KeepDigits(listTableMain[21]) + KeepDigits(listTableMain[22]) + KeepDigits(listTableMain[23]);
            player.BattleFinished = KeepDigits(listTableMain[9]) + KeepDigits(listTableMain[10]) + KeepDigits(listTableMain[11]);
            player.TotalTimeSpended = Math.Truncate(totalTime);
            player.SignUpDate = signUpDate[0].Substring(18);
            player.Squadron = squadron[0];
            return player;
        }
    }
}