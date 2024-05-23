using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Arreglo de prefabs de obst�culos
    public float[] spawnTimes; // Arreglo de tiempos de generaci�n
    public bool[] spawnPointsToggle; // Arreglo de booleanos para elegir el punto de generaci�n
    public Transform spawnPoint1; // Primer punto de generaci�n
    public Transform spawnPoint2; // Segundo punto de generaci�n

    void Start()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            StartCoroutine(SpawnObstacle(i));
        }
    }

    IEnumerator SpawnObstacle(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimes[index]);
            Transform spawnPoint = spawnPointsToggle[index] ? spawnPoint1 : spawnPoint2;
            GameObject obstacle = Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity);
            Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();
            if (obstacleScript != null)
            {
                obstacleScript.moveUp = spawnPointsToggle[index];
            }
        }
    }
}
