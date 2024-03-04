using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoSpawnTree : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject grid;
    public TilemapRenderer tilemapParent;


    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
    {
        int numberOfToSpawn = 25;
        for (int i = 0; i < numberOfToSpawn; i++)
        {
            int randomItem = Random.Range(0, spawnPool.Count);
            GameObject toSpawn = spawnPool[randomItem];

            // Lấy kích thước của lưới
            Vector3 gridSize = grid.GetComponent<Renderer>().bounds.size;

            // Tính toán vị trí ngẫu nhiên trong không gian của lưới
            float gridX = Random.Range((grid.transform.position.x - gridSize.x / 2) + 5f, (grid.transform.position.x + gridSize.x / 2) - 5f);
            float gridY = Random.Range((grid.transform.position.y - gridSize.y / 2) + 5f, (grid.transform.position.y + gridSize.y / 2) - 5f);
            Vector2 pos = new Vector2(gridX, gridY);
            GameObject tree = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            tree.transform.parent = tilemapParent.transform;
        }
    }
}
