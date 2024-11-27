using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatGain : MonoBehaviour
{
    [Header("Stats")]
     public float cash = 0;
     public float multi = 1;
     private Collider collision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StatGain();
    }
    void FixedUpdate(){
        OnCollisionEnter3D();
    }
    void OnCollisionEnter3D()
    {
        Debug.Log("Collision");
        if(collision.gameObject.CompareTag("MultiButton1")){
            Debug.Log("Collided with button");
            if(cash>=100){
                cash-=100;
                multi++;
                StatGain();
                Debug.Log("Cash decreased. New cash: "+cash);
                Debug.Log("Multi increased. New multi: "+multi);
            }
            else
            {
                Debug.Log("Not enough cash to increase multiplier");
            }
        }
    }
    public void StatGain()
     {
        if(multi>0)
        {
            cash += 1*multi*Time.deltaTime;
            
        }
     }
}
