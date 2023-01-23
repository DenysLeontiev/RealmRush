using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [SerializeField] private int difficultyRamp = 1;
    private int currentHitPoints = 0;

    private Enemy enemy;

    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start() 
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
            maxHitPoints+=difficultyRamp;
        }
    }
}
