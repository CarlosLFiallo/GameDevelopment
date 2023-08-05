using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Reflection;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    private PlayerControls player;
    private PowerCube cube;
    private Vector3 direction;



    void Start()
    {
        GameObject playerManager = GameObject.Find("Player");
        player = playerManager.GetComponent<PlayerControls>();
        direction = new Vector3(0, 0, 1);       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("PlayerProjectile")) 
        {
            transform.position += direction * speed * Time.deltaTime;
        }
   
    }


    void OnTriggerEnter(Collider other)
    {
        EnemyHealth health = other.gameObject.GetComponent<EnemyHealth>();   
        cube = other.gameObject.GetComponent<PowerCube>();
        if (other.gameObject.CompareTag("enemy"))
        {
            health.TakeDamage(damage);
            Debug.Log("Collision With Enemy");
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("BasicDrop") || other.gameObject.CompareTag("RareDrop") || other.gameObject.CompareTag("LegendaryDrop"))
        {
            player.fireRate -= cube.fireRatePower;
            player.speed += cube.speedPower;
            player.dashRate -= cube.dashRatePower;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }      

    }
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }



}
