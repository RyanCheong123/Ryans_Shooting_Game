using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float time = 1.0f;
    void Start()
    {
        Destroy(gameObject, time);
    }

}
