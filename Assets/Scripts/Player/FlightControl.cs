using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlightControl : MonoBehaviour
{
    [SerializeField] private float turnSpeed;

    private PlayerControls playerControls;
    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponentInChildren<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Flight.Rotate.performed += _ => OnRotate();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void OnRotate()
    {
        float direction = playerControls.Flight.Rotate.ReadValue<float>();
        myRigidbody.AddTorque(direction * turnSpeed);
        Debug.Log("Turning");
    }
}
