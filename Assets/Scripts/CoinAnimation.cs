using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating the coing in the y direction to have a spinning animation
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
