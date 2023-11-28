using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeadQuarter : Singleton<HeadQuarter>, IDamagable, IUpgrade
{

    //[SerializeField] Transform fundationSlotContainer;
    
    public int maxHitPoint;
    int hitPoint;

    [SerializeField] int energyGain;

    public float GetHitPoint() => hitPoint;

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

    //[SerializeField] Transform buildingContainer;
    //List<BuildingBase> buildingList;

    //List<string> availableUpgrade;

    //public List<BuildingBase> GetBuildings() => buildingList;
    protected override void Awake()
    {
        base.Awake();
        
          
        
    }
    // Start is called before the first frame update
    public void SetData( HeadQuarterArgs headQuarterArgs){
        maxHitPoint = headQuarterArgs.maxHitPoint;
        hitPoint = maxHitPoint;
        energyGain = headQuarterArgs.energyGainPerSec;
        StartCoroutine(EnergyGeneratorCoroutine());

        GainExp(experiencePointRate);
    }


    // void Start()
    // {
    //     hitPoint = maxHitPoint;
    //     StartCoroutine(EnergyGeneratorCoroutine());
    // }

    

    public void GainExp(int rate){
        StartCoroutine(IGainExp(rate));
    }

    IEnumerator IGainExp(int rate){

        while (true)
        {
            if(currentChoiceNode.left != null){
                experiencePoint += rate;
                
                if(experiencePoint >= 10){
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
        if( currentChoiceNode.choiceArgs.name == "Energy Gain"){
            energyGain += 20;
        }
        if( currentChoiceNode.choiceArgs.name == "Storage"){
            EnergySystem.Instance.MaxEnergyChange(500);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        hitPoint -= damage;
    }
    public void TakeEffect(EffectArgs effectArgs) { }

    IEnumerator EnergyGeneratorCoroutine()
    {
        while (true)
        {
            EnergySystem.Instance.GainEnergy(energyGain);
            yield return new WaitForSeconds(1);
        }
    }
}
