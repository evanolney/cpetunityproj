using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed; //Player speed

    private Rigidbody2D rbd2; //rigid body component for using physics

    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal input values
        float moveVertical = Input.GetAxis("Vertical"); //Vertical input values

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rbd2.AddForce(movement * speed);
    }
}
