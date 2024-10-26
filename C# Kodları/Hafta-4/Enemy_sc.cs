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
    void Start()
    {
        
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

    void OnTriggerEnter(Collider other){
        Player_sc player = other.GetComponent<Player_sc>();
        if(other.tag == "Player"){
            player.Damage();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser"){
            //? Always destroy the object of script which you are coding
            //* So.. destroy laser first then destroy enemy
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
