using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool gameRunning;
	
	private ScoreController scoreController;
	private Spawner enemySpawnSpawner;
	
	// Use this for initialization
	void Start () {
		scoreController = FindObjectOfType(typeof(ScoreController)) as ScoreController;
		enemySpawnSpawner = FindObjectOfType(typeof(Spawner)) as Spawner;
		Init ();
	}
	
	void Init() {
		scoreController.Init();
		enemySpawnSpawner.Spawn();
		Cursor.visible = false;
	}

	void CleanUp() {
		Cursor.visible = true;
		StopSpawners();
		DisableScoring();
		RemoveEnemies();
		ScoreController.RecordScore( scoreController.GetScore() );
	}
	
	void EnterMainMenu() {
		Application.LoadLevel("MainMenu");
	}

	public void GameOver() {
		CleanUp();
		EnterMainMenu();
	}
	
	private void RemoveEnemies() {
		Enemy[] enemies = FindObjectsOfType(typeof(Enemy)) as Enemy[];
		foreach( Enemy enemy in enemies ) {
			Destroy ( enemy.gameObject );
		}
	}
	
	private void DisableScoring() {
		scoreController.Disable();
	}
	
	private void StopSpawners() {
		Spawner[] spawners = FindObjectsOfType( typeof( Spawner )) as Spawner[];
		foreach( Spawner spawner in spawners ){
			spawner.Disable();
		}
	
	}
}
