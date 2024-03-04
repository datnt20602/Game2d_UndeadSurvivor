using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject _enemyPrefab;

	private List<GameObject> enemies = new List<GameObject>();

	public int initialWaveSize = 10; // Số lượng quái vật ban đầu trong mỗi wave
	public int additionalWaveSize = 5; // Số lượng quái vật được thêm vào mỗi wave sau khi tiêu diệt hết
	public float timeBetweenWaves = 3.0f; // Thời gian giữa các wave

	private bool spawningEnemies = true;

	private void Start()
	{
		// Bắt đầu coroutine để sinh quái vật
		StartCoroutine(SpawnEnemies());
	}


	private IEnumerator SpawnEnemies()
	{
		while (spawningEnemies)
		{
			// Sinh quái vật trong wave hiện tại
			for (int i = 0; i < initialWaveSize; i++)
			{
				SpawnEnemy();
				yield return new WaitForSeconds(0.5f); // Đợi 0.5 giây trước khi sinh quái vật tiếp theo
			}

			// Đợi cho đến khi tất cả quái vật bị tiêu diệt
			yield return new WaitWhile(() => enemies.Count > 0);

			// Sau khi tất cả quái vật bị tiêu diệt, tăng kích thước wave lên
			initialWaveSize += additionalWaveSize;

			// Đợi thời gian giữa các wave
			yield return new WaitForSeconds(timeBetweenWaves);
		}
	}


	private void SpawnEnemy()
	{
		GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
		enemies.Add(newEnemy); // Thêm quái vật mới vào danh sách

		EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();
		EnermyController enermyController = newEnemy.GetComponent<EnermyController>();
		if (enermyController != null)
		{
			// Nếu đối tượng quái vật có component EnemyMovement
			// Gán phương thức OnDestroyEnemy vào sự kiện OnDestroyed của EnemyMovement
			enermyController.OnDestroyed += OnDestroyEnemy;
		}
		else
		{
			// Nếu không tìm thấy component EnemyMovement trên đối tượng quái vật
			// Ghi log lỗi để thông báo
			Debug.LogError("Không tìm thấy thành phần EnemyMovement trên đối tượng quái vật!");
		}
	}

	public void OnDestroyEnemy(GameObject enemy)
	{
		enemies.Remove(enemy); // Xóa quái vật khỏi danh sách khi bị tiêu diệt
	}
}