using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Components
    private GameObject player;
    [SerializeField] private Rigidbody2D prb;

    // Mechanics
    private float impulse;
    private float angle;
    private float aVelocity;
    private float mVelocity;
    private float thrust;

    // Stats
    [SerializeField] private float accel = 100f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float maxTurnSpeed = 120;
    [SerializeField] private float smoothTime = 0.2f; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        prb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        
    }

    private void FixedUpdate() {
        Thrust();
    }

    private float PlayerToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.up, direction);
        return targetAngle;
    }

    private void RotatePlayer()
    {
        float targetAngle = PlayerToMouse();
        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref aVelocity, smoothTime, maxTurnSpeed);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Thrust()
    {
        if(Input.GetButton("Impulse")){
            impulse = Input.GetAxis("Impulse");
            if(impulse<0){
                impulse /= 2;
            }
            prb.AddForce(transform.up * accel * Time.deltaTime * impulse);
            prb.velocity = Vector2.ClampMagnitude(prb.velocity, maxSpeed);
            
        }
    }
}
