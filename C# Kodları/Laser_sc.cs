using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        if(transform.position.y > Camera.main.orthographicSize){
            Destroy(this.gameObject);   
        }
    }
}
