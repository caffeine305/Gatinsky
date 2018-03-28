using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

	public GameObject enemy;
	public Vector2 spawnValues;
	public int enemyCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start () {
		StartCoroutine (SpawnEnemies ());
	}

	IEnumerator SpawnEnemies ()	{
		yield return new WaitForSeconds (startWait);

		while(true){ //Por lo pronto está bien True. Mas adelante habrá que cambiarlo por while(lives > 0) y tal.
			for (int i = 0; i < enemyCount; i++) {
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}
