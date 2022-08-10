using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 v)
    {
        if (rb.velocity.sqrMagnitude > 0.001)
            return;
        rb.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
