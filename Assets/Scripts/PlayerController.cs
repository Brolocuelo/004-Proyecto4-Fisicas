using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] powerupIndicators;

    public float speed = 30f;
    private float forwardInput;

    private Rigidbody _rigidbody;
    private GameObject focalPoint;

    public bool hasPowerUp, hasPowerUp2;
    private float powerupForce = 15f;

    private float originalScale = 1.5f;
    private float powerupScale = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
        if(other.gameObject.CompareTag("PowerUp_2"))
        {
            hasPowerUp2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce,
             ForceMode.Impulse);
            StartCoroutine(PowerupCountDown());
        }
    }

    private IEnumerator PowerupCountDown()
    {
        if (hasPowerUp2)
        {
            transform.localScale = powerupScale * Vector3.one;
        }
        for(int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(true);
        }
        if (hasPowerUp2)
        {
            transform.localScale = originalScale * Vector3.one;
        }

        hasPowerUp = false;
        hasPowerUp2 = false;
    }

    private void Gameover()
    {
        //Time.Stop;
    }
}
