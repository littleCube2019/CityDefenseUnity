using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected string generatedEnemyName;
    protected float generateTimeInterval; 
    
    protected int maxEnemyNum;

    public virtual IEnumerator ISpawn(){
        for(int curEnemyNum = 0 ; curEnemyNum < maxEnemyNum; curEnemyNum++){
            
            SpawnEneny(generatedEnemyName, transform.position);
            yield return new WaitForSeconds(generateTimeInterval); 
        }
    }

    public virtual void SetData(ScriptableEnemyGenerator scriptable)
    {
        GetComponent<SpriteRenderer>().sprite = scriptable.sprite;
        generatedEnemyName = scriptable.generatedEnemyName;
        generateTimeInterval = scriptable.generateTimeInterval;
        maxEnemyNum = scriptable.maxEnemyNum;
        StartCoroutine(ISpawn());
    }
    // Update is called once per frame
    public void SpawnEneny(string name, Vector2 position)
    {
        ScriptableEnemy scriptable = ResourceSystem.Instance.GetEnemyData(generatedEnemyName);
        Enemy enemy = Instantiate(scriptable.prefab, position, Quaternion.identity);
        enemy.SetData(scriptable);
    }
}
