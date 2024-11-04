using System.Collections; // Required for IEnumerator
using System.Collections.Generic; // Required for List
using TMPro; // Required for TextMeshProUGUI
using UnityEngine; // Required for MonoBehaviour
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen; // Added title screen GameObject
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) // Accept difficulty parameter
    {
        isGameActive = true;

        titleScreen.SetActive(false); // Deactivate the title screen

        spawnRate /= difficulty; // Adjust spawn rate based on difficulty

        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        scoreText.text = "Score: " + score;

    }
}

