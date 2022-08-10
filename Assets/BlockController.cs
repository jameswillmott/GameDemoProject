using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    private Light light;
    private float intensity;

    [SerializeField]
    private float speed;

    IEnumerator Raise()
    {
        Vector3 y = transform.position;
        for(float t = 0; t < 1; t += Time.deltaTime / 2.0f)
        {
            var p = transform.position;
            transform.position = Vector3.Lerp(y - new Vector3(0, 1, 0), y,t);
            yield return null;
        }
    }

    void Start()
    {
        light = GetComponentInChildren<Light>();
        intensity = light.intensity;
        light.intensity = 0;

        StartCoroutine(Raise());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flash()
    {
        for(float i = intensity; i > 0; i -= Time.deltaTime * speed)
        {
            light.intensity = i;
            yield return null;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = Vector3.zero;
        collision.rigidbody.angularVelocity = Vector3.zero;
        collision.transform.position += collision.contacts[0].separation * collision.contacts[0].normal;
        StopAllCoroutines();
        StartCoroutine(Flash());
    }
}
