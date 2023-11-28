using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour,IDamagable
{
    // Start is called before the first frame update
    [SerializeField] HpBar hpBar;
    Rigidbody2D rb;
    ArmyArgs args;
    float hitPoint;
    float cooldownTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
        Transform target = FindOneNearestTarget();
        if (target != null)
        {   
            
            Vector2 faceDir = (target.position - transform.position).normalized;
            rb.velocity = args.moveSpeed * faceDir;
        }

    }

    public void TakeEffect(EffectArgs effect){

    }

    public void TakeDamage(int damage){
        hitPoint -= damage;
        if (hitPoint <= 0) {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        
        hpBar.SetValue(hitPoint, args.maxHitPoint);
    }

    public void Attack(Transform target)
    {
        if (cooldownTimer > 0) return;
        Debug.Log("attack");
        if(target.TryGetComponent<IDamagable>(out IDamagable damagable)){
            damagable.TakeDamage(args.attackPower);
        }
        cooldownTimer = args.cooldown;

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Attack(enemy.transform);
        }
        
    }

    public void SetData(ScriptableArmy scriptable)
    {
        GetComponent<SpriteRenderer>().sprite = scriptable.sprite;
        args = scriptable.args;
        hitPoint = args.maxHitPoint;

        
    }

    private Transform FindOneNearestTarget()
    {
        Transform target = null;
        float minDist = Mathf.Infinity;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, args.fieldOfView, LayerMask.GetMask("Enemy"));

        foreach(Collider2D enemy in enemies)
        {
            float dist = Vector2.Distance(enemy.transform.position, transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                target = enemy.transform;
            }
        }
        return target;
    }

}
