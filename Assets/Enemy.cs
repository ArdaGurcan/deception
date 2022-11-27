using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform mainCamera;

    [SerializeField]
    float bulletSpeed = 10f;

    public float speed = 0.8f;
    Transform enemy;
    Transform player;
    private NavMeshAgent navComponent;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform;
        enemy.position = new Vector3(enemy.position.x, enemy.position.y, 0f);
        player = GameObject.Find("PlayerCapsule").transform;
        navComponent = gameObject.GetComponent<NavMeshAgent>();

        InvokeRepeating("Shoot", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player);
        navComponent.SetDestination(player.position);
        

        var step =  speed * Time.deltaTime; // calculate distance to move
        // transform.position = Vector3.MoveTowards(enemy.position, player.position, step);
        transform.LookAt(player.position + player.up * 1f);
    }

    void Shoot() {
        if(gameObject != null) {
            GameObject bullet = Instantiate(bulletPrefab, enemy.position + enemy.up * 0.3f, enemy.rotation);
            bullet.GetComponent<Rigidbody>().velocity = enemy.forward * bulletSpeed;
        }
    }
}
