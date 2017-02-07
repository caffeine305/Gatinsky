using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public static bool onGround;

    void onCollisionEnter(Collision2D col)
        {
        if (col.gameObject.name == "Ground")
            onGround = true;
        else
            onGround = false;
        }

    }
