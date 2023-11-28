using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseLevelButton : MonoBehaviour, IPointerDownHandler
{
    public string levelName;
    
    public void OnPointerDown(PointerEventData eventData){
   
      
        GameDataRecorder.Instance.setLevelName( levelName );
        SceneSwitcher.Instance.SwitchSceneTo("SampleScene");
    }
}
