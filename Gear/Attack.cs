using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    float attackVal;
    public Animator animatorA;
    public Weapon attack;
    private void Start()
    {
        attackVal = attack.damage;
        animatorA.speed = attack.attackSpeed;
    }
    private void OnTriggerEnter2D(Collider2D col) // collision = component of object that collided
    {
        if (animatorA.GetCurrentAnimatorStateInfo(0).IsName("SamAttack1"))
        {
            Debug.Log("GameObject2 collided with " + col.name);
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<EnemyHealth>().health -= attackVal;
            }
            
        }
        if (animatorA.GetCurrentAnimatorStateInfo(0).IsName("SpecialSam"))
        {
            Debug.Log("GameObject2 collided with " + col.name);
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<EnemyHealth>().health -= (attackVal*15/10);
            }

        }
    }
}
