using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TechTreeSystem : PersistentSingleton<TechTreeSystem>
{
    List<string> unlockBuildings;
    List<string> lockBuildings;
    // Start is called before the first frame update
    void Start()
    {
        unlockBuildings= new List<string>();
        lockBuildings = ResourceSystem.Instance.buildingList.Select(d => d.buildingName).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void UnlockTurret(string turretName)
    {
        if (!CanUnlcokTurret(turretName)) return;
        if (unlockBuildings.Contains(turretName)) return;
        if (!lockBuildings.Contains(turretName)) return;
        lockBuildings.Remove(turretName);
        unlockBuildings.Add(turretName);
    }
    public bool CanUnlcokTurret(string turretName)
    {
        ScriptableTurret scriptable = ResourceSystem.Instance.GetTurretData(turretName);
        if(scriptable==null) return false;
        List<string> require = scriptable.unlockRequire;
        return require.All(d => unlockBuildings.Contains(d));
    }
    */
}
