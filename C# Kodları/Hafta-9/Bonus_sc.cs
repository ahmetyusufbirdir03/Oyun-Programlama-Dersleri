using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    int speed = 3;
    [SerializeField]
    int bonus_id = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement(){
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if(transform.position.y < -5.8f){
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        Player_sc player = other.GetComponent<Player_sc>();
        if(player != null){
            if(other.tag == "Player"){
                switch(bonus_id){
                    case 0:
                        player.ActivateTripleShot();
                        break;
                    case 1:
                        player.ActivateSpeedBonus();
                        break;
                    case 2:
                        player.ActivateShieldBonus();
                        break;
                    default:
                        Debug.Log("default value");
                        break;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
