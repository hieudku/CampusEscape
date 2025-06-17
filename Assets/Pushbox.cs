using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushableBox : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.transform.forward;
            rb.AddForce(pushDirection * 5f, ForceMode.Force);
        }
    }
}
