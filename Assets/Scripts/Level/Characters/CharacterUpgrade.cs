using System;

public class CharacterUpgrade
{
    public int upgradeLevel;
    public int nextCost;
    public int multiplier;
    public Func<int, int> costCalculation;

    public CharacterUpgrade(int level = 0, int cost = 10,int mult = 1, Func<int,int> calc = null)
    {
        upgradeLevel = level;
        nextCost = cost;
        multiplier = mult;

        if(calc == null)
        {
            costCalculation = ComputePrice;
        }
        else
        {
            costCalculation = calc;
        }
    }

    public int ComputePrice(int level)
    {
        return 10 + level * 10;
    }

    public int Upgrade(int value)
    {
        upgradeLevel++;
        nextCost = costCalculation(upgradeLevel);
        return value + multiplier;
    }
}

