using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelUI : Singleton<UpgradePanelUI>
{
    // Start is called before the first frame update
    public List<ChoiceUI> choiceList;
    public GameObject panel;


    public void closePanel(){
        panel.SetActive(false);
    }

    public void openPanel( ScriptableChoiceNode left, ScriptableChoiceNode right, IUpgrade targetTurret ){
        panel.SetActive(true);

        choiceList[0].setChoiceUI(left, targetTurret);
        choiceList[1].setChoiceUI(right, targetTurret);
    }
    
}
