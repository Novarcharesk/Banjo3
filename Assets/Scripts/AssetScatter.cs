using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterPrefabsOnTerrain : MonoBehaviour
{
    public GameObject prefabToScatter;  // The prefab to scatter
    public int numberOfPrefabs = 50;     // Number of prefabs to scatter
    public Vector3 scatterArea = new Vector3(10f, 0f, 10f);  // Size of the scattering area
    public float maxHeight = 10f;        // Maximum height above the terrain

    private Terrain terrain;             // Reference to the terrain
    private MeshCollider terrainCollider;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        terrainCollider = terrain.GetComponent<MeshCollider>();

        StartCoroutine(ScatterPrefabs());
    }

    IEnumerator ScatterPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            float posx = Random.Range(-scatterArea.x, scatterArea.x) + transform.position.x;
            float posz = Random.Range(-scatterArea.z, scatterArea.z) + transform.position.z;

            Ray ray = new Ray(new Vector3(posx, maxHeight + transform.position.y, posz), Vector3.down);
            RaycastHit hit;

            if (terrainCollider.Raycast(ray, out hit, 2.0f * maxHeight))
            {
                Vector3 spawnPosition = hit.point;
                Instantiate(prefabToScatter, spawnPosition, Quaternion.identity);
            }

            // Add a yield to prevent instantiating all objects in a single frame.
            yield return null;
        }
    }
}
