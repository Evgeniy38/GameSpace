using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;

    public float minDelay, maxDelay; //time between launches asteroids

    private float nextLaunch; //time next launch

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.getInstance().getIsSterted()) //if game not started
        {
            return;
        }
        /*
         if (Random.Range(0,3) == 1 //swich?
         {
         start asteroid 1...q
         }
         */

        if (Time.time > nextLaunch)
        {
            float xPos = Random.Range(-transform.localScale.x/2, transform.localScale.x / 2);
            float yPos = transform.position.y;
            float zPos = transform.position.z;

            Instantiate(asteroid, new Vector3(xPos, yPos, zPos),Quaternion.identity);
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
