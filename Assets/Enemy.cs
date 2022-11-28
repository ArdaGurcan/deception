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

    Animator enemy_Animator;

    public float speed = 0.8f;
    Transform enemy;
    Transform player;
    private NavMeshAgent navComponent;
    private CapsuleCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.tag + " name: " + gameObject.name);
        enemy_Animator = gameObject.GetComponent<Animator>(); 
        collider = gameObject.GetComponent<CapsuleCollider>();

        enemy = gameObject.transform;
        // enemy.position = new Vector3(enemy.position.x, 0, enemy.position.z);

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
            transform.LookAt(gameObject.transform.up);
            if(collider == null) 
                Debug.Log("collider not found");
            Destroy(collider);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z);
            // navComponent.baseOffset = -0.1f;

        } else {
            navComponent.SetDestination(player.position);
            var step =  speed * Time.deltaTime; // calculate distance to move
            // transform.position = Vector3.MoveTowards(enemy.position, player.position, step);
            transform.LookAt(player.position + player.up * 1f);
        }
    }

    void Shoot() {
        if(gameObject != null) {
            GameObject bullet = Instantiate(bulletPrefab, enemy.position + enemy.up * 1f, enemy.rotation);
            bullet.GetComponent<Rigidbody>().velocity = enemy.forward * bulletSpeed;
        }
    }

}
