using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_UI : MonoBehaviour
{
    [SerializeField] Transform slotContainer;
    [SerializeField] Transform slotTemplate;
    Wall wall;
    public void SetData(Wall wall)
    {
        this.wall = wall;
        foreach(Transform icon in slotContainer)
        {
            if(icon==slotTemplate) icon.gameObject.SetActive(false);
            else Destroy(icon.gameObject);
        }
        foreach(BuildingBase building in wall.buildingList)
        {
            Transform slot = Instantiate(slotTemplate, slotContainer);
            Transform icon = slot.Find("BuildingImage");
            if (building==null) icon.gameObject.SetActive(false);
            else
            {
                ScriptableBuilngBase scriptable = ResourceSystem.Instance.GetBuildingData(building.buildingName);
                icon.GetComponent<Image>().sprite = scriptable.sprite;
                icon.gameObject.SetActive(true);
            }
            slot.gameObject.SetActive(true);
        }
    }
}
