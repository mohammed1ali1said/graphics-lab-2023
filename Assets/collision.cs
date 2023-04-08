using System.Collections;
using UnityEngine;

public class collision : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackTime = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") && !gameObject.CompareTag("Wall"))
        {
            // Calculate knockback direction
            Vector3 knockbackDir = (collision.contacts[0].point - transform.position).normalized;

            // Disable character movement for knockbackTime seconds
            rb.velocity = Vector3.zero;
            StartCoroutine(DisableMovement(knockbackTime));

            // Apply knockback force to character
            rb.AddForce(-knockbackDir * knockbackForce, ForceMode.Impulse);
        }
    }

    IEnumerator DisableMovement(float time)
    {
        // Disable character movement
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

        // Wait for specified time
        yield return new WaitForSeconds(time);

        // Enable character movement
        rb.constraints = RigidbodyConstraints.None;
    }
}
