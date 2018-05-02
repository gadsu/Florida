using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraV2 : MonoBehaviour {

    private const float Y_ANGLE_MIN = 10.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;

    private HeadlineManager hm;

    private float distance = 3.75f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 2.0f;

    private bool controller = false;
    private bool nope = false;

    private void Start()
    {
        camTransform = transform;
        hm = GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>();

        checkController();
    }

    private void Update()
    {
        if (hm.headlines["The Nuclear Option"].Unlocked)
        {
            StartCoroutine("Wait");
        }
        if (nope != true)
        {
            if (!GameObject.Find("HeadlineManager").GetComponent<HeadlineManager>().headlineMenu.activeInHierarchy)
            {
                if (controller)
                {
                    currentX += Input.GetAxis("Right X") * sensitivityX;
                    currentY += Input.GetAxis("Right Y") * sensitivityY;
                }
                else
                {
                    currentX += Input.GetAxis("Mouse X");
                    currentY += Input.GetAxis("Mouse Y");
                }
            }

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    }

    private void LateUpdate()
    {
        if (nope != true)
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position + new Vector3(0, 1.5f, 0));
        }
    }

    private void checkController()
    {
        string[] names = Input.GetJoystickNames();
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Length > 0)
            {
                controller = true;
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        nope = true;
    }
}
