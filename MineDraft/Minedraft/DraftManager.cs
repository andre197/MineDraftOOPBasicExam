using System;
using System.Collections.Generic;
using System.Linq;



public class DraftManager
{
    private List<Harvester> harvesters = new List<Harvester>();
    private List<Provider> providers = new List<Provider>();
    private string mode = "FullMode";
    private double storedEnergy;
    private double production;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {

            if (arguments[0] == "Sonic")
            {
                harvesters.Add(HarvesterFactory.Get((int)HarvesterFactoryId.Sonic,arguments));
                return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
            }
            else
            {
                harvesters.Add(HarvesterFactory.Get((int)HarvesterFactoryId.Hammer,arguments));
                return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
            }
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {

            if (arguments[0] == "Solar")
            {
                providers.Add(ProviderFactory.Get((int)ProviderFactoryId.Solar, arguments));
                return $"Successfully registered Solar Provider - {arguments[1]}";
            }
            else
            {
                providers.Add(ProviderFactory.Get((int)ProviderFactoryId.Solar, arguments));
                return $"Successfully registered Pressure Provider - {arguments[1]}";

            }
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        int energyPercent = 100;
        int productionPercent = 100;

        double currentProduction = 0;


        if (this.mode == "Half")
        {
            energyPercent = 60;
            productionPercent = 50;
        }
        else if (this.mode == "Energy")
        {
            energyPercent = 0;
            productionPercent = 0;
        }

        double currentEnery = ProvideEnergy();


        if (this.storedEnergy >= this.harvesters.Sum(x => x.EnergyRequirement))
        {
            foreach (var harvester in harvesters)
            {
                this.storedEnergy -= harvester.EnergyRequirement * energyPercent / 100;
                this.production += harvester.OreOutput * productionPercent / 100;
                currentProduction += harvester.OreOutput * productionPercent / 100;
            }
        }

        return "A day has passed." + Environment.NewLine + $"Energy Provided: {currentEnery}" + Environment.NewLine + $"Plumbus Ore Mined: {currentProduction}";
    }

    private double ProvideEnergy()
    {
        double providedEnergy = 0;
        foreach (var provider in providers)
        {

            this.storedEnergy += provider.EnergyOutput;
            providedEnergy += provider.EnergyOutput;

        }
        return providedEnergy;
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }

    public string Check(List<string> arguments)
    {
        Harvester harvester = null;
        Provider provider = null;
        foreach (var h in harvesters)
        {
            if (h.Id == arguments[0])
            {
                harvester = h;
                break;
            }
        }
        if (harvester == null)
        {
            foreach (var p in providers)
            {
                if (p.Id == arguments[0])
                {
                    provider = p;
                }
            }

        }

        if (provider == null && harvester == null)
        {
            return $"No element found with id - {arguments[0]}";
        }
        if (harvester != null)
        {
            return harvester.ToString();
        }
        return provider.ToString();
    }

    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine + $"Total Energy Stored: {this.storedEnergy}" + Environment.NewLine + $"Total Mined Plumbus Ore: {this.production}";
    }



}

