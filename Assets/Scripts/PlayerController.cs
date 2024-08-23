using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] SurfaceEffector2D surfaceEffector;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    bool canMove = true;
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableMove()
    {
        canMove = false;
    }
    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }
}
