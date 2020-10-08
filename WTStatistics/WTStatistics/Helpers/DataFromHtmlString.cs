using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WTStatistics.Models;
using WTStatistics.ViewModels;

namespace WTStatistics.Helpers
{
    class DataFromHtmlString
    {
        Player player;

        #region Constructor

        public DataFromHtmlString(string datastring)
        {
            player = new Player();
            GetAviaTableData(datastring);
        }
        #endregion

        /// <summary>
        /// Selected and put data from HTML to players object propertys 
        /// </summary>
        /// <param name="htmlString">HTML string from webview</param>
        private void GetAviaTableData(string htmlString)
        {
            var listString = new List<string>();
            string[] splittedString = htmlString.Split(new string[] { "u003" }, StringSplitOptions.None);

            foreach (var s in splittedString)
            {
                if (s.Contains("AviationTable-TableData"))
                {
                    var trimStart = s.Substring(53);
                    var trimEnd = trimStart.Substring(0, trimStart.Length - 1);
                    listString.Add(trimEnd);
                }
            }

            player.LionEarned = Convert.ToInt32(listString[5]);
        }

        /// <summary>
        /// Return players data
        /// </summary>
        /// <returns>Players data</returns>
        public Player PlayerInfo()
        {
            return player;
        }
    }
}
