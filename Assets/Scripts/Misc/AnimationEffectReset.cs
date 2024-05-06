using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffectReset : MonoBehaviour
{
    [SerializeField] private bool hasParent;

    private void ResetEffect()
    {
        if (hasParent)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
    }
}
