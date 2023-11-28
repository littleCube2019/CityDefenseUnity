using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EffectHandler
{
    Transform host;
    IDamagable damagable;
    public EffectHandler(Transform host)
    {
        this.host = host;
        damagable= host.GetComponent<IDamagable>();
    }

    public void TakeEffect()
    {

    }
    public void TakeDamage(int damage)
    {
        if(damagable==null) { return; }
        damagable.TakeDamage(damage);
    }
}
