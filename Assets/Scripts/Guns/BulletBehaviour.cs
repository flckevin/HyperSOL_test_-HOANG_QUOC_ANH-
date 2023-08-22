using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //store speed
        float moveSpeed = 5f;
        //move bullet up
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
