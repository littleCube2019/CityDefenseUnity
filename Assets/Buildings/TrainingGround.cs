using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingGround : BuildingBase
{
    // Start is called before the first frame update
    protected float cooldownTimer;

    protected ScriptableArmy scriptableArmy;

    TrainingGroundArgs trainingGroundArgs;
    void Start()
    {
        
    }


    public override void SetData(ScriptableBuilngBase scirptable)
    {
        base.SetData(scirptable);
        ScriptableTrainingGround scriptableTrainingGround = scirptable as ScriptableTrainingGround;
        trainingGroundArgs = scriptableTrainingGround.trainingGroundArgs;
        scriptableArmy = ResourceSystem.Instance.GetArmyData(scriptableTrainingGround.army);
        
    }
    // Update is called once per frame
    void Update()
    {
        //if (populationNum < baseArgs.minWorker) return;
        if(cooldownTimer>0) cooldownTimer-=Time.deltaTime; 
        else
        {   
            GenerateArmy();
        }
    }

    void GenerateArmy(){
        //if (!EnergySystem.Instance.IsEnergyEnough(trainingGroundArgs.energyPerGenerate)) return;
        Army army = Instantiate(scriptableArmy.prefab, transform.position, Quaternion.identity);
        army.SetData(scriptableArmy);
        
        EnergySystem.Instance.CostEnergy(trainingGroundArgs.energyPerGenerate);
        cooldownTimer = trainingGroundArgs.cooldown ;
    }
}

[System.Serializable]
public struct TrainingGroundArgs
{
  
    public float cooldown;
    public int generateNum;
    public int energyPerGenerate;
}