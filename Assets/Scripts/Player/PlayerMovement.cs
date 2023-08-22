using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0,50)]
    public float shipSpeed = 5.0f; // ship speed

    void Start()
    {
        //disable multi touch
        Input.multiTouchEnabled = false;
    }


    void Update()
    {
        //if player touched or move their fingers
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //geet their finger position
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            //move the ship to their fingre position
            this.transform.Translate(Vector3.MoveTowards(this.transform.position, target, shipSpeed * Time.deltaTime) - this.transform.position);

        }
    }
}

