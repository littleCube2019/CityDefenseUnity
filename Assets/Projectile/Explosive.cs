// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Explosive : ProjectileBase
// {
//     void Update()
//     {
//         float travelDistance = Vector3.Distance(transform.position, startPosition);
//         if (travelDistance >= maxRange) Explode();
//     }
//     public void Explode()
//     {
//         Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, args.effectRange, LayerMask.GetMask("Enemy"));
//         foreach(Collider2D enemy in enemies)
//         {
//             enemy.GetComponent<IDamagable>().TakeDamage(attackPower);
//         }
//         Destroy(gameObject);
//     }
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Enemy"))
//         {
//             Explode();
//         }
//     }
// }
