using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour
{
    [Tooltip("Forma alternativa de pegar inputs que, independente da \"força\" utilizada, sempre dá velocidade 1 ou -1 em cada direção")]
    public bool discreteMovementInput;
    [Tooltip("If set to true, ship will slow down automatically")]
    public bool Auto_Break;

    [Tooltip("Velocidade da nave")]public float forwardSpeed;
    [Tooltip("Velocidade de freio da nave")] public float breakProportion;
    [Tooltip("Velocidade com que a nave gira ao apertar A ou D")]public float turnSpeed;

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
        }
        
        else if (moveVertical < 0 || (Auto_Break & moveVertical <= 0)) rb2d.velocity = rb2d.velocity * (1 - breakProportion);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
    }
}