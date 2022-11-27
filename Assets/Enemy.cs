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

    Animator enemy_Animator;

    public float speed = 0.8f;
    Transform enemy;
    Transform player;
    private NavMeshAgent navComponent;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.tag + " name: " + gameObject.name);
        enemy_Animator = gameObject.GetComponent<Animator>(); 

        enemy = gameObject.transform;
        // enemy.position = new Vector3(enemy.position.x, enemy.position.y, 0f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = gameObject.GetComponent<NavMeshAgent>();
        InvokeRepeating("Shoot", 5f, 5f);
        // Debug.Log("end of start() enemy position y" + enemy.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_Animator.GetCurrentAnimatorStateInfo(0).IsName("Death (2)")) {
            CancelInvoke();
            navComponent.velocity = Vector3.zero;
            navComponent.isStopped = true;
        }
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
