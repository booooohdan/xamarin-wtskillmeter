using System;

namespace WTStatistics.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Squadron { get; set; }
        public string SignUpDate { get; set; }
        public string BattleFinished { get; set; }
        public string LionEarned { get; set; }
        public string TotalTimeSpended { get; set; }
        public double TotalSkillBackground { get; set; }
        public string HeaderColor { get; set; }
        public int Preference { get; set; }

        public int WinRateAB { get; set; }
        public int WinRateRB { get; set; }
        public int WinRateSB { get; set; }

        public double KD_AAB { get; set; }
        public double KD_ARB { get; set; }
        public double KD_ASB { get; set; }
        public double KD_TAB { get; set; }
        public double KD_TRB { get; set; }
        public double KD_TSB { get; set; }
        public double KD_SAB { get; set; }
        public double KD_SRB { get; set; }

        public int CountAAB { get; set; }
        public int CountARB { get; set; }
        public int CountASB { get; set; }
        public int CountTAB { get; set; }
        public int CountTRB { get; set; }
        public int CountTSB { get; set; }
        public int CountSAB { get; set; }
        public int CountSRB { get; set; }

        public string FavoritePlane1 { get; set; }
        public string FavoritePlane2 { get; set; }
        public string FavoritePlane3 { get; set; }
        public string FavoriteTank1 { get; set; }
        public string FavoriteTank2 { get; set; }
        public string FavoriteTank3 { get; set; }


        public int MissionFighter { get; set; }
        public int MissionAttacker { get; set; }
        public int MissionBomber { get; set; }
        public int MissionMTank { get; set; }
        public int MissionHTank { get; set; }
        public int MissionSPAA { get; set; }
        public int MissionDestroyer { get; set; }
        public int MissionBoats { get; set; }
        public int MissionBarge { get; set; }
        public int MissionSubChasers { get; set; }
        public int MissionDestroyerShip { get; set; }
        public int MissionDestroyerCruiser { get; set; }

        public int ResearchedUSA { get; set; }
        public int ResearchedGermany { get; set; }
        public int ResearchedUSSR { get; set; }
        public int ResearchedBritain { get; set; }
        public int ResearchedJapan { get; set; }
        public int ResearchedIItaly { get; set; }
        public int ResearchedFrance { get; set; }
        public int ResearchedChina { get; set; }
        public int ResearchedSweden { get; set; }

    }
}