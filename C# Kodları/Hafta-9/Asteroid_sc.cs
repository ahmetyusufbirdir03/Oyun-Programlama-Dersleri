using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_sc : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20.0f;

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] SpawnManager_sc spawnManager;
    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        if(spawnManager != null)
        {
            spawnManager.Spawner();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime);
    }
    
    public void OnTriggerEnter2D(Collider2D other){
        if( other.tag == "Laser"){
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            spawnManager.Spawner();
            Destroy(this.gameObject);

        }
    }
}
