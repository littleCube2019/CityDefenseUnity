using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] Level_UI level_ui;
    
    public LevelManagerArgs levelManagerArgs;

    


    int time;

    float coolDownTime = 4;
    int enemyGeneratedNum = 0;
    private void Start()
    {   
        
        
        string levelName;
        if( GameDataRecorder.Instance == null){
            levelName = "test_1" ;
        }
        else{
            levelName =  GameDataRecorder.Instance.getLevelName();
        }
        levelManagerArgs = ResourceSystem.Instance.GetLevelArgsData(levelName).levelArgs;

        for(int i = 0 ; i < levelManagerArgs.enemyName.Count ; i ++){
            StartCoroutine(ISpawn(levelManagerArgs.enemyName[i],levelManagerArgs.enemyCoolDownTime[i] ));
        } 
        time = 0 ;

        City.Instance.SetData("test");
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            if(EnergySystem.Instance.GetTotalEnergy() >= levelManagerArgs.targetEnergy){
                print("You win :)");
                StopAllCoroutines();
            }
            else{
                print("Not yet :(");
            }
        }

        // time += 1 ;

        // if(time == 60000){
        //     print("gogo");
        //     StopAllCoroutines();
        //     for(int i = 0 ; i < levelManagerArgs2.enemyName.Count ; i ++){
        //         StartCoroutine(ISpawn(levelManagerArgs2.enemyName[i],levelManagerArgs2.enemyCoolDownTime[i] ));
        //     } 
        // }
        // if(time == 160000){
        //     print("gogo");
        //     StopAllCoroutines();
        //     for(int i = 0 ; i < levelManagerArgs3.enemyName.Count ; i ++){
        //         StartCoroutine(ISpawn(levelManagerArgs3.enemyName[i],levelManagerArgs3.enemyCoolDownTime[i] ));
        //     } 
        // }
    }
    
    public void LevelComplete()
    {
        Debug.Log("Level Complete");
    }
    public void GameOver()
    {

    }
    

    


    public IEnumerator ISpawn(string name, float coolDownTime){
        
        while(true){
            yield return new WaitForSeconds(coolDownTime);
            enemyGeneratedNum += 1;
            Vector2 randomPos = 8f * Random.insideUnitCircle.normalized;
            SpawnEneny(name, randomPos);
            //SpawnEneny("noraml", randomPos);
            if(enemyGeneratedNum % 5 == 0){
                coolDownTime *= 0.9f;
                coolDownTime = Mathf.Max(coolDownTime, 0.5f);
            }
            //yield return new WaitForSeconds(coolDownTime);
        }
    }

  
    public void SpawnEneny(string name, Vector2 position)
    {
        ScriptableEnemy scriptable = ResourceSystem.Instance.GetEnemyData(name);
        Enemy enemy = Instantiate(scriptable.prefab, position, Quaternion.identity);
        enemy.SetData(scriptable);
    }
}
[System.Serializable]
public struct LevelManagerArgs
{
    public List<string> enemyName ;
    public List<float> enemyCoolDownTime;

    public int targetEnergy;
}