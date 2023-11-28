using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

[CreateAssetMenu(fileName = "Turret", menuName = "Scriptable/Turrets")]
public class ScriptableTurret : ScriptableBuilngBase
{
    public TurretType turretType;
    public TurretArgs turretArgs;
    public string projectile;
    public Turret.UpgradeType upgradeType;
}

public enum TurretType
{
    main, support
}