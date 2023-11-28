using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_UI : Singleton<Level_UI>
{
    [SerializeField] Text txtEnergy;
    
    // Start is called before the first frame update
    void Start()
    {   
        EnergySystem.Instance.OnEnergyChange += UpdateEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateEnergy(object sender, EnergySystem.OnEnergyChangeArgs args)
    {
        txtEnergy.text = $"{args.energy} / {args.maxEnergy}";
    }
}
