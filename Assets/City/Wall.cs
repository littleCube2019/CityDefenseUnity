using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Wall : MonoBehaviour, IDamagable, IUpgrade
{
    [SerializeField] HpBar hpbar;
    public event EventHandler OnBuildingChange;
    
    // Wall argument
    int maxHitPoint = 100;
    int hitPoint;

    int repairAmount;
    // Wall argument
    public bool isActivate { get; private set; }
    public int buildingSlotSize = 1;
    public Vector2 direction;
    public List<BuildingBase> buildingList { get; private set; }
    [SerializeField] Transform buildingContainer;

    public int experiencePointRate;
    int ExperiencePoint;

    public int experiencePoint{
        get{
            return this.ExperiencePoint;
        }
        set{
            this.ExperiencePoint = value;
        }
    }



    public ScriptableChoiceNode CurrentChoiceNode;

    public ScriptableChoiceNode currentChoiceNode{
        get{
            return this.CurrentChoiceNode;
        }
        set{
            this.CurrentChoiceNode = value;
        }
    }

    public void GainExp(int rate){
        StartCoroutine(IGainExp(rate));
    }

    IEnumerator IGainExp(int rate){

        while (true)
        {
            if(currentChoiceNode.left != null){
                experiencePoint += rate;
                
                if(experiencePoint >= 11){
                    LevelUp();
                    experiencePoint = 0;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void LevelUp(){
        Time.timeScale=0;
       
        UpgradePanelUI.Instance.openPanel(currentChoiceNode.left, currentChoiceNode.right , this);
    }


    public void Upgrade_(ScriptableChoiceNode nextNode){
        currentChoiceNode = nextNode;
        if( currentChoiceNode.choiceArgs.key == "Hp"){
            maxHitPoint += 500;
        }
        if( currentChoiceNode.choiceArgs.key == "Repair"){
            repairAmount += 500; 
        }
    }


    public void SetData(WallArgs wallArgs, List<string>buildings ){
        maxHitPoint = wallArgs.maxHitPoint; 
        hitPoint = maxHitPoint;
        buildingList = new List<BuildingBase> { null };
        StartCoroutine(AutoRepairCoroutine());
        GainExp(experiencePointRate);
        foreach(string b in buildings){
            SetBuilding(b);
        }
    }

    // private void Start()
    // {
    //     hitPoint = maxHitPoint;
    //     isActivate = false;
    //     buildingList = new List<BuildingBase> { null };
    //     StartCoroutine(AutoRepairCoroutine());
    // }
    public void Upgrade()
    {
        buildingSlotSize += 1;
        buildingList.Add(null);
    }

    public void SetBuilding(string buildingName)
    {
        // if(index >= buildingSlotSize)
        // {
        //     Debug.Log("Set Building Error");
        //     return;
        // }
        ScriptableBuilngBase scriptable = ResourceSystem.Instance.GetBuildingData(buildingName);
        BuildingBase building = Instantiate(scriptable.prefab, buildingContainer);
        building.SetData(scriptable);
        building.SetActivate(isActivate);
        //buildingList[index] = building;
        buildingList.Add(building);
        OnBuildingChange?.Invoke(this, EventArgs.Empty);
    }

    public void TakeDamage(int damage)
    {
        hitPoint = Mathf.Max(0, hitPoint - damage);
        if (hitPoint == 0)
        {
            SetActive(false);
        }
        hpbar.SetValue(hitPoint, maxHitPoint);
    }
    public void Repair(int amount)
    {
        int repairAmount = Mathf.Min(maxHitPoint - hitPoint, amount);
        if (EnergySystem.Instance.CostEnergy(repairAmount))
        {
            hitPoint += repairAmount;
        }
        if (hitPoint == maxHitPoint)
        {
            SetActive(true);
        }
        hpbar.SetValue(hitPoint, maxHitPoint);
    }
    void SetActive(bool active)
    {
        isActivate = active;
        foreach (BuildingBase building in buildingList)
        {
            if (building != null) { building.SetActivate(active); }
        }
        GetComponent<Collider2D>().isTrigger = !active;
    }

    public void TakeEffect(EffectArgs effectArgs) { }
    IEnumerator AutoRepairCoroutine()
    {
        while (true)
        {
            Repair(repairAmount);
            yield return new WaitForSeconds(0.5f);
        }
    }


}
