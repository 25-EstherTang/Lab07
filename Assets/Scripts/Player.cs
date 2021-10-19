using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    Rigidbody PlayerRB;

    public Text scoreText;

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

        if (transform.position.y < -3)
        {
            SceneManager.LoadScene("GameOver");
        }

        else if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            GameManager.Score++;
            scoreText.GetComponent<Text>().text = "SCORE: " + GameManager.Score;
        }
    }

}
