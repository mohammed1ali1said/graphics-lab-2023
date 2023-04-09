using UnityEngine;

public class cameramovment : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public float maxYAngle = 80.0f;
    public float minYAngle = -80.0f;

    private float mouseX, mouseY;
    private Vector2 currentRotation;

    void Start()
    {
        currentRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        currentRotation.x += mouseY;
        currentRotation.y += mouseX;

        currentRotation.x = Mathf.Clamp(currentRotation.x, minYAngle, maxYAngle);

        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
    }

}
