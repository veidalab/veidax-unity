using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	private GameObject dudePrefab;

	private float difficultyMultiplier = 0.98f;
	private float spawnMinTimer = 2f;
	private float spawnMaxTimer = 4f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
		dudePrefab = (GameObject) Resources.Load("Dude");
	}
	
	IEnumerator SpawnEnemies() {
		while (true) {
			yield return new WaitForSeconds(Random.Range(spawnMinTimer, spawnMaxTimer));
			Instantiate(dudePrefab, SelectRandomPoint(),Quaternion.identity);

			//TODO: implement levels
			spawnMinTimer *= difficultyMultiplier;
			spawnMaxTimer *= difficultyMultiplier;
		}
	}

	Vector3 SelectRandomPoint() {
		Vector2 randomPoint = Random.insideUnitCircle * 1.5f;

		float x = randomPoint.x + transform.position.x;
		float y = 0.1f; //TODO: flying units;
		float z = randomPoint.y + transform.position.x;

		return new Vector3(x, y, z);
	}
}
