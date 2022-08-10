using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    public static int PickUps = 0;

    // Start is called before the first frame update
    void Start()
    {
        PickUps++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);    
    }
    private void OnDestroy()
    {
        PickUps--;
        if (PickUps == 0)
            SceneManager.LoadScene("Gameover");
    }
}
