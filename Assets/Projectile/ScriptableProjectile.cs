using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Scriptable/Projectile")]
public class ScriptableProjectile : ScriptableObject
{
    public string projectileName;
    public Sprite sprite;
    public ProjectileArgs projectileArgs;

    public EffectArgs effectArgs;
    public ProjectileBase prefab;
    [Header("Animation")]
    public AnimatorOverrideController projectileAnimation;
    public AnimatorOverrideController effectAnimation;
}

[System.Serializable]
public struct ProjectileArgs
{
    public float speed;
    public bool isPenetrated;

    public bool isPrabola;

    public int chainCounter;


}

[System.Serializable]
public struct EffectArgs
{
    
    public float splashRange;
    public float splashDuration;

    public float knockBackForce;

    public int DOTdamage;
    public float DOTduration;


}