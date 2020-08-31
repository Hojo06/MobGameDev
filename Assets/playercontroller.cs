using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// adds a rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class playercontroller : MonoBehaviour
{
    [Range(5,100)]
    public float jumpSpeed = 100f;
    [Range(5,100)]
    public float fallSpeed = 100f;
    [Range(5,50)]
    public float forwardSpeed = 10f;

    float tapTimer = 0f;

    public float doubleTapInterval = 0.2f;

    bool tapped = false;

    Rigidbody rb;
    bool isGrounded = false;

    public int score = 0;
    TextMeshPro scoreText;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Controller Starting Up!");

        rb = this.GetComponent<Rigidbody>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time since last frame = " + Time.deltaTime);

        if(Input.anyKeyDown) Jump();


    }

    //FixedUpdate is for physics, it runs 50 times / second.
    void FixedUpdate() {
        Debug.Log("Fixed Update frame time =" +Time.deltaTime);

        // adding forward force
        rb.AddRelativeForce(Vector3.right * forwardSpeed);

        if(isGrounded == false) {
            rb.AddRelativeForce(Vector3.down * 5);
        }
    }

    void Jump() {
        if(isGrounded) {
            rb.AddRelativeForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void DoubleTap () {
        Debug.Log("<color=cyan>Double Tap!</color>");
        Debug.Log("Timer = " + tapTimer);
        tapTimer = 0;
    }


    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
        else if(other.gameObject.CompareTag("Pickup")) {
            score += 1000;
            scoreText.text = "Score = " + score;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Finish")) {

            score = 0;
            this.transform.position = startPosition;
            Application.LoadLevel(0);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
