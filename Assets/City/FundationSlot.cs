using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundationSlot : MonoBehaviour
{
    BuildingFundation turretFundation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFundation(string fundationName)
    {
        GameObject fundationPrefab = ResourceSystem.Instance.GetPrefab(fundationName);
        if (fundationPrefab == null) return;
        GameObject fundation = Instantiate(fundationPrefab, transform);
        turretFundation = fundation.GetComponent<BuildingFundation>();
    }
    private void OnMouseDown()
    {
        //City_UI.Instance.ShowFundationUI(this);
    }
}
