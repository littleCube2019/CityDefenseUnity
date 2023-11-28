using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(int damage);
    void TakeEffect(EffectArgs effectArgs);
}

public interface IPopulation
{
    void SetPopulation(PopulationType type, int num);
    void GetPopulation(out PopulationType type, out int num);
}

public interface IUpgrade
{   
    void Upgrade_(ScriptableChoiceNode nextNode);
    
    int experiencePoint{ get; set;}
    ScriptableChoiceNode currentChoiceNode { get; set;}

    void GainExp(int v);
    void LevelUp();
 
    
}
//public interface IEffectable