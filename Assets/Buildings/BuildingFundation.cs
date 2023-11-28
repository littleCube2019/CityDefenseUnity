using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFundation : MonoBehaviour
{
    //[SerializeField] Transform turretSlot;
    public TurretType turretType;
    BuildingBase building;

    void Update()
    {

    }
    public void SetBuilding(string building)
    {
        Debug.Log($"set building {building}");
        Transform turretSlot = transform.Find("TurretSlot");
        foreach(Transform child in turretSlot)
        {
            Destroy(child.gameObject);
        }
        ScriptableBuilngBase scriptableBuilding = ResourceSystem.Instance.GetBuildingData(building);
        if (scriptableBuilding != null)
        {
            BuildingBase buildingPrefab = Instantiate(scriptableBuilding.prefab, turretSlot);
            buildingPrefab.SetData(scriptableBuilding);
            this.building = buildingPrefab;
        }
        else
        {
            this.building = null;
        }
    }
}
