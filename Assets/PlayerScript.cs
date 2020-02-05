using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float tilt;

    public float xMin, xMax, zMin, zMax;

    public GameObject LazerShot; //Prefab shot
    public Transform LazerGun; //Position gun

    public float shotDelay; //Delay between shots
    private float nextShot; //time next shot

    //public void explodeAllAsteroids()
    //{
    //    GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    //    foreach (GameObject asteroid in asteroids)
    //    {
    //        //Destroy(asteroid); 
    //        asteroid.GetComponent<AsteroidScript>().explode();
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.getInstance().getIsSterted()) //if game not started
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //float index = 1.5f;

        Rigidbody Ship = GetComponent<Rigidbody>();

        Ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; // velocity > speed

        Ship.rotation = Quaternion.Euler(moveVertical * tilt/1.5f, 0, -moveHorizontal * tilt); // rotation(tilt)

        float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(Ship.position.z, zMin, zMax);

        Ship.position = new Vector3(xPosition, 0, zPosition);


        //Shots
        //if (Time.time > nextShot && Input.GetButton("Fire1")) // Button mause1
        //if (Time.time > nextShot) // All time shots
        if (Time.time > nextShot && Input.GetKey(KeyCode.Space)) // Key Space - Shots
        {
            Instantiate(LazerShot, LazerGun.position, Quaternion.identity);
            nextShot = Time.time + shotDelay; // next shot
        }
        //Instantiate(LazerShot, LazerGun.position, Quaternion.identity);

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            //explodeAllAsteroids();
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject asteroid in asteroids)
            {
                //Destroy(asteroid); 
                asteroid.GetComponent<AsteroidScript>().explode();
            }
        }
    }
}
