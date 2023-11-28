using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Singleton<City>
{
    [SerializeField] HeadQuarter HQ;
    //public List<Wall> walls; // up right down left
    public Wall wall;
    void Start()
    {
        
    }

    public void SetData(string cityName){
        ScriptableCity cityData = ResourceSystem.Instance.GetCityData(cityName);
        
        wall.SetData(cityData.wallArgs, cityData.buildingNames );
        HQ.SetData(cityData.headQuarterArgs);

    }


    // public void UpgradeHQ()
    // {
    //     Debug.Log("Upgrade HQ");
    //     HQ.Upgrade();
    // }



    // public void UpgradeWall()
    // {
    //     Debug.Log("Upgrade Wall");
    //     foreach(Wall wall in walls)
    //     {
    //         wall.Upgrade();
    //     }
    // }
}
