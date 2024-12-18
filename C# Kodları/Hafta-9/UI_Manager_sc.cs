using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_sc : MonoBehaviour
{
    [SerializeField] GameManager_sc gameManager;
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI gameOverTMP;
    [SerializeField] TextMeshProUGUI restartTMP;

    [SerializeField] Sprite [] livesSprites;

    [SerializeField] Image livesImg;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_sc>();
        if(gameManager == null)
        {
            Debug.Log("GameManager could not be created");
        }
        scoreTMP.text = "Score: " + 0;
        livesImg.sprite = livesSprites[3];
        gameOverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
    public void UpdateScoreTMP(int score){
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLivesImg(int lives)
    {
        livesImg.sprite = livesSprites[lives];
       
        if (lives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        if(gameManager != null)
        {
            gameManager.GameOver();
        }

        gameOverTMP.gameObject.SetActive(true);
        restartTMP.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
      while(true)
      {
        gameOverTMP.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameOverTMP.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
      }  
    }
}
