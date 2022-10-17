using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    private int cubeSpeed;
    private int cubeDistance;
    private float waitTime;
    private IEnumerator coroutine;

    public int CubeSpeed
    {
        set => cubeSpeed = value;
    }

    public int CubeDistance
    {
        set => cubeDistance = value;
    }

    public float WaitTime
    {
        set => waitTime = value;
    }

    public void StartSpawn()
    {
        coroutine = SpawnCube();
        StartCoroutine(coroutine);
    }

    public void StopSpawn()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator SpawnCube()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            var cube = Instantiate(cubePrefab, transform.position, Quaternion.identity).GetComponent<Cube>();
            cube.Speed = cubeSpeed;
            cube.Distance = cubeDistance;
        }
    }
}