using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float CurrentEnergyAmount {  get; private set; }

    [SerializeField] private float maxEnergyAmount;

    private void Awake()
    {
        CurrentEnergyAmount = maxEnergyAmount;
    }

    public void ConsumeEnergy(float amount)
    {
        CurrentEnergyAmount -= amount;
        if (CurrentEnergyAmount < 0 ) { CurrentEnergyAmount = 0; }
    }
}
