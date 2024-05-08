using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] private float minForce, maxForce;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PropelAsteroid(Transform targetPoint)
    {
        float forceMultiplier = Random.Range(minForce, maxForce);
        rb.AddForce((targetPoint.position - transform.position) * forceMultiplier, ForceMode2D.Impulse);
    }
}
