using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject TopBody;
    [SerializeField]
    GameObject BottomBody;
    [SerializeField]
    Animator topAnimator;
    [SerializeField]
    Animator bottomAnimator;


    float speed = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        var topRotation = TopBody.transform.rotation.eulerAngles;
        var bottomRotation = BottomBody.transform.rotation.eulerAngles;

        bool isFiring = false;
        bool isMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isMoving = true;
            pos.x += speed * Time.deltaTime;
            bottomRotation.z = 90;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            isMoving = true;
            pos.x -= speed * Time.deltaTime;
            bottomRotation.z = 270;
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            isMoving = true;
            pos.y += speed * Time.deltaTime;
            bottomRotation.z = 180;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            isMoving = true;
            pos.y -= speed * Time.deltaTime;
            bottomRotation.z = 0;
        }

        if (Input.GetAxisRaw("Fire-Horizontal") > 0)
        {
            isFiring = true;
            topRotation.z = 90;
        }
        if (Input.GetAxisRaw("Fire-Horizontal") < 0)
        {
            isFiring = true;
            topRotation.z = 270;
        }
        if (Input.GetAxisRaw("Fire-Vertical") > 0)
        {
            isFiring = true;
            topRotation.z = 180;
        }
        if (Input.GetAxisRaw("Fire-Vertical") < 0)
        {
            isFiring = true;
            topRotation.z = 0;
        }

        transform.position = pos;
        BottomBody.transform.rotation = Quaternion.Euler(bottomRotation);
        if (isFiring)
        {
            topAnimator.ResetTrigger("Idle");
            topAnimator.SetTrigger("Fire");
            TopBody.transform.rotation = Quaternion.Euler(topRotation);
        }
        else
        {
            topAnimator.ResetTrigger("Fire");
            topAnimator.SetTrigger("Idle");
            TopBody.transform.rotation = Quaternion.Euler(bottomRotation);
        }

        if (isMoving)
        {
            bottomAnimator.ResetTrigger("Idle");
            bottomAnimator.SetTrigger("Walk");
        }
        else
        {
            bottomAnimator.ResetTrigger("Walk");
            bottomAnimator.SetTrigger("Idle");
        }
    }
}
