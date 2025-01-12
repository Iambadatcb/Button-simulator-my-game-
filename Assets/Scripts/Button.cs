using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private PlayerStatGain player;
    public TextMesh cash;
    public TextMesh multi;
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter3D(Collider collision)
    {
        Debug.Log("Collision detected");
         if(collision.gameObject.CompareTag("Player") && player.cash>=Convert.ToInt32(cash.text))
        {
            Debug.Log("Colllided with player.");
            if(player.cash>=Convert.ToInt32(cash.text)){

            player.multi = player.multi + Convert.ToInt32(multi.text);
            player.cash = player.cash - Convert.ToInt32(cash.text);
            Debug.Log("Player's multiplier increased. New multiplier: " + player.multi);
            Debug.Log("Player's cash decreased. New cash: " + player.cash);
            }
            else{
                Debug.Log("Not enough cash to increase multiplier.");
                }
        }
    }
}
