using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Rigidbody bullet;
    public float bulletSpeed = 50f;
    Transform emitter;


    // Start is called before the first frame update
    void Start()
    {
        emitter = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        Rigidbody rb = Instantiate(bullet, emitter.position, emitter.rotation);
        rb.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(rb.gameObject, 2);
    }
}
