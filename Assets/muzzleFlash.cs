using UnityEngine;
using System.Collections;

public class muzzleFlash : MonoBehaviour
{

    public GameObject flashObject;
    public float flashDuration = 0.1f;

    // Use this for initialization
    void Start()
    {
        flashObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash()
    {
        flashObject.SetActive(true);
        yield return new WaitForSeconds(flashDuration);
        flashObject.SetActive(false);
    }
}
