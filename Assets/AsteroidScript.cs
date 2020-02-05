using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotation;
    public float minSpeed, maxSpeed;

    public GameObject asteroidExplosion;
    public GameObject shipExplosion;

    public void explode()
    {
        //Asteroid explosion

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

        //Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject); // Destroy asteroid
        GameControllerScript.getInstance().increaseScore(10);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set rotation
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation; //Random.insideUnitSphere - set random rotation
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    // Called when colliding with another object
    private void OnTriggerEnter(Collider other) // method colliders
    {
        if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "Asteroid")
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            //Ship explosion
            // other.gameObject.transform.position //Ship position

            Instantiate(shipExplosion, other.gameObject.transform.position, Quaternion.identity);

            GameControllerScript.getInstance().getGameOver();
            
            //GameControllerScript.getInstance().increaseScore(10);
        }
        else
            explode();

        Destroy(other.gameObject);

    }
}
