using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Properties")]
    public float damage = 1;
    public float attackSpeed = 2;
    private float nextFire = 0f;

    public void Attack()
    {
        if (Time.time >= nextFire)
        {
            OnAttack();            
            nextFire = Time.time + 1f / attackSpeed; //manage firerate
        }
    }
    public abstract void OnAttack();
}
public class MeleeWeapon : Weapon
{
    [Header("Melee Properties")]
    public Transform slashCenter;
    public float meleeRange;
    public ParticleSystem meleeEffect;
    public override void OnAttack()
    {
        ConnectSlash();
    }
    public void ConnectSlash()
    {
        if (meleeEffect)
            meleeEffect.Play();

        Collider[] targets = Physics.OverlapSphere(transform.position, meleeRange);
        foreach (Collider target in targets)
        {
            if (target.gameObject.tag == this.gameObject.tag)
                continue;
            if (target.GetComponent<Health>())
            {
                target.GetComponent<Health>().TakeDamage(damage);                
            }
        }
    }
}
