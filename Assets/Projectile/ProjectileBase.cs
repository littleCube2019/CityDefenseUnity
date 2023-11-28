using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{   
    
    
    protected Rigidbody2D rb;
    
    protected ProjectileArgs projectileArgs;

    protected EffectArgs effectArgs;
    protected int attackPower;

    protected float maxRange;
    protected Vector3 startPosition;

    bool isSplashing;
    ScriptableProjectile scriptable;

    float travelDistance;
    [SerializeField] Animator animator;
    public AnimatorOverrideController projectileAnimation;
    public AnimatorOverrideController effectAnimation;
    // Start is called before the first frame update
    void Awake()
    {   
        travelDistance = 0;
        isSplashing = false;
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void SetData(ScriptableProjectile scriptable, int attackPower, ProjectileArgs projectileArgs, EffectArgs effectArgs)
    {   
        this.scriptable = scriptable;
        GetComponent<SpriteRenderer>().sprite = scriptable.sprite;
        
        this.projectileArgs = projectileArgs;
        this.effectArgs = effectArgs;


        this.attackPower = attackPower;

        projectileAnimation = scriptable.projectileAnimation;
        effectAnimation = scriptable.effectAnimation;
    }
    public virtual void Launch(Vector2 direction, float maxRange)
    {   
        


        rb.velocity = direction.normalized * projectileArgs.speed;
        
        if(projectileArgs.isPrabola){
            this.maxRange = direction.magnitude;
        }
        else{
            this.maxRange = maxRange;
        }
        
        projectileArgs.chainCounter -= 1 ;
        
        travelDistance = 0;
        startPosition = transform.position;
        
        // if(projectileArgs.scatterNum != 0){
        //     int oneSide = projectileArgs.scatterNum / 2;
        //     int angleUnit =  projectileArgs.scatterAngle / (oneSide * 2 + 1);
        //     for(int i = -oneSide ; i < oneSide ; i++){
        //         if(i == 0) continue;
        //         Vector2 nextDirection = Quaternion.AngleAxis(angleUnit * i, Vector3.forward) * direction;
        //         projectileArgs.scatterNum = 0;
        //         ProjectileBase nextProjectile = Instantiate( this , transform.position, Quaternion.identity  );
                
        //         print(nextDirection);
        //         nextProjectile.Launch( nextDirection , this.maxRange  );
        //     }
            
        // }

        //animator.runtimeAnimatorController = projectileAnimation;
    }

    void Update(){
        travelDistance = Vector3.Distance(transform.position, startPosition);
        
        
        
        if (travelDistance >= maxRange ){
            if(effectArgs.splashRange > 0){  //DOT or Explosive (One time DOT)
                StartCoroutine(ISplashOverTime());
            }else{ // normal
                TryDestroy(gameObject);
            }
        }
    }


    void TryDestroy(GameObject gameObject){
        if(projectileArgs.chainCounter >= 0 && travelDistance <  maxRange ) return ;// normal will be -1 here
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || projectileArgs.isPrabola ) return;
        if(collision.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            if(projectileArgs.chainCounter >= 0 ){ // normal will be -1 here
                Transform target = FindOtherNearestTarget(collision.transform); 
             
                if(target != null){ 
                    //print( target.position - transform.position ) ;
                    Launch( target.position - transform.position  , maxRange);
                }
                else{
                    projectileArgs.chainCounter = -1;
                }
                
            }

            if(effectArgs.splashRange > 0){
                StartCoroutine(ISplashOverTime()); //Destroy at the end
            }
            else{
                damagable.TakeEffect(effectArgs);
                damagable.TakeDamage(attackPower);
                if( !projectileArgs.isPenetrated ){
                    TryDestroy(gameObject);
                }
            }

        }
    }



    IEnumerator ISplashOverTime() 
    {   
        if(!isSplashing){
            isSplashing = true;
            rb.velocity = Vector2.zero;
            float duration = effectArgs.splashDuration ;
            while (true)
            {   
                Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, effectArgs.splashRange, LayerMask.GetMask("Enemy"));
                foreach(Collider2D enemy in enemies)
                {
                    enemy.GetComponent<IDamagable>().TakeDamage(attackPower);
                    enemy.GetComponent<IDamagable>().TakeEffect(effectArgs);
                }
                
                
                duration -= 1f;
                
                if( duration <= 0){
                    TryDestroy(gameObject);
                }
                
                yield return new WaitForSeconds(1f);
            }
        }
    }

    private Transform FindOtherNearestTarget(Transform currentEnemy)
    {
        Transform target = null;
        float minDist = Mathf.Infinity;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, maxRange, LayerMask.GetMask("Enemy"));

        foreach(Collider2D enemy in enemies)
        {   
            float dist = Vector2.Distance(enemy.transform.position, transform.position);
            if (dist < minDist && enemy.transform != currentEnemy)
            {
                minDist = dist;
                target = enemy.transform;
            }
        }
        return target;
    }

  

}
