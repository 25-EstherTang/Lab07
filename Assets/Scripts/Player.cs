using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    Rigidbody PlayerRB;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        PlayerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        thisAnimation.Play();

    }
}
