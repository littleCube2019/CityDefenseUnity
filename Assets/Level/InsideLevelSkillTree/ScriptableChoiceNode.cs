using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Choice node", menuName = "Scriptable/Choice node")]
public class ScriptableChoiceNode : ScriptableObject
{
    public ChoiceArgs choiceArgs;

    public ScriptableChoiceNode left;
    public ScriptableChoiceNode right;
}
