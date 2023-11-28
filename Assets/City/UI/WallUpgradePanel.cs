// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class WallUpgradePanel : MonoBehaviour
// {
//     [SerializeField] Transform buildingPanelContianer;
//     [SerializeField] Transform buildingPanelTemplate;

//     [Header("Building Menu")]
//     [SerializeField] Transform buildingMenuPanel;
//     [SerializeField] Transform buildingMenuSlotContainer;
//     [SerializeField] Transform buildingMenuSlotTemplate;

//     List<BuildingBase> buildingList;
//     Wall wall;
//     public void SetData(Wall wall)
//     {
//         if(this.wall!=null) this.wall.OnBuildingChange -= this.OnBuildingChange;
//         this.wall = wall;
//         this.wall.OnBuildingChange += this.OnBuildingChange;
//         UpdateData();
//         CloseBuildingMenu();
//     }
//     public void OnBuildingChange(object sender, EventArgs args)
//     {
//         CloseBuildingMenu();
//         UpdateData();
//     }
//     public void UpdateData()
//     {
//         buildingList = new List<BuildingBase>(wall.buildingList);
//         foreach (Transform panel in buildingPanelContianer)
//         {
//             if (panel == buildingPanelTemplate) panel.gameObject.SetActive(false);
//             else Destroy(panel.gameObject);
//         }
//         for(int i=0; i<buildingList.Count; i++)
//         {
//             int index = i;
//             Transform buildingPanel = Instantiate(buildingPanelTemplate, buildingPanelContianer);
//             Transform icon = buildingPanel.Find("Icon");
//             Button btnUpgrade = buildingPanel.Find("UpgradeButton").GetComponent<Button>();
//             if (buildingList[i] != null)
//             {
//                 icon.GetComponent<Image>().sprite = buildingList[i].sprite;
//                 btnUpgrade.onClick.AddListener(() => buildingList[index].Upgrade());
//             }
//             else
//             {
//                 btnUpgrade.gameObject.SetActive(false);
//             }
//             icon.GetComponent<Button>().onClick.AddListener(() => {
//                 //wall.SetBuilding("test_training_ground", index);
//                 ShowBuildingMenu(index);
//             });
            
//             buildingPanel.gameObject.SetActive(true);
//         }
//     }
//     public void ShowBuildingMenu(int index)
//     {
//         BuildingBase originBuilding = wall.buildingList[index];
//         List<ScriptableBuilngBase> buildings = ResourceSystem.Instance.buildingList;
//         foreach(Transform slot in buildingMenuSlotContainer)
//         {
//             if (slot != buildingMenuSlotTemplate) Destroy(slot.gameObject);
//             else slot.gameObject.SetActive(false);
//         }
//         foreach(ScriptableBuilngBase building in buildings)
//         {
//             if (originBuilding!=null && building.buildingName == originBuilding.buildingName) continue;
//             Transform slot = Instantiate(buildingMenuSlotTemplate, buildingMenuSlotContainer);
//             slot.GetComponent<Image>().sprite = building.sprite;
//             slot.GetComponent<Button>().onClick.RemoveAllListeners();
//             slot.GetComponent<Button>().onClick.AddListener(() => { wall.SetBuilding(building.buildingName); });
//             slot.gameObject.SetActive(true);
//         }
//         buildingMenuPanel.gameObject.SetActive(true);
//     }
//     public void CloseBuildingMenu()
//     {
//         buildingMenuPanel.gameObject.SetActive(false);
//     }
// }
