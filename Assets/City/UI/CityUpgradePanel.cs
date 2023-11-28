// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class CityUpgradePanel : MonoBehaviour
// {
//     [SerializeField] Button btnHQUpgrade;
//     [SerializeField] Button btnWallUpgrade;
//     [SerializeField] List<Wall_UI> ui_walls; // up right down left
//     [SerializeField] WallUpgradePanel wallUpgradePanel;

//     private void Start()
//     {
//         btnHQUpgrade.onClick.AddListener(() => { 
//             City.Instance.UpgradeHQ();
//             UpdateUI();
//         });
//         btnWallUpgrade.onClick.AddListener(() => {
//             City.Instance.UpgradeWall();
//             UpdateUI();
//         });

//         for(int i=0; i< ui_walls.Count; i++)
//         {
//             int index = i;
//             Button btn = ui_walls[index].GetComponent<Button>();
//             btn.onClick.AddListener(() => ShowWallPanel(City.Instance.walls[index]));
//             City.Instance.walls[index].OnBuildingChange += OnBuildingChange;
//         }
//     }
//     // public void OnBuildingChange(object sender, EventArgs args)
//     // {
//     //     UpdateUI();
//     // }
//     public void ShowWallPanel(Wall wall)
//     {
//         wallUpgradePanel.SetData(wall);
//         wallUpgradePanel.gameObject.SetActive(true);
//     }
//     // public void UpdateUI()
//     // {
//     //     for(int i=0; i<ui_walls.Count; i++)
//     //     {
//     //         ui_walls[i].SetData(City.Instance.wall);
//     //     }
//     // }
    
// }
