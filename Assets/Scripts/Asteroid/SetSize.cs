using UnityEngine;

public class SetSize : MonoBehaviour
{
    [SerializeField] private float minScale = 1;
    [SerializeField] private float maxScale;

    private void Start()
    {
        float scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector2(scale, scale);
    }
}
