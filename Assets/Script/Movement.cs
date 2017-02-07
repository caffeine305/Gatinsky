using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float gravity = 9.8f;
    public bool onGround;
    public bool isJumping;

    void Start(){
        onGround = true;
        isJumping = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        onGround = true;
        isJumping = false;
    }

    void FixedUpdate() {


        float vel = Input.GetAxis("Horizontal") * moveSpeed; 
        transform.Translate(Vector2.right * vel * Time.deltaTime);

        if (Input.GetButton("Fire1")){

            if ((onGround == true) && (isJumping == false))
            {
                transform.Translate(Vector2.up * gravity * Time.deltaTime);
                isJumping = true;
                onGround = false;
            }
        }
    }


}