using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGenerator : BuildingBase
{
    EnergyGeneratorArgs generatorArgs;
    float cooldownTimer;

    private void Update()
    {
        if (populationNum < baseArgs.minWorker) return;
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
        else GainEnergy();
    }
    public override void SetData(ScriptableBuilngBase scirptable)
    {
        base.SetData(scirptable);
        ScriptableEnergyGenerator generatorScriptable = scirptable as ScriptableEnergyGenerator;
        generatorArgs = generatorScriptable.energyGeneratorArgs;
        cooldownTimer = generatorArgs.cooldown;
    }

    void GainEnergy()
    {
        int amount = Mathf.FloorToInt(generatorArgs.amount + populationNum * 5);
        EnergySystem.Instance.GainEnergy(amount);
        cooldownTimer = generatorArgs.cooldown ;
    }
    public override void Build()
    {
        base.Build();
        EnergySystem.Instance.MaxEnergyChange(generatorArgs.capacity);
    }
    public override void Destroy()
    {
        EnergySystem.Instance.MaxEnergyChange(-generatorArgs.capacity);
        base.Destroy();
    }

}

[System.Serializable]
public struct EnergyGeneratorArgs
{
    public int amount;
    public int capacity;
    public float cooldown;
}