using System;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get { return this.id; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ThrowException("Id");
            }
            this.id = value;
        }
    }

    public virtual double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                ThrowException("OreOutput");
            }
            this.oreOutput = value;
        }

    }

    public virtual double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0||value>20000)
            {
                ThrowException("EnergyRequirement");
            }
            if (value > 20000)
            {
                ThrowException("EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    private void ThrowException(string fieldName)
    {
        throw new ArgumentException($@"Harvester is not registered, because of it's {fieldName}");
    }

    public override string ToString()
    {
        return $" Harvester - {this.Id}" + Environment.NewLine + $"Ore Output: {this.OreOutput}" + Environment.NewLine + $"Energy Requirement: {this.EnergyRequirement}";
    }
}

