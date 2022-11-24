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
    float bulletSpeed = 5f;

    public float speed = 0.8f;
    Transform enemy;
    Transform player;
    private NavMeshAgent navComponent;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform;
        enemy.position = new Vector3(enemy.position.x, enemy.position.y, 0f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = gameObject.GetComponent<NavMeshAgent>();

        InvokeRepeating("Shoot", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        navComponent.SetDestination(player.position);

        var step =  speed * Time.deltaTime; // calculate distance to move
        // transform.position = Vector3.MoveTowards(enemy.position, player.position, step);
        transform.LookAt(player.position + player.up * 1f);
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, enemy.position + enemy.up * 0.3f, enemy.rotation);
        bullet.GetComponent<Rigidbody>().velocity = enemy.forward * bulletSpeed;
    }
}
