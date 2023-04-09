using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public float spawnRadius = 1.0f;
    public float minY = 0.0f;
    public float maxY = 1.0f;
    public float horizontalSpeed = 0.0f;
    public float spawnDelay = 0.2f;
    public GameObject plane;
    public TextMeshProUGUI respawnCounterText;
    public TextMeshProUGUI timeText;
    private float spawnTime;
    private float deathTime;

    private bool movingRight = true;
    private Vector3 originalPosition;
    private bool isDead = false;
    public static float  respawnCounter = 0;
    public static float avgTimeForResults;

    void Start()
    {
        originalPosition = transform.position;
      
    }

    void Update()
    {
        respawnCounterText.text = "hits: " + respawnCounter;
        if (isDead)
        {
            return;
        }

        float moveDirection = movingRight ? 1.0f : -1.0f;
        transform.position += new Vector3(moveDirection * horizontalSpeed * Time.deltaTime, 0.0f, 0.0f);

        if (transform.position.x > originalPosition.x + spawnRadius)
        {
            movingRight = false;
        }
        else if (transform.position.x < originalPosition.x - spawnRadius)
        {
            movingRight = true;
        }
    }

    public void TakeDamage(float amount)
    {
        Target.respawnCounter++;
               respawnCounterText.text = "hits: " + respawnCounter;
       
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        deathTime = Time.time;
        if (isDead)
        {
            return;
        }

        isDead = true;

        


        // Destroy the current object after a delay
        Destroy(gameObject, spawnDelay);

        // Create a new empty game object
        GameObject newTarget = new GameObject("Target");

        // Copy the position and rotation of the current object to the new object
        newTarget.transform.position = transform.position;
        newTarget.transform.rotation = transform.rotation;

        // Get the renderer of the current object
        Renderer renderer = GetComponent<Renderer>();

        // Instantiate a copy of the current object as a child of the new game object
        GameObject targetObject = Instantiate(gameObject, Vector3.zero, Quaternion.identity, newTarget.transform);

        // Set the scale and rotation of the new target to match the current target
        targetObject.transform.localScale = transform.localScale;
        targetObject.transform.rotation = transform.rotation;

        // Generate a random position within the plane's bounds
        float x = Random.Range(plane.transform.position.x - plane.transform.localScale.x / 2, plane.transform.position.x + plane.transform.localScale.x / 2);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(plane.transform.position.z - plane.transform.localScale.z / 2, plane.transform.position.z + plane.transform.localScale.z);

        // Set the position of the new target to the random position within the plane's bounds
        targetObject.transform.position = new Vector3(x, y, z);

        // Get the Target component of the new target and set its properties
        Target target = targetObject.GetComponent<Target>();
        target.health = 30.0f;
        target.spawnRadius = spawnRadius;
        target.minY = minY;
        target.maxY = maxY;
        target.horizontalSpeed = horizontalSpeed;
        target.respawnCounterText = respawnCounterText;

        // Set the material of the new target to match the current target
        avgTimeForResults = ((deathTime - spawnTime) / respawnCounter);
        timeText.text = "AVG time " + avgTimeForResults.ToString("F2");
        targetObject.GetComponent<Renderer>().material = renderer.material;
        spawnTime = Time.time;
    }
}
