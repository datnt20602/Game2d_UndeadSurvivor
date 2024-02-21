using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawnTree : MonoBehaviour
{
	public int numberToSpawn;
	public List<GameObject> spawnPool;
	public GameObject grid; 


	// Start is called before the first frame update
	void Start()
	{
		spawnObjects();
	}

	public void spawnObjects()
	{
		int numberOfToSpawn = Random.Range(30, 40+1);

		for (int i = 0; i < numberOfToSpawn; i++)
		{
			int randomItem = Random.Range(0, spawnPool.Count);
			GameObject toSpawn = spawnPool[randomItem];

			// Lấy kích thước của lưới
			Vector3 gridSize = grid.GetComponent<Renderer>().bounds.size;

			// Tính toán vị trí ngẫu nhiên trong không gian của lưới
			float gridX = Random.Range(grid.transform.position.x - gridSize.x / 2, grid.transform.position.x + gridSize.x / 2);
			float gridY = Random.Range(grid.transform.position.y - gridSize.y / 2, grid.transform.position.y + gridSize.y / 2);

			Vector2 pos = new Vector2(gridX, gridY);

			Instantiate(toSpawn, pos, toSpawn.transform.rotation);
		}
	}
}
