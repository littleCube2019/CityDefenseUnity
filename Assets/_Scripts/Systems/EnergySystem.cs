using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : Singleton<EnergySystem>
{
    public event EventHandler<OnEnergyChangeArgs> OnEnergyChange;
    public class OnEnergyChangeArgs : EventArgs
    {
        public int energy;
        public int maxEnergy;
    }
    [SerializeField] int maxEnergy;

    int totalEnergy;
    
    private void Start()
    {
        totalEnergy = 0;
        OnEnergyChange?.Invoke(this, new OnEnergyChangeArgs { energy = totalEnergy, maxEnergy = maxEnergy });
    }
    public int GetTotalEnergy() => totalEnergy;

    public void MaxEnergyChange(int amount)
    {
        maxEnergy += amount;
        OnEnergyChange?.Invoke(this, new OnEnergyChangeArgs { energy = totalEnergy, maxEnergy = maxEnergy});
    }
    public void GainEnergy(int gain)
    {
        totalEnergy = Mathf.Min(totalEnergy + gain, maxEnergy);
        OnEnergyChange?.Invoke(this, new OnEnergyChangeArgs { energy = totalEnergy, maxEnergy = maxEnergy });
    }
    public bool CostEnergy(int cost)
    {
        if (IsEnergyEnough(cost))
        {
            totalEnergy = Mathf.Max(0, totalEnergy - cost);
            OnEnergyChange?.Invoke(this, new OnEnergyChangeArgs { energy = totalEnergy, maxEnergy = maxEnergy });
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsEnergyEnough(int require)
    {
        return totalEnergy >= require;
    }
}
