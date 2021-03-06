﻿public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.sonicFactor = sonicFactor;
        base.EnergyRequirement /= this.sonicFactor;
    }
    
    public override string ToString()
    {
        return "Sonic" + base.ToString();
    }
}

