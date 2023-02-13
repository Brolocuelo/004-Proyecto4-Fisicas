using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 10f;
    private float yMin = 5f;

    private Rigidbody _rigidbody;
    private GameObject player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // Calculo de la direccion enemigo -> player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        // Aplicar la fuerza al enemigo
        _rigidbody.AddForce(direction * speed);

        if(transform.position.y < -yMin)
        {
            Destroy(gameObject);
        }
    }
}
