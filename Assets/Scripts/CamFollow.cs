using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public bool shouldFollow = true;
    public float yOffset = 0;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFollow)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, gameObject.transform.position.z);
        }
    }
}
