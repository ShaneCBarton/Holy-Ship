using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Flight Variables")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float propelSpeed;
    [SerializeField] private float brakingDrag;
    [SerializeField] private GameObject burnerObject;
    [SerializeField] private GameObject smokeEffectObject;
    [SerializeField] private GameObject shieldObject;

    [Header("Projectile Variables")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileCooldown;

    [Header("Energy Requirements")]
    [SerializeField] private float energyCostToShoot;
    [SerializeField] private float energyCostToShield;
    [SerializeField] private float energyCostToBlink;

    [Header("Blink Ability Variables")]
    [SerializeField] private float blinkDistanceMultiplier;
    [SerializeField] private float blinkCooldown;
    [SerializeField] private float blinkPause;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject blinkEffectObject;

    enum CooldownType
    {
        Shoot,
        Blink
    }

    private PlayerControls playerControls;
    private Rigidbody2D myRigidbody;
    private Energy energy;

    private bool isRotating = false;
    private bool isMoving = false;
    private bool isBraking = false;
    private bool isShooting = false;
    private bool isBlinking = false;

    private bool canShoot = true;
    private bool canShield = true;
    private bool canBlink = true;

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
        playerControls.Combat.Blink.performed += _ => OnBlink();

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
        canShield = energyCostToShield <= energy.CurrentEnergyAmount;
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
        canShoot = energyCostToShoot <= energy.CurrentEnergyAmount;
        if (!canShoot) { return; }

        isShooting = true;
        energy.ConsumeEnergy(energyCostToShoot);
    }

    private void OnBlink()
    {
        canBlink = energyCostToBlink <= energy.CurrentEnergyAmount;
        if (!canBlink) { return; }

        isBlinking = true;
        energy.ConsumeEnergy(energyCostToBlink);
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
        Blink();
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
            StartCoroutine(CooldownRoutine(projectileCooldown, CooldownType.Shoot));
        }
    }

    private void Blink()
    {
        if (isBlinking && canBlink)
        {
            StartCoroutine(BlinkRoutine(blinkPause));
        }
    }

    public void Teleport()
    {
        Vector2 newPosition = myRigidbody.transform.up * blinkDistanceMultiplier;
        myRigidbody.position += newPosition;

        StartCoroutine(CooldownRoutine(blinkCooldown, CooldownType.Blink));
    }

    private IEnumerator BlinkRoutine(float teleportPauseTime)
    {
        canBlink = false;
        isBlinking = false;

        spriteRenderer.enabled = false;
        blinkEffectObject.SetActive(true);
        
        yield return new WaitForSeconds(teleportPauseTime);
        Teleport();
        yield return new WaitForSeconds(.25f);

        blinkEffectObject.SetActive(true);
        spriteRenderer.enabled = true;
    }

    private IEnumerator CooldownRoutine(float cooldownTime, CooldownType type)
    {
        yield return new WaitForSeconds(cooldownTime);

        switch (type)
        {
            case CooldownType.Shoot:
                canShoot = true;
                break;

            case CooldownType.Blink:
                canBlink = true;
                break;
        }
    }
}
