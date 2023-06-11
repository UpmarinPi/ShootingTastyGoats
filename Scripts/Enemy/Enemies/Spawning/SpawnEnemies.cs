using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [System.Serializable]
    public class InfoEnemy
    {
        public GameObject enemyPrefab;
        public int time;
        public Vector2 spawnCoords = new Vector2(0,32);
    }
    [SerializeField] List<InfoEnemy> infoEnemies = new List<InfoEnemy>();
    void Start()
    {
        
    }

    void Update()
    {

    }
}
