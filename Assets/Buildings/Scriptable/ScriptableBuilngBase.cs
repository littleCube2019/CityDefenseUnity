using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptableBuilngBase : ScriptableObject
{
    public string buildingName;
    public BuildingType buildingType;
    public BuildingBaseArgs baseArgs;

    public Sprite sprite;
    public BuildingBase prefab;

    public ScriptableChoiceNode choiceNodeRoot;

    public List<string> unlockRequire;
}
