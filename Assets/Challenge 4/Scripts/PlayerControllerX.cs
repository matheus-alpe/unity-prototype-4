using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private readonly float speed = 500;
    private readonly float speeder = 1000;
    private GameObject focalPoint;

    public ParticleSystem smokeParticle;
    public GameObject smokeParticlePrefab;

    public bool hasPowerup;
    public bool canUseSpace = true;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private readonly float normalStrength = 10; // how hard to hit enemy without powerup
    private readonly float powerupStrength = 25; // how hard to hit enemy with powerup

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        GameObject smokeInstance = Instantiate(smokeParticlePrefab, transform.position + new Vector3(0.6f, 0.6f, 0), Quaternion.identity);


        smokeParticle = smokeInstance.GetComponent<ParticleSystem>();

    }

    void Update()
    {


        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");


        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        //sets smoke partical system position to beneath player.
        smokeParticle.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canUseSpace)
        {

            playerRb.AddForce(focalPoint.transform.forward * speeder * verticalInput);


            smokeParticle.Play();

            StartCoroutine(SpaceBarCooldown());
        }
        else
        {
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        }

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    // cool down for "space" bar
    IEnumerator SpaceBarCooldown()
    {

        canUseSpace = false;

        yield return new WaitForSeconds(1);

        canUseSpace = true;

    }
    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                playerRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                playerRb.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }

}
