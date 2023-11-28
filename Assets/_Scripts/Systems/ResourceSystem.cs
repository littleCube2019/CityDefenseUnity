using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ResourceSystem : PersistentSingleton<ResourceSystem>
{
    //List<ScriptableItem> itemList;
    //Dictionary<GameResourceType, ScriptableItem> itemDict;
    public List<ScriptableBuilngBase> buildingList { get; private set; }
    Dictionary<string, ScriptableBuilngBase> buildingDict;
    public List<ScriptableEnemy> enemyList { get; private set; }
    Dictionary<string, ScriptableEnemy> enemyDict;
    public List<ScriptableProjectile> projectileList { get; private set; }
    Dictionary<string, ScriptableProjectile> projectileDict;
    public List<ScriptableEnemyGenerator> enemyGeneratorList { get; private set; }
    Dictionary<string, ScriptableEnemyGenerator> enemyGeneratorDict;

    public List<ScriptableArmy> armyList { get; private set; }
    Dictionary<string, ScriptableArmy> armyDict;

    public List<ScriptableCity> cityList { get; private set; }
    Dictionary<string, ScriptableCity> cityDict;

    public List<ScriptableLevelArgs> levelList { get; private set; }
    Dictionary<string, ScriptableLevelArgs> levelDict;
    protected override void Awake()
    {
        base.Awake();
        Assemble();
    }

    void Assemble()
    {
        //itemList = Resources.LoadAll<ScriptableItem>("Scriptable/Items").ToList();
        //itemDict = itemList.ToDictionary(d => d.resourceType, d => d);
        buildingList = Resources.LoadAll<ScriptableBuilngBase>("ScriptableObjs/Buildings").ToList();
        buildingDict = buildingList.ToDictionary(d => d.buildingName, d => d);
        enemyList = Resources.LoadAll<ScriptableEnemy>("ScriptableObjs/Enemy").ToList();
        enemyDict = enemyList.ToDictionary(d => d.enemyName, d => d);
        projectileList = Resources.LoadAll<ScriptableProjectile>("ScriptableObjs/Projectiles").ToList();
        projectileDict = projectileList.ToDictionary(d => d.projectileName, d => d);
        enemyGeneratorList = Resources.LoadAll<ScriptableEnemyGenerator>("ScriptableObjs/EnemyGenerator").ToList();
        enemyGeneratorDict = enemyGeneratorList.ToDictionary(d => d.enemyGeneratorName, d => d);
        armyList = Resources.LoadAll<ScriptableArmy>("ScriptableObjs/Army").ToList();
        armyDict = armyList.ToDictionary(d => d.armyName, d => d);
        cityList = Resources.LoadAll<ScriptableCity>("ScriptableObjs/City").ToList();
        cityDict = cityList.ToDictionary(d => d.cityName, d => d);


        levelList = Resources.LoadAll<ScriptableLevelArgs>("ScriptableObjs/LevelArgs").ToList();
        levelDict = levelList.ToDictionary(d => d.levelName, d => d);  

    }

    //public ScriptableItem GetGameResourceData(GameResourceType t) => itemDict[t];
    public GameObject GetPrefab(string prefabName)
    {
        GameObject ret = Resources.Load<GameObject>($"Prefabs/{prefabName}");
        if (ret == null) GetDataFailed(prefabName);
        return ret;
    }

    public ScriptableLevelArgs GetLevelArgsData(string name){
        ScriptableLevelArgs ret = levelDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }

    public ScriptableCity GetCityData(string name){
        ScriptableCity ret = cityDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }



    public ScriptableArmy GetArmyData(string name){
        ScriptableArmy ret = armyDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }

    public ScriptableBuilngBase GetBuildingData(string name)
    {
        ScriptableBuilngBase ret = buildingDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }
    public ScriptableEnemy GetEnemyData(string name)
    {
        ScriptableEnemy ret = enemyDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }
    public ScriptableProjectile GetProjectileData(string name)
    {
        ScriptableProjectile ret = projectileDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }
    public ScriptableEnemyGenerator GetEnemyGeneratorData(string name)
    {
        ScriptableEnemyGenerator ret = enemyGeneratorDict[name];
        if (ret == null) GetDataFailed(name);
        return ret;
    }
    public void GetDataFailed(string name)
    {
        Debug.Log($"Get {name} failed");
    }
    
}
