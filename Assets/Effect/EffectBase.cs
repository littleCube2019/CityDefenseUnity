using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBase : MonoBehaviour
{
    EffectArgs args;
    EffectHandler handler;
    public virtual void SetData(EffectArgs args)
    {
        this.args = args;
    }
    public virtual void EffectBegin(EffectHandler handler)
    {

    }
    public virtual void EffectEnd()
    {

    }
    public virtual IEnumerator DamageCoroutine()
    {
        while (true)
        {

        }
    }
}
