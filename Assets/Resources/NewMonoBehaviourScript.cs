using UnityEngine;
using Oculus.Interaction;

public class RaySpawnCube : MonoBehaviour
{
    public GameObject cubePrefab; // Le prefab du cube
   

    private void Start()
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Cube Prefab non assigné !");
        }
    }

    // Fonction déclenchée quand l'interaction est détectée
    public void OnRaySelect()
    {
        if (cubePrefab != null)
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
            Debug.Log("Cube apparu !");
        }
    }
}
