using UnityEngine;

public class Exploder : MonoBehaviour
{
    private SpawnCubesAtRandom spawnCubes;

    private void Start()
    {
        spawnCubes = FindObjectOfType<SpawnCubesAtRandom>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Aww, you got me");
            spawnCubes.enemies.RemoveAt(0);
            spawnCubes.enemiesCount--;
            gameObject.SetActive(false);
        }
    }
}