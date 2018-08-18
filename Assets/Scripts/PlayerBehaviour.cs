using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


    public GameObject WinText;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Death")
        {
            Debug.Log("Dead");
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        if (collision.collider.tag == "Finish")
        {
            Debug.Log("You Win!");
            WinText.SetActive(true);
            Time.timeScale = 0.0f;  
        }

    }
}
