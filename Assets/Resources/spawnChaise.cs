using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;  // Le prefab du cube que vous voulez instancier
    public int numberOfCubes = 5;  // Nombre de cubes à instancier
    public Transform spawnPoint;   // Point de spawn pour les cubes

    private void Update()
    {
        Debug.Log("vivant");
    }
    // Fonction pour instancier des cubes
    public void SpawnCubes()
    {
        Debug.Log("ici");
        for (int i = 0; i < numberOfCubes; i++)
        {
            // Position aléatoire autour du point de spawn
            Vector3 randomOffset = new Vector3(
                Random.Range(-2f, 2f),
                Random.Range(1f, 3f),
                Random.Range(-2f, 2f)
            );

            // Instancier les cubes à la position spécifiée
            Instantiate(cubePrefab, spawnPoint.position + randomOffset, Quaternion.identity);
        }
    }
}
