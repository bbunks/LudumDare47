using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblesController : MonoBehaviour
{
    public float rotationSpeed = 250f;
    private float angle, turnSmoothVelocity, turnSmooth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float targetAngle = transform.rotation.y * Mathf.Rad2Deg + rotationSpeed * Time.deltaTime;
        // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y * Mathf.Rad2Deg, targetAngle, ref turnSmoothVelocity, turnSmooth);
        angle += Time.deltaTime*rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
