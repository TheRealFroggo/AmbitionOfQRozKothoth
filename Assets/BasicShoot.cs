using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour
{
    [Tooltip("Amount of shots fired per second")]
    public float FireRate;
    private float TimeBetweenShots;
    private float FireRateTimer;

    [Header("Projectile")]
    public Projectile WeaponProjectile;

    private void Start()
    {
        TimeBetweenShots = 1.0f / FireRate;
    }

    private void FixedUpdate()
    {
        FireRateTimer += Time.fixedDeltaTime;
        if (FireRateTimer > TimeBetweenShots)
        {
            FireRateTimer = 0.0f;
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        Projectile Bullet = Instantiate(WeaponProjectile);

        Bullet.transform.position = transform.GetChild(0).transform.position;

        Vector3 rot = transform.rotation.eulerAngles;
        Bullet.transform.rotation = Quaternion.Euler(rot);

        Bullet.Direction = transform.right;
    }
}
