using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    InputManager mgr;


    // Start is called before the first frame update
    void Start()
    {
        mgr = GameObject.Find("InputManager").GetComponent<InputManager>();
    }


    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
            mgr.UpdateScore(1000);
        }
        Destroy(this.gameObject);
    }
}
