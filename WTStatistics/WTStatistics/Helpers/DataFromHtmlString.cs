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
        private int ToInt(string subjectString)
        {
            var stringWithLetter = string.Concat(subjectString.Where(Char.IsDigit));
            if (!string.IsNullOrEmpty(stringWithLetter))
            {
                return Convert.ToInt32(stringWithLetter);
            }
            else
            {
                return 0;
            }
        }

        private double KDCalculate(int kills, int battles)
        {
            double KD = battles > 0 ? (double)kills / (double)battles : 0;
            return Math.Round(KD, 1);
        }

        private double CalculateTotalSkill()
        {
            List<double> efficiency = new List<double>();
            if (ToInt(listTableAvia[5]) > 100) {
                efficiency.Add(player.KD_AAB);
            }
            if (ToInt(listTableAvia[6]) > 100)
            {
                efficiency.Add(player.KD_ARB);
            }
            if (ToInt(listTableAvia[7]) > 100)
            {
                efficiency.Add(player.KD_ASB);
            }
            if (ToInt(listTableTanks[5]) > 100)
            {
                efficiency.Add(player.KD_TAB);
            }
            if (ToInt(listTableTanks[6]) > 100)
            {
                efficiency.Add(player.KD_TRB);
            }
            if (ToInt(listTableTanks[7]) > 100)
            {
                efficiency.Add(player.KD_TSB);
            }
            if (ToInt(listTableShips[5]) > 100)
            {
                efficiency.Add(player.KD_SAB);
            }
            if (ToInt(listTableShips[6]) > 100)
            {
                efficiency.Add(player.KD_SRB);
            }

            return efficiency.Average();
        }

        /// <summary>
        /// Return players data
        /// </summary>
        /// <returns>Players data</returns>
        public Player PlayerInfo()
        {
            DateConverter date = new DateConverter();
            var totalTime = date.GetSpendTime(listTableMain[29]) + date.GetSpendTime(listTableMain[30]) + date.GetSpendTime(listTableMain[31]);

            player.LionEarned = ToInt(listTableMain[21]) + ToInt(listTableMain[22]) + ToInt(listTableMain[23]);
            player.BattleFinished = ToInt(listTableMain[9]) + ToInt(listTableMain[10]) + ToInt(listTableMain[11]);
            player.TotalTimeSpended = Math.Truncate(totalTime);
            player.SignUpDate = signUpDate[0].Substring(18);
            player.Squadron = squadron[0];

            player.WinRateAB = ToInt(listTableMain[13]);
            player.WinRateRB = ToInt(listTableMain[14]);
            player.WinRateSB = ToInt(listTableMain[15]);

            player.KD_AAB = KDCalculate(ToInt(listTableAvia[41]), ToInt(listTableAvia[5]));
            player.KD_ARB = KDCalculate(ToInt(listTableAvia[42]), ToInt(listTableAvia[6]));
            player.KD_ASB = KDCalculate(ToInt(listTableAvia[43]), ToInt(listTableAvia[7]));
            player.KD_TAB = KDCalculate(ToInt(listTableTanks[53]), ToInt(listTableTanks[5]));
            player.KD_TRB = KDCalculate(ToInt(listTableTanks[54]), ToInt(listTableTanks[6]));
            player.KD_TSB = KDCalculate(ToInt(listTableTanks[55]), ToInt(listTableTanks[7]));
            player.KD_SAB = KDCalculate(ToInt(listTableShips[81]), ToInt(listTableShips[5]));
            player.KD_SRB = KDCalculate(ToInt(listTableShips[82]), ToInt(listTableShips[6]));

            player.TotalSkillBackground = CalculateTotalSkill();
            return player;
        }
    }
}