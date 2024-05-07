using UnityEngine;

public class SpawnRotation : MonoBehaviour
{
    [SerializeField] private float minTorque;
    [SerializeField] private float maxTorque;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float torqueAmount = Random.Range(minTorque, maxTorque);
        rb.AddTorque(torqueAmount);
    }
}
