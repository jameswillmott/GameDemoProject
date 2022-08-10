#if UNITY_ANDROID
#define MOBILE
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MobileController : MonoBehaviour
{
    public PlayerController playerController;
    public UIBehaviour mobile;

    public float speed = 5;

#if MOBILE
    public bool touched = false;
    public Vector3 touchPosition;
    public Vector2 touchDirection;
#endif

    // Start is called before the first frame update
    void Start()
    {
#if MOBILE
        //Nothing to do here!
#else
        Destroy(mobile.transform.gameObject);
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if MOBILE
        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {
            var t = touches[0];
            switch (t.phase)
            {
                case TouchPhase.Began:
                    touched = true;
                    touchPosition = t.position;
                    break;
                case TouchPhase.Ended:
                    touched = false;
                    touchDirection = Vector2.zero;
                    break;
                case TouchPhase.Moved:
                    touchDirection = t.deltaPosition;
                    break;
            }
        }

        if(touchDirection.magnitude > 10)
        {
            float xmag = touchDirection.x;
            float ymag = touchDirection.y;
            if (Mathf.Abs(xmag) > Mathf.Abs(ymag))
            {
                playerController.SetVelocity(new Vector3(Mathf.Sign(xmag) * speed, 0, 0));
            }
            else
            {
                playerController.SetVelocity(new Vector3(0,0, Mathf.Sign(ymag) * speed));
            }
        }
#else
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerController.SetVelocity(Vector3.right * speed);
            return;
        }
       
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerController.SetVelocity(Vector3.right * -speed);
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerController.SetVelocity(Vector3.forward * speed);
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerController.SetVelocity(Vector3.forward * -speed);
            return;
        }
#endif
    }
}
