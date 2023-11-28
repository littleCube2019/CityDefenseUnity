// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Arrow : ProjectileBase
// {
//     private void Update()
//     {
//         float travelDistance = Vector3.Distance(transform.position, startPosition);
//         if(travelDistance>=maxRange) Destroy(gameObject);
//     }
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (!collision.CompareTag("Enemy")) return;
//         if(collision.TryGetComponent<IDamagable>(out IDamagable damagable))
//         {
//             damagable.TakeDamage(attackPower);
//             Destroy(gameObject);
//         }
//     }
// }
