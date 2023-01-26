using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private ParticleSystem projectiles;
    [SerializeField] private float range = 15f;
    private Transform target;

    private void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    private void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                maxDistance = targetDistance;
                closestEnemy = enemy.transform;
            }
        }

        target = closestEnemy;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        try
        {
            var emmisionModule = projectiles.emission;
            emmisionModule.enabled = isActive;
        }
        catch
        {
            
        }
    }
}
