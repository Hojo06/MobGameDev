using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float rotSpeed = 10f;
    public float incrementSize = 0.1f;
    public float maxSize = 5f;
    public Vector3 startSize;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        startSize = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.one * rotSpeed * Time.deltaTime);
        if(Input.anyKeyDown) {
            rend.material.color = Random.ColorHSV();
            this.transform.localScale += Vector3.one * incrementSize;
            if(this.transform.localScale.x > maxSize) {
                this.transform.localScale = Vector3.one * 3;
            }
        }
    }
}
