using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle  : MonoBehaviour
{
    public float strength = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody otherRB = collision.rigidbody;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * strength/2, ForceMode.Force);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * strength, ForceMode.VelocityChange);

            Destroy(gameObject);
        }
    }
}
