using UnityEngine;
using System.Linq;

public class CubeImageMapper : MonoBehaviour
{
    public int gridSize = 3; // 3x3 mur
    public Material sharedMaterial;

    void Start()
    {
        ApplyUVMapping();
    }

    void ApplyUVMapping()
    {
        // Récupérer les cubes et les trier par position (de gauche à droite, de haut en bas)
        Transform[] cubes = GetComponentsInChildren<Transform>()
            .Where(t => t != transform) // Exclure le parent
            .OrderByDescending(c => c.position.y) // Trier d'abord par hauteur (y décroissant)
            .ThenBy(c => c.position.x) // Puis par position horizontale (x croissant)
            .ToArray();

        float uvSize = 1f / gridSize; // Taille d'une portion d'image

        for (int i = 0; i < cubes.Length; i++)
        {
            int x = i % gridSize; // Colonne
            int y = i / gridSize; // Ligne

            Transform cube = cubes[i];
            cube.Rotate(0, -90, 0); // Appliquer la rotation

            Mesh mesh = cube.GetComponent<MeshFilter>().mesh;
            Vector2[] uvs = mesh.uv;

            float xOffset = x * uvSize;
            float yOffset = (gridSize - 1 - y) * uvSize; // Inverser Y pour correspondre à l'image

            // Modifier les UVs uniquement pour la face avant (indice 0,1,2,3)
            uvs[0] = new Vector2(xOffset, yOffset);
            uvs[1] = new Vector2(xOffset + uvSize, yOffset);
            uvs[2] = new Vector2(xOffset, yOffset + uvSize);
            uvs[3] = new Vector2(xOffset + uvSize, yOffset + uvSize);

            mesh.uv = uvs;
            cube.GetComponent<Renderer>().material = sharedMaterial;
        }
    }
}
