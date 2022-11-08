using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float speedRotate;
    public Camera camera;
    public float life;
    public Text txtLife;
    public Rigidbody rb;
    private bool inFloor = false;

    // Start is called before the first frame update
    void Start()
    {
        txtLife.text = "Vidas: " + life;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, speedRotate, 0.0f);
        }
        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -speedRotate, 0.0f);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(inFloor)
            {
                rb.AddForce(new Vector3(0.0f, 7.0f, 0.0f), ForceMode.Impulse);
            }
            
        }
        /*if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f, 0.0f, speed);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0.0f, 0.0f, -speed);
        }*/
        transform.position += transform.forward * speed;
        camera.transform.position = transform.position + new Vector3(0.0f, 1.2f, -1.0f);
        camera.transform.rotation = transform.rotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Colidiu");
            transform.position = new Vector3(0.0f, 0.6f, -4.5f);
            life--;
            txtLife.text = "Vidas: " + life;
            if (life == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if(collision.gameObject.tag == "Floor")
        {
            inFloor = true;
        }
        
    }
}
