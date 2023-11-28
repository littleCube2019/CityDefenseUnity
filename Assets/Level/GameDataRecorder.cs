using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataRecorder : PersistentSingleton<GameDataRecorder>
{
    string levelName;
    public SkillTreeSystem<string> skillTree { get; private set; }

    private void Start()
    {
        List<string> unlocked = new List<string>();
        List<string> locked = new List<string>() { "00006","00013","01006","01013","02006","02013" }; //todo
        skillTree = new SkillTreeSystem<string>(unlocked, locked);
        //skillTree.SetRequireSkill("Gun Powder", new List<string>() { "require1", "require2" }); //todo
    }
    public void setLevelName( string name){
        levelName = name;
    }

    public string getLevelName(){
        return levelName;
    }
}
