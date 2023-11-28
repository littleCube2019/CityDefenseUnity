using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PopulationSystem : Singleton<PopulationSystem>
{
    public event EventHandler OnPopulationChange;

    int maxPopulation;

    public Dictionary<PopulationType, int> totalPopulationDict { get; private set; }
    public Dictionary<PopulationType, int> availablePopulationDict { get; private set; }


    private void Start()
    {
        List<PopulationType> populationTypes = Utils.GetEnumList<PopulationType>();
        totalPopulationDict = populationTypes.ToDictionary(d => d, d=>0);
        availablePopulationDict = populationTypes.ToDictionary(d => d, d => 0);
        AddPopulation(PopulationType.barbarian, 10);
    }
    public void AddPopulation(PopulationType type, int amount)
    {
        totalPopulationDict[type] += amount;
        availablePopulationDict[type] += amount;
        UpdatePopulation();
    }
    public void UpdatePopulation()
    {
        foreach(var pair in totalPopulationDict)
        {
            availablePopulationDict[pair.Key] = pair.Value;
        }
        var populationUnits = FindObjectsOfType<MonoBehaviour>().OfType<IPopulation>();
        foreach (var unit in populationUnits)
        {
            unit.GetPopulation(out PopulationType type, out int num);
            availablePopulationDict[type] -= num;
        }
        OnPopulationChange?.Invoke(this, EventArgs.Empty);
    }
}

public enum PopulationType
{
    barbarian,
}