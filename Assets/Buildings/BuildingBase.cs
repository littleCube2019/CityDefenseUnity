using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public string buildingName;
    public Sprite sprite;
    protected BuildingBaseArgs baseArgs;
    protected int populationNum;
    protected float efficiency;

    public bool isActivate { get; private set; }
    public virtual void SetData(ScriptableBuilngBase scriptable) 
    {
        buildingName = scriptable.buildingName;
        sprite = scriptable.sprite;
        baseArgs = scriptable.baseArgs;
    }
    public virtual void Build() { }
    public virtual void Destroy() { 
        Destroy(gameObject);
    }
    public void SetActivate(bool activate)
    {
        isActivate = activate;
    }
    public virtual void Upgrade()
    {
        Debug.Log($"{buildingName} Upgrade");
    }
}

public enum BuildingType
{
    turret,
    generator,
}

[System.Serializable]
public struct BuildingBaseArgs
{
    public int energyCost;
    public int minWorker;
}