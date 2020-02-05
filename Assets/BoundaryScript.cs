using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        //when another object (other) leaves the borders of the collider
        Destroy(other.gameObject);

    }
}
