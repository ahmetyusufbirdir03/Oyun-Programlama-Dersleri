using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{   
    bool stopSpawn = false;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject enemyContainer;
    IEnumerator SpawnRoutine(){ //* Random Enemy Generator Function
        while(!stopSpawn){
            Vector3 position = new Vector3(Random.Range(-9.4f,9.4f),7.4f,0);
            GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
            /* if(!GameObject.Find("Player")){
                 break;
             }*/
            //? This is a diffrent way which isnot prefered because ; GameObject.Find function causes system problems when its called too much

        }
    }
    public void OnPlayerDeath(){
        stopSpawn = true;
    }
    void Start()
    {
        StartCoroutine("SpawnRoutine");
        //! StartCoroutine("SpawnRoutine"); non prefered way because of the mistake that the coder can make while writing the name of routine function */
    }

    void Update()
    {   
        
    }
}
