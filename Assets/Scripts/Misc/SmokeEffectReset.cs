using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEffectReset : MonoBehaviour
{
    private void ResetEffect()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
