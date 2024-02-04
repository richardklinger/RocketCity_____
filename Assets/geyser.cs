using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geyser : MonoBehaviour
{
    public float changeY = 10f;
    public float force = 5f;
    private GameObject player;
    private Rigidbody2D rb;
    private float moveTime;
    //time it takes to go up
    public float upTime;
    //time holds in the air
    public float holdTime;
    private float goalY;
    private int stage;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        goalY = transform.position.y + changeY;
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        moveTime = 0;
        stage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //moveTime helps as a failsafe and works with hold time
        moveTime += Time.deltaTime;
        float x = transform.position.x;
        float y = transform.position.y;

        if (stage == 0)
        {
            Vector2 nextPos = new Vector2(x, y + (Time.deltaTime * (changeY / upTime)));
            if (Mathf.Abs(nextPos.y - goalY) < 0.01 || moveTime > upTime)
            {
                nextPos.y = goalY;
                transform.position = nextPos;
                moveTime = 0;
                stage = 1;
                //Debug.Log("nextPos: " + nextPos.y);
            }
            else
            {
                transform.position = nextPos;
            }
        }
        else if (stage == 1 && moveTime >= holdTime)
        {
            stage = 2;
            moveTime = 0;
        }
        else if (stage == 2)
        {
            Vector2 nextPos = new Vector2(x, y - (Time.deltaTime * (changeY / upTime)));
            if (Mathf.Abs(nextPos.y - startY) < 0.01 || moveTime > upTime)
            {
                nextPos.y = startY;
                transform.position = nextPos;
                moveTime = 0;
                stage = 0;
            }
            else
            {
                transform.position = nextPos;
            }
        }

        //accounts for player mass in case we change it
        //rb.AddForce(new Vector2(force * rb.mass, 0), ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, force * rb.mass), ForceMode2D.Impulse);
        }
    }
}
