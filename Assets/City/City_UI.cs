using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_UI : Singleton<City_UI>
{
    [SerializeField] Transform cityUpgradePanel;
    [SerializeField] Transform wallUpgradePanel;
    // Start is called before the first frame update
    void Start()
    {
        CloseUpgradeUI();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (cityUpgradePanel.gameObject.activeInHierarchy) CloseUpgradeUI();
        //     else ShowUpgradeUI();
        // }
    }
    public void ShowUpgradeUI()
    {
        cityUpgradePanel.gameObject.SetActive(true);
        
    }
    public void CloseUpgradeUI()
    {
        cityUpgradePanel.gameObject.SetActive(false);
        wallUpgradePanel.gameObject.SetActive(false);
    }
}
