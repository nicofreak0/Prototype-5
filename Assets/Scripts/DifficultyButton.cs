using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button; // Corrected to Button
    private GameManager gameManager; // Added gameManager
    public int difficulty; // Added difficulty variable

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); // Corrected to Button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Corrected method to find GameObject
        button.onClick.AddListener(SetDifficulty); // Add listener for button click
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty); // Pass difficulty to StartGame
    }
}