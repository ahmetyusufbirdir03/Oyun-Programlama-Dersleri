using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    public int playerHealth = 3;
    public float speed = 5;
    float speedMultiplier = 2;
    public float horizontal;
    public float vertical;
    float fireRate = 0.5f;
    float nextFire = 0f;
    [SerializeField]
    bool isTripleShotActive = false;
    [SerializeField]
    bool isShieldBonusActive = false;
    [SerializeField]
    bool isSpeedBonusActive = false;
    public GameObject laserPrefab;
    SpawnManager_sc spawnManager_sc;
    public GameObject tripleShotPrefab;
    [SerializeField]
    GameObject shieldVisualizer;
    
    void Start()
    {
        spawnManager_sc =GameObject.Find("Spawn_Manager").GetComponent<SpawnManager_sc>();
        if(spawnManager_sc == null){
            Debug.Log("Spawn_Manager could not be find");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Fire();
    }
    void Fire(){
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {   
            if(!isTripleShotActive){
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }else{
                Instantiate(tripleShotPrefab, transform.position + new Vector3(-0.9536626f, 1.269109f, 0), Quaternion.identity);
            }
            
            nextFire = Time.time + fireRate;
        }  
    }

    void CalculateMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed);
    }

    public void Damage(){
        if(!isShieldBonusActive)
            this.playerHealth--;
        else{
            isShieldBonusActive = false;
            shieldVisualizer.SetActive(false);
            }

        if(playerHealth == 0){
            if(spawnManager_sc != null)
                spawnManager_sc.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
    
    public void ActivateTripleShot(){
        isTripleShotActive = true;
        StartCoroutine(TripleShotBonusDisableRoutine());
    }
    public void ActivateSpeedBonus(){
        isSpeedBonusActive = true;
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusDisableRoutine());
    }
    public void ActivateShieldBonus(){
        isShieldBonusActive = true;
        shieldVisualizer.SetActive(true);
        StartCoroutine(ShieldBonusDisableRoutine());
    }

    IEnumerator TripleShotBonusDisableRoutine(){
        
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
    IEnumerator SpeedBonusDisableRoutine(){
        
        yield return new WaitForSeconds(5.0f);
        speed /= speedMultiplier;
        isSpeedBonusActive = false;
    }
    IEnumerator ShieldBonusDisableRoutine(){
        yield return new WaitForSeconds(10.0f);
        shieldVisualizer.SetActive(false);
        isShieldBonusActive = false;
    }
    
}
