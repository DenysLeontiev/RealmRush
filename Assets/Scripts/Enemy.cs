using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int goldReward = 25;
    [SerializeField] private int goldPenalty = 25;
    private Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    void Update()
    {
        
    }

    public void RewardGold()
    {
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        bank.Withdraw(goldPenalty);
    }
}
