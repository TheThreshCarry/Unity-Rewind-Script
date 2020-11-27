using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Explosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public float lift = 30;
    public float speed = 10;
    public bool explode = false;
    void FixedUpdate()
    {
        if (explode)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, lift);
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            explode = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            explode = false;
        }
    }
}