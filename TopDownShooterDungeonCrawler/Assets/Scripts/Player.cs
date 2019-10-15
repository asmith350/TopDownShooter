using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    GlobalFunctions gf = new GlobalFunctions();

    Rigidbody2D rb;

    Weapon weapon;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float moveSpeed = 20.0f;    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        weapon = FindObjectOfType<Weapon>();
    }
	
	// Update is called once per frame
	void Update () {
        // Get Player Input
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 left
        vertical = Input.GetAxisRaw("Vertical"); // -1 down

        // Get Mouse Position
        LookAtMouse();

        if (Input.GetButtonDown("Fire1")) {
            weapon.Shoot();
        }
    }

    private void FixedUpdate()
    {
        // Check for diagonal movement
        if (horizontal != 0 && vertical != 0) {
            // limit move speed diagonally, so player moves at moveLimiter% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
   

    void LookAtMouse()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = gf.AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) + 90f;

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
