//using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Image hpBar;

    float hp;
    float maxHp;
    public void SetValue(float hp, float maxHp)
    {
        hpBar.fillAmount = hp / maxHp;
    }
    public float GetValue()
    {
        return hp;
    }
}
