using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGenerator", menuName = "Scriptable/EnemyGenerator")]
public class ScriptableEnemyGenerator : ScriptableObject
{
    public string enemyGeneratorName;
    public EnemyGeneratorType enemyGeneratorType;

    public string generatedEnemyName;
    public float generateTimeInterval; 
    
    public int maxEnemyNum;
    public EnemyGeneratorBase prefab;
    public Sprite sprite;


    public enum EnemyGeneratorType
    {
        main
    }

}
