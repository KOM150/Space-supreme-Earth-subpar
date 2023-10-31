using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    // for dragging objects
    public Ray ray;
    RaycastHit hit;
    public Vector2 pos;

    public float speed = 13.0f;
    public float tilt;
    public Done_Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;



    void Update()
    {
        bool buttonFire = false;

        if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        {
            buttonFire = true;
        }

        if (buttonFire && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Quaternion angle = Quaternion.Euler(new Vector3(0, 15.0f, 0));
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation * angle);
            angle = Quaternion.Euler(new Vector3(0, -15.0f, 0));
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation * angle);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");
        float distance_per_frame = speed * Time.deltaTime;

        transform.Translate(Vector3.right * horizontal_input * distance_per_frame); //Player ¿Ãµø
        transform.Translate(Vector3.forward/*Z√‡*/ * vertical_input * distance_per_frame);

        /*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		*/
    }
}
