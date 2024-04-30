using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class FlightControl : MonoBehaviour
{
    [Header("Flight Variables")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float propelSpeed;
    [SerializeField] private float brakingDrag;

    [Header("Required Game Object References")]
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private GameObject burnerObject;
    [SerializeField] private GameObject smokeEffectObject;

    [Header("Projectile Variables")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileCooldown;

    [Header("Energy Requirements")]
    [SerializeField] private float energyCostToShoot;
    [SerializeField] private float energyCostToShield;
    [SerializeField] private float energyCostToBlink;

    private PlayerControls playerControls;
    private Rigidbody2D myRigidbody;
    private Energy energy;

    private bool isRotating = false;
    private bool isMoving = false;
    private bool isBraking = false;
    private bool isShooting = false;
    private bool canShoot = true;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Flight.Rotate.started += _ => OnRotateStart();
        playerControls.Flight.Rotate.canceled += _ => OnRotateStop();
        playerControls.Flight.Propel.started += _ => OnPropelStart();
        playerControls.Flight.Propel.canceled += _ => OnPropelStop();
        playerControls.Flight.Brake.performed += _ => OnBrake();

        playerControls.Combat.Shield.started += _ => OnShieldStart();
        playerControls.Combat.Shield.canceled += _ => OnShieldStop();
        playerControls.Combat.Fire.performed += _ => OnFire();

        energy = gameObject.GetComponentInChildren<Energy>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnRotateStart()
    {
        isBraking = false;
        isRotating = true;
    }

    private void OnRotateStop()
    {
        isRotating = false;
    }

    private void OnPropelStart()
    {
        isBraking = false;
        isMoving = true;
        burnerObject.SetActive(true);
    }

    private void OnPropelStop()
    {
        isMoving = false;
        burnerObject.SetActive(false);
    }

    private void OnBrake()
    {
        isBraking = true;
        smokeEffectObject.SetActive(true);
    }

    private void OnShieldStart()
    {
        bool canShield = energyCostToShield < energy.CurrentEnergyAmount;
        if (!canShield) { return; }

        shieldObject.SetActive(true);
        energy.ConsumeEnergy(energyCostToShield);
    }

    private void OnShieldStop()
    {
        shieldObject.SetActive(false);
    }

    private void OnFire()
    {
        bool canShoot = energyCostToShoot < energy.CurrentEnergyAmount;
        if (!canShoot) { return; }
            
        isShooting = true;
        energy.ConsumeEnergy(energyCostToShoot);
    }

    private void FixedUpdate()
    {
        RotateShip();
        PropelShip();
        Brake();
    }

    private void Update()
    {
        Fire();
    }

    private void RotateShip()
    {
        if (isRotating)
        {
            float rotationDir = playerControls.Flight.Rotate.ReadValue<float>();
            myRigidbody.AddTorque(rotationDir * turnSpeed);
        }

        if (myRigidbody.angularVelocity >= maxRotationSpeed)
        {
            myRigidbody.angularVelocity = maxRotationSpeed;
        }
        else if (myRigidbody.angularVelocity <= -maxRotationSpeed)
        {
            myRigidbody.angularVelocity = -maxRotationSpeed;
        }
    }

    private void PropelShip()
    {
        if (isMoving)
        {
            myRigidbody.AddRelativeForce(Vector2.up * propelSpeed);
        }
    }

    private void Brake()
    {
        if (isBraking)
        {
            float start = myRigidbody.drag;
            myRigidbody.drag = Mathf.Lerp(start, brakingDrag, 1);

            start = myRigidbody.angularDrag;
            myRigidbody.angularDrag = Mathf.Lerp(start, brakingDrag, 1);

        }
        else
        {
            myRigidbody.drag = 0f;
            myRigidbody.angularDrag = 0.05f;
        }
    }

    private void Fire()
    {
        if (isShooting && canShoot)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint);
            canShoot = false;
            isShooting = false;
            StartCoroutine(FiringCooldownRoutine());
        }
    }
   
    private IEnumerator FiringCooldownRoutine()
    {
        yield return new WaitForSeconds(projectileCooldown);
        canShoot = true;
    }
}
