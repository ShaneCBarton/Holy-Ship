using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] private Transform[] destinationPoints;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        int index = Random.Range(0, destinationPoints.Length);

        rb.AddRelativeForce(destinationPoints[index].forward);
    }
}
