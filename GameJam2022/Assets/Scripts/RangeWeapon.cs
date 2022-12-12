using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public Transform weaponOrigin;
    public GameObject projectile;
    private Ray ray;
    private RaycastHit hit;

    // explosion
    [Header("Explosion Properties")]
    public float explosionRange;

    // forces
    [Header("Launch Properties")]
    public float forwardForce;
    public bool hasGravity = false;
    public float upwardForce;

    // lifetime
    [Header("Lifetime and Collisions")]
    public float maxLifeTime;

    [Header("Effects")]
    public ParticleSystem muzzleFlash;

    public override void OnAttack()
    {
        FireWeapon();
    }
    public void FireWeapon()
    {
        //bullet tracers for debug
        ray.origin = weaponOrigin.position;
        ray.direction = weaponOrigin.forward;
        if (Physics.Raycast(ray, out hit))
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);

        // play effects
        if (muzzleFlash)
        {
            muzzleFlash.transform.position = weaponOrigin.position;
            muzzleFlash.Play();
        }

        //checks if ray hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //instatiates projectile
        GameObject currentProjectile = Instantiate(projectile, weaponOrigin.position, Quaternion.identity);
        currentProjectile.transform.forward = weaponOrigin.forward.normalized;

        AddProjectileProperties(currentProjectile);

        //adds force to projectile
        currentProjectile.GetComponent<Rigidbody>().AddForce(weaponOrigin.forward.normalized * forwardForce, ForceMode.Impulse);
        currentProjectile.GetComponent<Rigidbody>().AddForce(weaponOrigin.transform.up * upwardForce, ForceMode.Impulse);
    }
    void AddProjectileProperties(GameObject projectile)
    {
        Projectile p = projectile.GetComponent<Projectile>();

        p.explosionDamage = damage;
        p.explosionRange = explosionRange;

        projectile.GetComponent<Rigidbody>().useGravity = hasGravity;
        p.maxLifetime = maxLifeTime;
    }
}
