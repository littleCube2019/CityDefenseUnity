using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level args", menuName = "Scriptable/Level args")]
public class ScriptableLevelArgs : ScriptableObject
{
    public string levelName;
    public LevelManagerArgs levelArgs;
}
