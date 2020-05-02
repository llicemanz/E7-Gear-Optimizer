﻿namespace E7_Gear_Optimizer
{
    public struct Stat
    {
        private float value;

        public Stat(Stats name, float value)
        {
            Name = name;
            this.value = name != Stats.ATK && name != Stats.DEF && name != Stats.HP && name != Stats.SPD && value >= 1 ? value / 100 : value;
        }

        public Stats Name { get; set; }
        public float Value
        {
            get => value;
            set
            {
                if (value > 0)
                {
                    this.value = value;
                }
            }
        }
    }
}
