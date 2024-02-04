using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Vector3 checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.transform.position = checkpoint;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            health = maxHealth;
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }
}
