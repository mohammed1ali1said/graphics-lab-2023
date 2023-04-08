using UnityEngine;

public class playermovment : MonoBehaviour
{
    public float speed = 2.5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

        transform.Translate(movement, Space.Self);
    }
}
