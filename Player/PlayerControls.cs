using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody rb;

    public float shield= 3f;
    public float speed = 5f;
    public float dashSpeed = 5f;
    public GameObject basicProjectile;
    public ParticleSystem particleSystem;
    public AudioSource shootSound;
    public AudioSource teleport;
    public float fireRate = 5f;
    public float dashRate = 5f;
    public float timeBetweenDash;

    private float timeBetweenShots;


    private bool ifFired = false;
    private bool ifDashed = false;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeBetweenShots = fireRate;
        timeBetweenDash = dashRate;
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

    }


    void Update()
    {
        Move();   
        Shoot();       
        TimerCountdown();
        Dash();
    }

  

     void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movementAmount = horizontalInput * speed * Time.deltaTime;
        Vector3 movement = transform.right * movementAmount;
        transform.position += movement;
    }

    void Shoot() 
    {
        if (ifFired)
        {
            return; // Exit the method if already fired
        }

       if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(basicProjectile, transform.position + new Vector3(0, -1, 2), new Quaternion(0, 1, 1, 0));
            ifFired = true;
            shootSound.Play();
            Debug.Log(ifFired);
        }
    }

    void TimerCountdown()
    {
        if (timeBetweenShots > 0 && ifFired)
        {
            // Update the timer by subtracting the elapsed time
            timeBetweenShots -= Time.deltaTime;

            if (timeBetweenShots <= 0)
            {
                ifFired = false;
                timeBetweenShots = fireRate;
            }
        }

        if (timeBetweenDash > 0 && ifDashed)
        {
            // Update the timer by subtracting the elapsed time
            timeBetweenDash -= Time.deltaTime;

            if (timeBetweenDash <= 0)
            {
                ifDashed = false;
                timeBetweenDash = dashRate;
            }
        }
    }

    void Dash() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float dashAmount = horizontalInput * dashSpeed * Time.deltaTime;
        Vector3 dash = transform.right * dashAmount;


        if (ifDashed == false) 
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                PlayParticles();
                transform.position += dash;
                teleport.Play();
                ifDashed = true;                
            }
        }
    }

    void PlayParticles() 
    {

        ParticleSystem instantiatedParticleSystem = Instantiate(particleSystem, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        instantiatedParticleSystem.Play();
        if (timeBetweenDash < 0)
        {
            Destroy(instantiatedParticleSystem.gameObject);
        }
    }



}
