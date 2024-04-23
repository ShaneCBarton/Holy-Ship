using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [Range(1f, 5f)][SerializeField] private float scrollSpeed;
    [SerializeField] private float scrollHeight = 12f;

    private GameObject background1, background2;
    private Vector2 startPosition;

    private void Start()
    {
        background1 = transform.GetChild(0).gameObject;
        background2 = transform.GetChild(1).gameObject;

        startPosition = background2.transform.position;
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        background1.transform.Translate(0, scrollSpeed * Time.deltaTime, 0);
        background2.transform.Translate(0, scrollSpeed * Time.deltaTime, 0);

        if (background1.transform.position.y > scrollHeight)
        {
            background1.transform.position = startPosition;
        }
        else if (background2.transform.position.y > scrollHeight)
        {
            background2.transform.position = startPosition;
        }
    }
}
