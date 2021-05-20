using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    enum ActiveState
    {
        ready,
        firing,
        cooldown,
        reload
    }

    [Header("Attacking")]
    [Tooltip("Does holding down the attack button continously fire")]
    public bool isAutoFire;
    [Tooltip("Amount of shots fired per second")]
    public float FireRate;
    private float TimeBetweenShots;
    private float FireRateTimer;
    [Tooltip("Amount of time in seconds it takes to reload")]
    public float ReloadSpeed;
    private float ReloadTimer;
    [Tooltip("How many bullets can be held in one clip")]
    public int ClipSize;
    [Tooltip("How many bullets it comsumes per shot")]
    public int BulletsPerShot;
    private int CurrentShots;

    private ActiveState State = ActiveState.ready;

    [Header("Projectile")]
    public Projectile WeaponProjectile;

    void Start()
    {
        TimeBetweenShots = 1.0f / FireRate;
        CurrentShots = ClipSize;
    }

    void Update()
    {
        switch (State)
        {
            case ActiveState.ready:
                switch (isAutoFire)
                {
                    case true:
                        if (Input.GetMouseButton(0))
                            State = ActiveState.firing;
                        break;
                    case false:
                        if (Input.GetMouseButtonDown(0))
                            State = ActiveState.firing;
                        break;
                }
                break;

            case ActiveState.firing:
                CurrentShots -= BulletsPerShot;
                State = ActiveState.cooldown;
                SpawnProjectile();

                if (CurrentShots <= 0)
                    State = ActiveState.reload;
                break;

            case ActiveState.cooldown:
                FireRateTimer += Time.deltaTime;
                if (FireRateTimer > TimeBetweenShots)
                {
                    FireRateTimer = 0.0f;
                    State = ActiveState.ready;
                }
                break;

            case ActiveState.reload:
                ReloadTimer += Time.deltaTime;
                if (ReloadTimer > ReloadSpeed)
                {
                    CurrentShots = ClipSize;
                    ReloadTimer = 0.0f;
                    State = ActiveState.ready;
                }
                break;
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
