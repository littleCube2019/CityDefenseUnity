using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public float dangerZoneRange = 3f;
    List<Transform> dangerZoneEnemy;
    List<Transform> upEnemy;
    List<Transform> leftEnemy;
    List<Transform> downEnemy;
    List<Transform> rightEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateEnemyGroup()
    {
        dangerZoneEnemy.Clear();
        upEnemy.Clear();
        leftEnemy.Clear();
        downEnemy.Clear();
        rightEnemy.Clear();

        Collider2D[] danger = Physics2D.OverlapCircleAll(HeadQuarter.Instance.transform.position, dangerZoneRange, LayerMask.GetMask("Enemy"));
        Collider2D[] enemies = Physics2D.OverlapCircleAll(HeadQuarter.Instance.transform.position, 20f, LayerMask.GetMask("Enemy"));
        dangerZoneEnemy = danger.ToList().Select(d => d.transform).ToList();

        
        foreach(var enemy in enemies)
        {
            if (dangerZoneEnemy.Contains(enemy.transform)) continue;
            Vector2 dir = enemy.transform.position - HeadQuarter.Instance.transform.position;
            if (dir.x > 0 && Mathf.Abs(dir.x) >= Mathf.Abs(dir.y)) rightEnemy.Add(enemy.transform);
            else if (dir.x < 0 && Mathf.Abs(dir.x) >= Mathf.Abs(dir.y)) leftEnemy.Add(enemy.transform);
            else if(dir.y>0) upEnemy.Add(enemy.transform);
            else downEnemy.Add(enemy.transform);
        }
    }
    public Transform SelectTarget(Vector2 dir)
    {
        return null;
    }
}
