using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }
    void Update()
    {
        Vector3 v = startingPosition;
        v.z += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sobject")
        {
            explode();
        }

    }

    public void explode()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 5; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, 4f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(50f, transform.position, 4f, 0.4f);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {

        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(0.2f * x, 0.2f * y, 0.2f * z) - new Vector3(0.5f, 0.5f, 0.5f);
        piece.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 0.2f;
    }

}