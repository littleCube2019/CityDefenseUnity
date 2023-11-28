using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurretPanel : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] Image icon;
    [SerializeField] Transform attackPowerInfo;
    [SerializeField] Transform rangeInfo;
    [SerializeField] Transform cooldownInfo;

    [Header("Menu")]
    [SerializeField] Transform turretContainer;
    [SerializeField] Transform turretTemplate;

    BuildingFundation fundation;
    public void SetTurret(BuildingFundation fundation)
    {
        this.fundation = fundation;
        //UpdateInfoPanel();
        //UpdateMenuPanel();
    }
    public void SelectTurret(string turret)
    {
        fundation.SetBuilding(turret);
    }
    /*
    public void UpdateInfoPanel()
    {
        Turret turret = fundation.GetTurret();
        turret.GetLevelData(out int atkLevel, out int rangeLevel, out int cooldownLevel);

        icon.sprite = turret.transform.GetComponent<SpriteRenderer>().sprite;

        attackPowerInfo.Find("Value").GetComponent<Text>().text = atkLevel.ToString();
        attackPowerInfo.Find("LevelUp").GetComponent<Button>().onClick.RemoveAllListeners();
        attackPowerInfo.Find("LevelUp").GetComponent<Button>().onClick.AddListener(() =>
        {
            turret.AttackPowerLevelUp();
            UpdateInfoPanel();
        });

        rangeInfo.Find("Value").GetComponent<Text>().text = rangeLevel.ToString();
        rangeInfo.Find("LevelUp").GetComponent<Button>().onClick.RemoveAllListeners();
        rangeInfo.Find("LevelUp").GetComponent<Button>().onClick.AddListener(() => 
        { 
            turret.RangeLevelUp();
            UpdateInfoPanel();
        });

        cooldownInfo.Find("Value").GetComponent<Text>().text = cooldownLevel.ToString();
        cooldownInfo.Find("LevelUp").GetComponent<Button>().onClick.RemoveAllListeners();
        cooldownInfo.Find("LevelUp").GetComponent<Button>().onClick.AddListener(() => 
        { 
            turret.CooldownLevelUp();
            UpdateInfoPanel();
        });

    }
    
    public void UpdateMenuPanel()
    {
        List<ScriptableBuiingBase> buildingList = ResourceSystem.Instance.buildingList.Where(d => d.turretType == fundation.turretType).ToList();
        foreach(Transform child in turretContainer)
        {
            if(child==turretTemplate) child.gameObject.SetActive(false);
            else Destroy(child.gameObject);
        }
        foreach(ScriptableTurret turret in buildingList)
        {
            Transform turretSlot = Instantiate(turretTemplate, turretContainer);
            turretSlot.GetComponent<Image>().sprite = turret.sprite;
            turretSlot.GetComponent<Button>().onClick.AddListener(() => {
                SelectTurret(turret.turretName);
                //UpdateInfoPanel();
            });
            turretSlot.gameObject.SetActive(true);
        }
    }
    */
}
