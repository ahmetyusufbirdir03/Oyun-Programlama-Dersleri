using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{   
    bool stopSpawn = false;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject[] bonusPrefabs;
    [SerializeField]
    GameObject enemyContainer;
    IEnumerator SpawnRoutine()
    { //* Random Enemy Generator Function
        yield return new WaitForSeconds(4.0f);
        while(!stopSpawn){
            Vector3 position = new Vector3(Random.Range(-9.4f,9.4f),9f,0);
            GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
            /* if(!GameObject.Find("Player")){
                 break;
             }*/
            //? This is a diffrent way which isnot prefered because ; GameObject.Find function causes system problems when its called too much

        }
    }
    IEnumerator SpawnBonusRoutine()
    { //* Random Bonus generator function 
        yield return new WaitForSeconds(4.0f);
        while(!stopSpawn){
            Vector3 position = new Vector3(Random.Range(-9.4f,9.4f),9f,0);
            Instantiate(bonusPrefabs[Random.Range(0,3)], position, Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawn = true;
    }

    public void Spawner()
    {   
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }

    void Start()
    {
        
    }

    void Update()
    {   
        
    }
}
