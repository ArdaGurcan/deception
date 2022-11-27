using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    // Start is called before the first frame update
    public int numEnemy = 3;
    Transform player;
    public List<GameObject> enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = new List<GameObject>();
        // int walkable = 1 << NavMesh.GetAreaFromName("Spawnable");
        for(int i = 0; i < numEnemy; i++) {
            NavMeshHit hit;
            // set positoin to random position on NavMesh
            if(NavMesh.SamplePosition(GeneratedPosition(), out hit, Mathf.Infinity, NavMesh.AllAreas)) {
                GameObject e = Instantiate(enemyPrefab, hit.position, player.rotation);
                enemy.Add(e);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        Vector3 GeneratedPosition()
        {
            float x, y, z;
            x = Random.Range(10, 20) * Mathf.Pow(-1, Random.Range(0,1));
            y = Random.Range(0,20);
            z = Random.Range(5, 10);
            return new Vector3(x, y, z);
        }

}
