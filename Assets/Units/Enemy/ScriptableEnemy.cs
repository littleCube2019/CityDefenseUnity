using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable/Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    public string enemyName;
    public Sprite sprite;
    public EnemyArgs args;
    public Enemy prefab;
}
[System.Serializable]
public struct EnemyArgs
{
    public int maxHitPoint;
    public int attackPower;
    public float moveSpeed;
    public float cooldown;

    
}