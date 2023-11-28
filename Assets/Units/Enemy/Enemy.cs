using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

//using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    
    [SerializeField] HpBar hpBar;

    EnemyArgs args;

    Transform target;
    Rigidbody2D rb;
    int hitPoint;
    float cooldownTimer;

    float DOTduration ;
    int DOTdamage;
    bool isKnockedBack;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindTarget();
        DOTduration = 0;
        StartCoroutine( IDOTdamage() );
        isKnockedBack = false;
    }



    private void Update()
    {
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;

        if (target != null && !isKnockedBack)
        {
            Vector2 faceDir = (target.position - transform.position).normalized;
            rb.velocity = args.moveSpeed * faceDir;
        }
    }
    public void SetData(ScriptableEnemy scriptable)
    {
        GetComponent<SpriteRenderer>().sprite = scriptable.sprite;
        args = scriptable.args;
        hitPoint = args.maxHitPoint;

        
    }
    public void FindTarget()
    {
        target = FindObjectOfType<City>().transform;
        
    }
    public void Attack(Transform target)
    {
        if (cooldownTimer > 0) return;
//        Debug.Log("attack");
        if(target.TryGetComponent<IDamagable>(out IDamagable damagable)){
            damagable.TakeDamage(args.attackPower);
        }
        cooldownTimer = args.cooldown;

        
    }
    public void TakeDamage(int damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0) {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        hpBar.SetValue(hitPoint, args.maxHitPoint);
    }

    public void TakeEffect(EffectArgs effectArgs){
        if(effectArgs.knockBackForce != 0 && !isKnockedBack){
            Vector2 force = rb.velocity * -1 * effectArgs.knockBackForce;
            StartCoroutine(IKnockBack(force));
        }

    

        if(effectArgs.DOTdamage != 0){
            DOTduration = effectArgs.DOTduration;
            DOTdamage = effectArgs.DOTdamage;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("City"))
        {
            Attack(collision.transform);
        }
    }

    IEnumerator IDOTdamage(){
        while(true){
            if( DOTduration > 0 ){
                DOTduration -= 1;
                TakeDamage( DOTdamage );
                
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator IKnockBack(Vector2 force){
        //Vector2 originalVelocity = rb.velocity;
        isKnockedBack= true;
        rb.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        isKnockedBack = false;
    }

}
