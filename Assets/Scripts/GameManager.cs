using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    private int score;
    private bool isFirstEnter = true;
    private void Awake()
    { 
        Application.targetFrameRate = 60;
        Pause();    
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        getReady.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i=0;i<pipes.Length;i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        SetImage();
        Time.timeScale = 0f;
        player.enabled = false;
    }
    private void SetImage()
    {
        getReady.SetActive(isFirstEnter);
        gameOver.SetActive(!isFirstEnter);
    }
    public void GameOver()
    {
        isFirstEnter = false;
        SetImage();
        playButton.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
