using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float CurrentEnergyAmount {  get; private set; }

    [SerializeField] private float maxEnergyAmount;
    
    private float currentEnergyAmount;

    private void Awake()
    {
        currentEnergyAmount = maxEnergyAmount;
    }

    public void ConsumeEnergy(float amount)
    {
        currentEnergyAmount -= amount;
        if (currentEnergyAmount < 0 ) { currentEnergyAmount = 0; }
    }

}
