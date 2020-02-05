using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.getInstance().getIsSterted()) //if game not started
        {
            return;
        }

            //Time.time 
        float newZPosition = Mathf.Repeat(Time.time * speed, 100); //loop plane
        transform.position = startPosition + Vector3.back * newZPosition;
    }
}
