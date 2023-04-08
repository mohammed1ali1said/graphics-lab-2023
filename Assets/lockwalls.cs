using UnityEngine;

public class lockwalls : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        // Lock position to initial position
        transform.position = initialPosition;
    }
}
