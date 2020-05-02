using System.Collections.Generic;

namespace E7_Gear_Optimizer
{
    /// <summary>
    /// Represents all stats of a character or an item
    /// </summary>
    public class SStats
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SStats"/> with all properties equal to zero
        /// </summary>
        public SStats()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SStats"/> with values copied from <paramref name="stats"/> Dictionary
        /// </summary>
        /// <param name="stats"></param>
        public SStats(Dictionary<Stats, float> stats)
        {
            ATKPercent = stats.ContainsKey(Stats.ATKPercent) ? stats[Stats.ATKPercent] : 0;
            ATK = stats.ContainsKey(Stats.ATK) ? stats[Stats.ATK] : 0;
            SPD = stats.ContainsKey(Stats.SPD) ? stats[Stats.SPD] : 0;
            Crit = stats.ContainsKey(Stats.Crit) ? stats[Stats.Crit] : 0;
            CritDmg = stats.ContainsKey(Stats.CritDmg) ? stats[Stats.CritDmg] : 0;
            HPPercent = stats.ContainsKey(Stats.HPPercent) ? stats[Stats.HPPercent] : 0;
            HP = stats.ContainsKey(Stats.HP) ? stats[Stats.HP] : 0;
            DEFPercent = stats.ContainsKey(Stats.DEFPercent) ? stats[Stats.DEFPercent] : 0;
            DEF = stats.ContainsKey(Stats.DEF) ? stats[Stats.DEF] : 0;
            EFF = stats.ContainsKey(Stats.EFF) ? stats[Stats.EFF] : 0;
            RES = stats.ContainsKey(Stats.RES) ? stats[Stats.RES] : 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SStats"/> with values copied from another <see cref="SStats"/>
        /// </summary>
        /// <param name="stats"></param>
        public SStats(SStats sStats)
        {
            ATKPercent = sStats.ATKPercent;
            ATK = sStats.ATK;
            SPD = sStats.SPD;
            Crit = sStats.Crit;
            CritDmg = sStats.CritDmg;
            HPPercent = sStats.HPPercent;
            HP = sStats.HP;
            DEFPercent = sStats.DEFPercent;
            DEF = sStats.DEF;
            EFF = sStats.EFF;
            RES = sStats.RES;
        }

        public float ATKPercent { get; set; }
        public float ATK { get; set; }
        public float SPD { get; set; }
        public float Crit { get; set; }
        public float CritCapped { get => Crit < 1 ? Crit : 1; }
        public float CritDmg { get; set; }
        public float HPPercent { get; set; }
        public float HP { get; set; }
        public float DEFPercent { get; set; }
        public float DEF { get; set; }
        public float EFF { get; set; }
        public float RES { get; set; }
        public float HPpS { get => HP * SPD / 100; }
        public float EHP { get => HP * (1 + (DEF / 300)); }
        public float EHPpS { get => EHP * SPD / 100; }
        public float DMG { get => (ATK * (1 - CritCapped)) + (ATK * CritCapped * CritDmg); }
        public float DMGpS { get => DMG * SPD / 100; }

        /// <summary>
        /// Adds values of <paramref name="sStats"/> properties to corresponding values of the <see cref="SStats"/>
        /// </summary>
        /// <param name="sStats"></param>
        public void Add(SStats sStats)
        {
            ATKPercent += sStats.ATKPercent;
            ATK += sStats.ATK;
            SPD += sStats.SPD;
            Crit += sStats.Crit;
            CritDmg += sStats.CritDmg;
            HPPercent += sStats.HPPercent;
            HP += sStats.HP;
            DEFPercent += sStats.DEFPercent;
            DEF += sStats.DEF;
            EFF += sStats.EFF;
            RES += sStats.RES;
        }

        public void AddAll(SStats sStats1, SStats sStats2, SStats sStats3)
        {
            ATKPercent += sStats1.ATKPercent + sStats2.ATKPercent + sStats3.ATKPercent;
            ATK += sStats1.ATK + sStats2.ATK + sStats3.ATK;
            SPD += sStats1.SPD + sStats2.SPD + sStats3.SPD;
            Crit += sStats1.Crit + sStats2.Crit + sStats3.Crit;
            CritDmg += sStats1.CritDmg + sStats2.CritDmg + sStats3.CritDmg;
            HPPercent += sStats1.HPPercent + sStats2.HPPercent + sStats3.HPPercent;
            HP += sStats1.HP + sStats2.HP + sStats3.HP;
            DEFPercent += sStats1.DEFPercent + sStats2.DEFPercent + sStats3.DEFPercent;
            DEF += sStats1.DEF + sStats2.DEF + sStats3.DEF;
            EFF += sStats1.EFF + sStats2.EFF + sStats3.EFF;
            RES += sStats1.RES + sStats2.RES + sStats3.RES;
        }

        /// <summary>
        /// Copies value of <paramref name="stat"/> to corresponding value of the <see cref="SStats"/>
        /// </summary>
        /// <param name="stat"></param>
        public void SetStat(Stat stat)
        {
            switch (stat.Name)
            {
                case Stats.ATKPercent:
                    ATKPercent = stat.Value;
                    break;
                case Stats.ATK:
                    ATK = stat.Value;
                    break;
                case Stats.SPD:
                    SPD = stat.Value;
                    break;
                case Stats.Crit:
                    Crit = stat.Value;
                    break;
                case Stats.CritDmg:
                    CritDmg = stat.Value;
                    break;
                case Stats.HPPercent:
                    HPPercent = stat.Value;
                    break;
                case Stats.HP:
                    HP = stat.Value;
                    break;
                case Stats.DEFPercent:
                    DEFPercent = stat.Value;
                    break;
                case Stats.DEF:
                    DEF = stat.Value;
                    break;
                case Stats.EFF:
                    EFF = stat.Value;
                    break;
                case Stats.RES:
                    RES = stat.Value;
                    break;
                case Stats.HPpS:
                    break;
                case Stats.EHP:
                    break;
                case Stats.EHPpS:
                    break;
                case Stats.DMG:
                    break;
                case Stats.DMGpS:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Copies values of <paramref name="stats"/> properties to corresponding values of the <see cref="SStats"/>
        /// </summary>
        /// <param name="stats"></param>
        public void SetStats(Stat[] stats)
        {
            foreach (Stat stat in stats)
            {
                SetStat(stat);
            }
        }
    }
}
