using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;
    Player_sc player;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null){
            Debug.Log("Anim is null");
        }
        player = GameObject.Find("Player").GetComponent<Player_sc>();
    }

    // Update is called once per frame
    void Update()
    {   
        CalculateMovement();
        
    }

    void CalculateMovement(){

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -5.4f){
            int minValue = -9;  
            int maxValue = 9; 
            float random = Random.Range(minValue,maxValue);
            transform.position = new Vector3(random,7.5f,0);
        }
        /* 
        --alternative way--
        float movement = Time.deltaTime * speed;
        transform.Translate(new Vector3(0, -movement, 0) );
        */
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player.Damage();
            anim.SetTrigger("OnEnemyDeath");
            this.speed = 0;
            Destroy(this.gameObject, 2.0f);
        }
        else if(other.tag == "Laser"){
            //? Always destroy the object of script which you are coding
            //* So.. destroy laser first then destroy enemy
            Destroy(other.gameObject);
            
            if(player != null)
            {
                player.UpdateScore(10); 
            }
            anim.SetTrigger("OnEnemyDeath");
            this.speed = 0;
            Destroy(this.gameObject,2.0f);
        }
    }
}
