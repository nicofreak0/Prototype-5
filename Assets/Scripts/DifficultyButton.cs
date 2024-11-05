using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //corrected to Button
    private Button button; 
    //added gameManager
    private GameManager gameManager; 
    //added difficulty variable
    public int difficulty; 

    //start is called before the first frame update
    void Start()
    {
        //corrected to Button
        button = GetComponent<Button>(); 
        //corrected method to find GameObject
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        //listener for button click
        button.onClick.AddListener(SetDifficulty); 
    }

    //update is called once per frame
    void Update()
    {
    }

    void SetDifficulty()
    {
        //pass difficulty to StartGame
        gameManager.StartGame(difficulty); 
    }
}