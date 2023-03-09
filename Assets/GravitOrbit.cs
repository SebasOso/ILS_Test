using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitOrbit : MonoBehaviour
{
    public float gravity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravitControl>())
        {
            other.GetComponent<GravitControl>().gravity = this.GetComponent<GravitOrbit>();
        }
    }
}
