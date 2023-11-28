using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class UpgradeSystem : Singleton<UpgradeSystem>
{
    List<string> buildingUpgradeList;
    List<string> populationList;
    List<string> upgraded;

    private void Start()
    {
        buildingUpgradeList = ResourceSystem.Instance.buildingList.Select(d => d.buildingName).ToList();
        populationList = new List<string> { "barbarian" };
        upgraded = new List<string>();
    }
    /*
    public void Upgrade(string upgrade)
    {
        if (upgraded.Contains(upgrade)) return;
        if (upgrade == "") return;
        else if (upgrade == "barbarian") PopulationSystem.Instance.AddPopulation(PopulationType.barbarian, 10);
        else
        {
            City.Instance.BuildBuilding(upgrade);
        }
        upgraded.Add(upgrade);
    }
    */
    public List<string> GetAvailableUpgrade(int num)
    {
        List<string> availableUpdgrade = new List<string>();
        List<string> pickedList = new List<string>();
        foreach (string building in buildingUpgradeList)
        {
            if(!upgraded.Contains(building)) availableUpdgrade.Add(building);
        }
        foreach(string population in populationList)
        {
            availableUpdgrade.Add(population);
        }
        if (num >= availableUpdgrade.Count) pickedList = availableUpdgrade;
        else
        {
            for(int i=0; i<num; i++)
            {
                int pick = Random.Range(0, availableUpdgrade.Count);
                pickedList.Add(availableUpdgrade[pick]);
                availableUpdgrade.RemoveAt(pick);
            }
        }
        return pickedList;
    }
}
