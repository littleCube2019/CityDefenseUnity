using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChoiceUI : MonoBehaviour, IPointerDownHandler
{
    public Text Name;
    public Text Description;

    public Image Sprite;

    public IUpgrade targetTurret;

    ScriptableChoiceNode choiceNode;
    public void setChoiceUI( ScriptableChoiceNode node, IUpgrade targetTurret){
        choiceNode = node;
        this.Name.text = node.choiceArgs.name;
        this.Description.text = node.choiceArgs.description;
        this.Sprite.sprite = node.choiceArgs.sprite;
        this.targetTurret = targetTurret;
    }

    public void OnPointerDown(PointerEventData eventData){
        Time.timeScale=1;
        UpgradePanelUI.Instance.closePanel();
        
        targetTurret.Upgrade_(choiceNode);
    }
}

[System.Serializable]
public class ChoiceArgs {
    public string name;
    public string description;

    public Sprite sprite;

    public string key;
 

    // public choiceArgs(string name , string description, Sprite sprite){
    //     this.name = name;
    //     this.description = description;
    //     this.sprite = sprite;
    // }

}