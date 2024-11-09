using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    int speed = 3;
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
                player.ActivateTripleShot();
                Destroy(this.gameObject);
            }
        }
    }
}
