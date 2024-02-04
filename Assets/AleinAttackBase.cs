using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using UnityEngine.InputSystem;

public class AleinAttackBase : MonoBehaviour
{
    [SerializeField] private float gameTime = 60f;
    [SerializeField] private TMP_Text clock = null;
    [SerializeField] private GameObject Enemies = null;
    
    private int shields = 2;

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        // UpdateLevelTimer(gameTime);

        if(Enemies.transform.childCount <= 0)
        {
            Debug.Log("Game End - you win!");
        }
       
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (pos);
        

        if (Input.GetMouseButtonUp(0))
        {         
            RaycastHit2D hit=Physics2D.Raycast(pos, Vector2.zero, 0f);
            
            if (hit)
            {
                hit.transform.gameObject.GetComponent<Enemy>().On_hit();
            }
            
        }


    }

    public void get_hit()
    {
        if (shields <= 0)
        {
            Debug.Log("Game over"); 
        }
        else
        {
            shields--;
        }
    }

    // public void UpdateLevelTimer(float totalSeconds)
    // {
    //     int minutes = Mathf.FloorToInt(totalSeconds / 60f);
    //     int seconds = Mathf.RoundToInt(totalSeconds % 60f);
 
    //     string formatedSeconds = seconds.ToString();
 
    //     if (seconds == 60)
    //     {
    //         seconds = 0;
    //         minutes += 1;
    //     }
 
    //     clock.text = minutes.ToString("00") + ":" + seconds.ToString("00");
 
    //     if (totalSeconds <= 0f)
    //     {
    //         Debug.Log("Game over");
    //     }
 
    // }
}
