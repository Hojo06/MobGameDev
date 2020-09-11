using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{

    public TextMeshProUGUI debugText;
    public TextMeshProUGUI scoreText;
    public Slider powerSlider;
    public bool phoneIsAttached = true;
    public Transform bulletSpawn;
    [Tooltip("This is your gun barrel, or your tank.")]
    public Transform gun;
    public Rigidbody2D bullet;
    public GameObject enemyPrefab;
    public float minPower = 50f, maxPower = 200;[Tooltip("The X and Y min and max spawn position for enemies.")]

    public Vector2 min, max;

    public int score = 0;


    public float timer = 0;
    public bool mouseIsDown= false;

    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "Input Mgr Connected!";
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(phoneIsAttached) {
            if(Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                debugText.text = "Pressed! Timer = " + timer;
                timer += Time.deltaTime * 50;
                powerSlider.value = timer;

                if(touch.phase == TouchPhase.Ended) {
                    debugText.text = "Timer = " + timer;
                }
            }

        }
        else {
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                debugText.text = "You are clicking the screen!";
                mouseIsDown = true;
            }
            if(Input.GetKeyUp(KeyCode.Mouse0)) {
                mouseIsDown = false;
                debugText.text = "Timer = " + timer;
                Shoot();
            }
            if(mouseIsDown) {
                timer += Time.deltaTime * 50;
                debugText.text = "Clicked! Timer = " + timer;

                powerSlider.value = timer;
            }
        }
    }


    public void Shoot() {
        if(timer > maxPower) timer = maxPower;
        debugText.text = "Pow! Power = " + timer.ToString("0.0");

        Rigidbody2D rb = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        rb.AddRelativeForce(Vector2.up * 10 * timer);

        timer = minPower;
        powerSlider.value = timer;
    }

    public void UpdateScore(int givenScore) {
        score += givenScore;
        scoreText.text = "Score: " + score.ToString();
    }

    public void RotateGun(int dir) {
        gun.transform.Rotate(0, 0, dir * 5);
    }

    public void SpawnEnemy(){
        // the for loop has the counter built in.
        int totalEnemies = Random.Range(4, 9);
        for(int i = 0; i < totalEnemies; i += 1){
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        }
    }
}
