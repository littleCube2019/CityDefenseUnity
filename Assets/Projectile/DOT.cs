// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DOT : ProjectileBase
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float travelDistance = Vector3.Distance(transform.position, startPosition);
//         if (travelDistance >= maxRange) Splash();
//     }
//     public void Splash()
//     {
//         StartCoroutine(DotCoroutine());
//         Destroy(gameObject, effectArgs.duration);
//     }
//     IEnumerator DotCoroutine()
//     {
//         while (true)
//         {
//             Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, effectArgs.effectRange, LayerMask.GetMask("Enemy"));
//             foreach(Collider2D enemy in enemies)
//             {
//                 enemy.GetComponent<IDamagable>().TakeDamage(attackPower);
//             }
//             yield return new WaitForSeconds(1f);
//         }
//     }
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (!collision.CompareTag("Enemy"))
//         {
//             Splash();
//         }
//     }
// }
