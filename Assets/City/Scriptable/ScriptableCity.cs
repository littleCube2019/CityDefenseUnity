using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "City", menuName = "Scriptable/City")]
public class ScriptableCity : ScriptableObject

{
    public string cityName;
    public List<string> buildingNames ;  

    public WallArgs wallArgs;
    public HeadQuarterArgs headQuarterArgs;
}

[System.Serializable]
public struct WallArgs
{
    public int maxHitPoint;
   
}


[System.Serializable]
public struct HeadQuarterArgs
{
    public int maxHitPoint;
    public int energyGainPerSec;
   
}
