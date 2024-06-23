using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float rotate;
    public float jump;
    public Rigidbody rigidBody;
    public int score;

    public float boost;
    private float boostTimer;
    private bool boosting;




    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        speed = 5;
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        float trans = Input.GetAxis("Vertical") * speed;
        float playerRotate = Input.GetAxis("Horizontal") * rotate;

        playerRotate *= Time.deltaTime;
        trans *= Time.deltaTime;

        transform.Translate(0, 0, trans);
        transform.Rotate(0, playerRotate, 0);

        if (Input.GetButton("Jump"))
        {
            rigidBody.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }

        if (boosting)
        {
            boostTimer *= Time.deltaTime;

            if (boostTimer >= 3.0f)
            {
                speed = 5;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            speed = 15;
            Destroy(other.gameObject);
        }
    }
}
