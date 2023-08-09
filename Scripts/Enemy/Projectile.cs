using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    private Vector3 direction;
    public AudioSource hitSound;
    public AudioSource playerHitSound;

    private MeshRenderer meshRenderer;
    private Collider collider;
    private Rigidbody rigidbody;



    void Start()
    {
        direction = new Vector3(0, 0, -1);
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += direction * speed * Time.deltaTime;       
    }

 
    void OnCollisionEnter(Collision collision)
    {
        BaseHealth baseHealth = collision.gameObject.GetComponent<BaseHealth>();

        if (collision.gameObject.CompareTag("Player"))
        {
            PlaySoundAndDestroy(playerHitSound);
            Debug.Log("Collision With Player");           
        } 
        else if (collision.gameObject.CompareTag("Base")) 
        {
            PlaySoundAndDestroy(hitSound);
            baseHealth.TakeDamage(damage);            
        }
    }
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    private void PlaySoundAndDestroy(AudioSource audio)
    {
        if (hitSound != null && !hitSound.isPlaying)
        {
            audio.Play();

            // Disable the mesh renderer and collider components and rigidbody
            meshRenderer.enabled = false;
            collider.enabled = false;
            Destroy(rigidbody);

            StartCoroutine(DestroyComponentsAfterDelay(1f)); // 1 second delay before destroying the entire GameObject
        }
    }
    private IEnumerator DestroyComponentsAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Wait for an additional 1 second before destroying the entire GameObject
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
 


}
