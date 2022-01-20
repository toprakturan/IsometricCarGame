using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private float gameSessionTimer;
    public GameObject player;

    private void Awake()
    {
        gameSessionTimer = 0;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
        gameSessionTimer += Time.deltaTime; //Session timer.
        int seconds = Mathf.RoundToInt(gameSessionTimer % 60f); //Seconds
        int minutes = Mathf.RoundToInt(gameSessionTimer / 60f); //Minutes
        if (player.GetComponent<Player>().isGameOver)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}
