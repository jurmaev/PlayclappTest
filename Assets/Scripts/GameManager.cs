using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject stopButton;
    [SerializeField] private TMP_InputField speedText;
    [SerializeField] private TMP_InputField distanceText;
    [SerializeField] private TMP_InputField timeText;
    [SerializeField] private SpawnManager spawnManager;

    public void StartSpawning()
    {
        if (int.TryParse(speedText.text, out var speed) && int.TryParse(distanceText.text, out var distance) &&
            float.TryParse(timeText.text, out var time))
        {
            spawnManager.StartSpawn();
            spawnManager.CubeDistance = distance;
            spawnManager.CubeSpeed = speed;
            spawnManager.WaitTime = time;
            startButton.SetActive(false);
            stopButton.SetActive(true);
        }
    }

    public void StopSpawning()
    {
        spawnManager.StopSpawn();
        stopButton.SetActive(false);
        startButton.SetActive(true);
    }
}