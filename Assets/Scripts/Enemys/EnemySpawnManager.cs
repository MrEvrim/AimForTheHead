using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnManager : MonoBehaviour
{
    public Text spawnerScore;
    public GameObject WinScreen;
    private int totalSpawnPoints = 7;
    private int remainingSpawnPoints; 
    private int score = 0;
    private int killScore = 0;
    

    void Start()
    {
        remainingSpawnPoints = totalSpawnPoints;
    }
    public bool IsSpawnPointActive(GameObject spawnPoint)
    {
        return spawnPoint != null && spawnPoint.activeSelf;
    }
    public void AddScore(int value)
    {
        score -= value;
        if (score <= -70)
        {
            EndGame();
        }
    }
    public void KillAddScore(int value)
    {
        killScore += value;
       
    }
    void EndGame()
    {
      WinScreen.SetActive(true);
    }
    private void Update()
    {
        spawnerScore.text = killScore.ToString();
    }
}