﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using WTStatistics.Models;
using WTStatistics.Resx;
using Xamarin.Forms;

namespace WTStatistics.Helpers
{
    class DataFromHtmlString
    {
        #region List of collection

        Player player;
        List<string> listTableMain;
        List<string> listTableAvia;
        List<string> listTableTanks;
        List<string> listTableShips;
        List<string> listTableVehicle;
        List<string> squadron;
        List<string> signUpDate;
        #endregion

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

        #region Methods

        // Put info from html table to list
        private List<string> GetTableData(string htmlString, string tableName)
        {
            var listString = new List<string>();
            string[] splittedString = null;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    splittedString = htmlString.Split(new string[] { "u003" }, StringSplitOptions.None);
                    break;
                case Device.iOS:
                    splittedString = htmlString.Split(new string[] { "<" }, StringSplitOptions.None);
                    break;
            }

            foreach (var s in splittedString)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        if (s.Contains(tableName))
                        {
                            var trimStart = s.Substring(s.IndexOf('>') + 1);
                            var trimEnd = trimStart.Substring(0, trimStart.Length - 1);
                            listString.Add(trimEnd);
                        }
                        break;
                    case Device.iOS:
                        if (s.Contains(tableName))
                        {
                            var trimStart = s.Substring(s.IndexOf('>') + 1);
                            var trimEnd = trimStart.Substring(0, trimStart.Length - 0);
                            listString.Add(trimEnd);
                        }
                        break;
                }
            }
            return listString;
        }


        //  Return Int32 value from string with null check
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

        // Calculate Kill/Battle ratio
        private double KBCalc(int kills, int battles)
        {
            double KD = battles > 0 ? (double)kills / (double)battles : 0;
            return Math.Round(KD, 1);
        }

        // Calculate total skill for modes where more 100 battles + winrate
        private double CalculateTotalSkill()
        {
            List<double> efficiency = new List<double>();
            if (ToInt(listTableAvia[5]) > 100)
            {
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

            efficiency.Add((double)player.WinRateAB * 2 / 100);
            efficiency.Add((double)player.WinRateRB * 2 / 100);
            efficiency.Add((double)player.WinRateSB * 2 / 100);

            return efficiency.Average();
        }

        private string SetAvatar()
        {
            string result = string.Empty;
            var air = player.CountAAB + player.CountARB + player.CountASB;
            var tank = player.CountTAB + player.CountTRB + player.CountTSB;
            var fleet = player.CountSAB + player.CountSRB;

            if (air >= tank & air >= fleet)
            {
                result = "pilot";
            }
            else
            if (tank >= air & tank >= fleet)
            {
                result = "tankman";
            }
            else
            if (fleet >= air & fleet >= tank)
            {
                result = "sailor";
            }
            return result;
        }

        private string SetHashTag()
        {
            ModesCalc();
            CountryCalc();
            var hashtag = "#" + ModesCalc() + "  #" +CountryCalc() ;
            hashtag = hashtag.ToLower();
            return hashtag;
        }

        //return string with preference game mode for hashtag
        private string ModesCalc()
        {
            var ab = player.CountAAB + player.CountTAB + player.CountSAB; 
            var rb = player.CountARB + player.CountTRB + player.CountSRB;
            var sb = player.CountASB + player.CountTSB;

            if (ab > rb & ab > sb)
            {
                return AppResources.PlayerAB;
            }
            if (rb > ab & rb > sb)
            {
                return AppResources.PlayerRB;
            }
            if (sb > ab & sb > rb)
            {
                return AppResources.PlayerSB;
            }
            return null;
        }

        //return string with preference country for hashtag
        private string CountryCalc()
        {
            var countrys = new List<int>
            {
                player.ResearchedUSA,
                player.ResearchedGermany,
                player.ResearchedUSSR,
                player.ResearchedBritain,
                player.ResearchedJapan,
                player.ResearchedItaly,
                player.ResearchedFrance,
                player.ResearchedChina,
                player.ResearchedSweden
            };

            var country = countrys.Max();
                      
            if (country == player.ResearchedUSA)
            {
                return AppResources.PlayerUSA;
            }
            if (country == player.ResearchedGermany)
            {
                return AppResources.PlayerGermany;
            }
            if (country == player.ResearchedUSSR)
            {
                return AppResources.PlayerUssr;
            }
            if (country == player.ResearchedBritain)
            {
                return AppResources.PlayerBritain;
            }
            if (country == player.ResearchedJapan)
            {
                return AppResources.PlayerJapan;
            }
            if (country == player.ResearchedItaly)
            {
                return AppResources.PlayerItaly;
            }
            if (country == player.ResearchedFrance)
            {
                return AppResources.PlayerFrance;
            }
            if (country == player.ResearchedChina)
            {
                return AppResources.PlayerChina;
            }
            if (country == player.ResearchedSweden)
            {
                return AppResources.PlayerSweden;
            }

            return null;
        }

        private void PreferenceVehicleType()
        {
            var list = new List<Preference>()
            {
                new Preference(AppResources.Fighter, player.MissionFighter, "Fighter"),
                new Preference(AppResources.Attacker, player.MissionAttacker, "Attacker"),
                new Preference(AppResources.Bomber, player.MissionBomber, "Bomber"),
                new Preference(AppResources.MediumTanks, player.MissionMTank, "MiddleTank"),
                new Preference(AppResources.HeavyTanks, player.MissionHTank, "HeavyTank"),
                new Preference(AppResources.TankDestroyer, player.MissionDestroyer, "TankDestroyer"),
                new Preference(AppResources.SPAA, player.MissionSPAA, "SPAA"),
                new Preference(AppResources.Boats, player.MissionBoats, "Boat"),
                new Preference(AppResources.Barge, player.MissionBarge, "Barge"),
                new Preference(AppResources.Frigate, player.MissionFrigate, "Frigate"),
                new Preference(AppResources.ShipDestroyer, player.MissionDestroyerShip, "ShipDestroyer")
            };
            double sum = list.Sum(x => x.Count);
            var sorted = list.OrderByDescending(x => x.Count);

            var percentage = new List<Preference>();
            foreach (var s in sorted)
            {
                var percent = Math.Round(s.Count / sum*100, 0);
                percentage.Add(new Preference(s.Name, percent, s.Icon));
            }

            player.FavoriteVehicleName1 = percentage[0].Name;
            player.FavoriteVehicleName2 = percentage[1].Name;
            player.FavoriteVehicleName3 = percentage[2].Name;
            player.FavoriteVehicleName4 = percentage[3].Name;
            player.FavoriteVehicleName5 = percentage[4].Name;
            player.FavoriteVehicle1 = percentage[0].Count;
            player.FavoriteVehicle2 = percentage[1].Count;
            player.FavoriteVehicle3 = percentage[2].Count;
            player.FavoriteVehicle4 = percentage[3].Count;
            player.FavoriteVehicle5 = percentage[4].Count;
            player.FavoriteVehicleIcon1 = percentage[0].Icon;
            player.FavoriteVehicleIcon2 = percentage[1].Icon;
            player.FavoriteVehicleIcon3 = percentage[2].Icon;
            player.FavoriteVehicleIcon4 = percentage[3].Icon;
            player.FavoriteVehicleIcon5 = percentage[4].Icon;
        }

        //Set gradient color and skill label
        private void SetSkill(double skill)
        {
            if (skill >= 0 & skill <= 0.6)
            {
                player.SkillGradient = "grad_red.png";
                player.SkillDescription = AppResources.BadPlayer;
            }
            if (skill > 0.6 & skill <= 0.9)
            {
                player.SkillGradient = "grad_yellow.png";
                player.SkillDescription = AppResources.AveragePlayer;
            }
            if (skill > 0.9 & skill <= 1.1)
            {
                player.SkillGradient = "grad_green.png";
                player.SkillDescription = AppResources.GoodPlayer;
            }
            if (skill > 1.1 & skill <= 1.5)
            {
                player.SkillGradient = "grad_blue.png";
                player.SkillDescription = AppResources.ExcellentPlayer;
            }
            if (skill > 1.5)
            {
                player.SkillGradient = "grad_violet.png";
                player.SkillDescription = AppResources.OutstandingPlayer;
            }
        }

        private string ConvToM(string convertedValue)
        {
            double num = Convert.ToDouble(convertedValue);
            string converted = string.Empty;
            if (num > 1000000)
            {
                converted = Math.Round(num / 1000000, 1) + " M";
            }
            else
            {
                converted = num.ToString();
            }
            return converted;
        }

        // Set players data to model instance
        public Player Info()
        {
            DateConverter date = new DateConverter();
            var battleFinished = (ToInt(listTableMain[9]) + ToInt(listTableMain[10]) + ToInt(listTableMain[11])).ToString();
            var totalTime = date.GetSpendTime(listTableMain[29]) + date.GetSpendTime(listTableMain[30]) + date.GetSpendTime(listTableMain[31]);
            var lionEarned = (ToInt(listTableMain[21]) + ToInt(listTableMain[22]) + ToInt(listTableMain[23])).ToString();

            player.BattleFinished = battleFinished;
            player.TotalTimeSpended = Math.Truncate(totalTime) +AppResources.H;
            player.LionEarned = ConvToM(lionEarned);
            player.SignUpDate = signUpDate[0].Substring(18);
            player.Squadron = squadron[0];

            player.WinRateAB = ToInt(listTableMain[13]);
            player.WinRateRB = ToInt(listTableMain[14]);
            player.WinRateSB = ToInt(listTableMain[15]);

            player.CountAAB = ToInt(listTableAvia[5]);
            player.CountARB = ToInt(listTableAvia[6]);
            player.CountASB = ToInt(listTableAvia[7]);
            player.CountTAB = ToInt(listTableTanks[5]);
            player.CountTRB = ToInt(listTableTanks[6]);
            player.CountTSB = ToInt(listTableTanks[7]);
            player.CountSAB = ToInt(listTableShips[5]);
            player.CountSRB = ToInt(listTableShips[6]);

            player.KD_AAB = KBCalc(ToInt(listTableAvia[41]), player.CountAAB);
            player.KD_ARB = KBCalc(ToInt(listTableAvia[42]), player.CountARB);
            player.KD_ASB = KBCalc(ToInt(listTableAvia[43]), player.CountASB);
            player.KD_TAB = KBCalc(ToInt(listTableTanks[53]) + ToInt(listTableTanks[49]), player.CountTAB);
            player.KD_TRB = KBCalc(ToInt(listTableTanks[54]) + ToInt(listTableTanks[50]), player.CountTRB);
            player.KD_TSB = KBCalc(ToInt(listTableTanks[55]) + ToInt(listTableTanks[51]), player.CountTSB);
            player.KD_SAB = KBCalc(ToInt(listTableShips[81]), player.CountSAB);
            player.KD_SRB = KBCalc(ToInt(listTableShips[82]), player.CountSRB);

            player.MissionFighter = ToInt(listTableAvia[9]) + ToInt(listTableAvia[10]) + ToInt(listTableAvia[11]);
            player.MissionAttacker = ToInt(listTableAvia[17]) + ToInt(listTableAvia[18]) + ToInt(listTableAvia[19]);
            player.MissionBomber = ToInt(listTableAvia[13]) + ToInt(listTableAvia[14]) + ToInt(listTableAvia[15]);

            player.MissionMTank = ToInt(listTableTanks[9]) + ToInt(listTableTanks[10]) + ToInt(listTableTanks[11]);
            player.MissionHTank = ToInt(listTableTanks[17]) + ToInt(listTableTanks[18]) + ToInt(listTableTanks[19]);
            player.MissionDestroyer = ToInt(listTableTanks[13]) + ToInt(listTableTanks[14]) + ToInt(listTableTanks[15]);
            player.MissionSPAA = ToInt(listTableTanks[21]) + ToInt(listTableTanks[22]) + ToInt(listTableTanks[23]);

            player.MissionBoats = ToInt(listTableShips[13]) + ToInt(listTableShips[14])+ ToInt(listTableShips[17]) + ToInt(listTableShips[18]) 
                + ToInt(listTableShips[21]) + ToInt(listTableShips[22]);
            player.MissionBarge = ToInt(listTableShips[33]) + ToInt(listTableShips[34]);
            player.MissionFrigate = ToInt(listTableShips[25]) + ToInt(listTableShips[26]);
            player.MissionDestroyerShip = ToInt(listTableShips[29]) + ToInt(listTableShips[30]);

            player.ResearchedUSA = ToInt(listTableVehicle[11]);
            player.ResearchedUSSR = ToInt(listTableVehicle[17]);
            player.ResearchedBritain = ToInt(listTableVehicle[23]);
            player.ResearchedGermany = ToInt(listTableVehicle[29]);
            player.ResearchedJapan = ToInt(listTableVehicle[35]);
            player.ResearchedItaly = ToInt(listTableVehicle[41]);
            player.ResearchedFrance = ToInt(listTableVehicle[47]);
            player.ResearchedChina = 0;
            player.ResearchedSweden = 0;
            
            var skill = CalculateTotalSkill();
            SetSkill(skill);
            PreferenceVehicleType();
            player.Avatar = SetAvatar();
            player.HashTag = SetHashTag();
            return player;
        }
        #endregion
    }
}