﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public bool onGround;
    public bool isJumping;

    void Start(){
        moveSpeed = 10.0f;
        onGround = true;
        isJumping = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "Ground")
        {
            onGround = true;
            isJumping = false;
        }
    }

    void FixedUpdate() {

        float velx = Input.GetAxis("Horizontal") * moveSpeed;

        transform.Translate(Vector2.right * velx * Time.deltaTime);

        if (Input.GetButton("Fire1")){

            if ((onGround == true) && (isJumping == false))
            {
                onGround = false;
                isJumping = true;
            }
        }

        if (isJumping == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, moveSpeed), ForceMode2D.Impulse); // ¡ESTA ES UNA FORMA MUY TÉCNICA!
            isJumping = false;
        }
    }


}