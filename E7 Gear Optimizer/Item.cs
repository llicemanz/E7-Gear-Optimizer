using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E7_Gear_Optimizer
{
    public class Item
    {
        public string ID { get; }

        private int iLvl;
        private int enhance;
        private Stat main;
        private Stat[] subStats;
        public SStats AllStats { get; set; } = new SStats();
        public bool Locked { get; set; }
        public Hero Equipped { get; set; }

        public Item(string id, ItemType type, Set set, Grade grade, int iLvl, int enhance, Stat main, Stat[] subStats, Hero equipped, bool locked)
        {
            ID = id;
            Type = type;
            Set = set;
            Grade = grade;
            this.iLvl = iLvl;
            this.enhance = enhance;
            this.main = main;
            this.subStats = subStats;
            Equipped = equipped;
            Locked = locked;

            AllStats.SetStat(main);
            AllStats.SetStats(subStats);

            CalcWSS();
        }

        public Item() { }


        public ItemType Type { get; set; }
        public Set Set { get; set; }
        public Grade Grade { get; set; }
        public int ILvl
        {
            get => iLvl;
            set
            {
                if (value > 0)
                {
                    iLvl = value;
                }
            }
        }
        public int Enhance
        {
            get => enhance;
            set
            {
                if (value > -1 && value < 16)
                {
                    enhance = value;
                }
            }
        }
        public Stat Main
        {
            get => main;
            set
            {
                main = value;
                AllStats.SetStat(main);
            }
        }
        public Stat[] SubStats
        {
            get => subStats;
            set
            {
                subStats = value;
                AllStats.SetStats(subStats);
            }
        }

        public float WSS { get; private set; }

        private const float wssMultiplier = 2f / 3f;

        public void CalcWSS()
        {
            WSS = 0;
            foreach (Stat s in subStats)
            {
                switch (s.Name)
                {
                    case Stats.ATKPercent:
                    case Stats.DEFPercent:
                    case Stats.HPPercent:
                    case Stats.EFF:
                    case Stats.RES:
                        WSS += 100 * s.Value / 48;
                        break;
                    case Stats.Crit:
                        WSS += 100 * s.Value / 30;
                        break;
                    case Stats.CritDmg:
                        WSS += 100 * s.Value / 42;
                        break;
                    case Stats.SPD:
                        WSS += s.Value / 24;
                        break;
                    case Stats.ATK:
                        break;
                    case Stats.HP:
                        break;
                    case Stats.DEF:
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
            WSS *= wssMultiplier;
        }
    }
}
