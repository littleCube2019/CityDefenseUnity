using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Army", menuName = "Scriptable/Army")]
public class ScriptableArmy : ScriptableObject
{
    public string armyName;
    public Sprite sprite;
    public ArmyArgs args;
    public Army prefab;
}


[System.Serializable]
public struct ArmyArgs
{
    public float maxHitPoint;
    public int attackPower;
    public float moveSpeed;
    public float cooldown;

    public float fieldOfView;
}


