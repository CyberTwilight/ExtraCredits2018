using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour
{

    public bool discreteMovementInput;
    [Tooltip("If set to true, ship will slow down automatically")]
    public bool Auto_Break;

    public float forwardSpeed;
    public float breakProportion;
    public float turnSpeed;

    private Rigidbody2D rb2d;      


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;

        if (discreteMovementInput)
        {
            if (Input.GetAxis("Horizontal") > 0) moveHorizontal = 1;
            if (Input.GetAxis("Horizontal") < 0) moveHorizontal = -1;
            if (Input.GetAxis("Vertical") > 0) moveVertical = 1;
            if (Input.GetAxis("Vertical") < 0) moveVertical = -1;

        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

        //left and right inputs rotate the ship
        this.transform.Rotate(new Vector3(0, 0, -turnSpeed * moveHorizontal));

        if (moveVertical > 0)
        {
            rb2d.AddRelativeForce(Vector3.up * moveVertical * forwardSpeed);
            Debug.Log(Vector3.forward * moveVertical * forwardSpeed);
        }
        
        else if (moveVertical < 0 || (Auto_Break & moveVertical <= 0)) rb2d.velocity = rb2d.velocity * (1 - breakProportion);
    }

}