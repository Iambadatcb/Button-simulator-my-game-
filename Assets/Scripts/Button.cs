using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private PlayerStatGain player;
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter3D(Collider collision)
    {
        Debug.Log("Collision detected");
         if(collision.gameObject.CompareTag("Player") && player.cash>=100)
        {
            Debug.Log("Colllided with player.");
            if(player.cash>=100){

            player.multi = player.multi + 1;
            player.cash = player.cash - 100;
            Debug.Log("Player's multiplier increased. New multiplier: " + player.multi);
            Debug.Log("Player's cash decreased. New cash: " + player.cash);
            }
            else{
                Debug.Log("Not enough cash to increase multiplier.");
                }
        }
    }
}
