using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Color playerColor;

    public GameObject pickupPrefab;

    public TextMeshProUGUI pointText;
    public GameObject winText;
    public GameObject gameoverText;
    public GameObject quitButton;
    public GameObject playagainButton;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    private int point;

    private Renderer renderer;
    public Color[] colors = { Color.red, Color.blue, Color.green };

    public PickupController pickUpController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomColor();
        point = 0;
        setPointText();
        Time.timeScale = 1;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setPointText()
    {
        pointText.text = "Point: " + point.ToString();
        if(point == 10)
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
            quitButton.gameObject.SetActive(true);
            playagainButton.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    
    void RandomColor()
    {
        renderer = GetComponent<Renderer>();
        Color randomColor = colors[Random.Range(0, colors.Length)];
        renderer.material.color = randomColor;
        playerColor = randomColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pick Up"))
        {
            if (other.gameObject.GetComponent<MeshRenderer>().material.color == playerColor )
            {
                //Destroy(other.gameObject);
                pickUpController.PickedUp(other.gameObject);
                RandomColor();
                point += 1;
                setPointText();
            }
            else
            {
                Debug.Log("GameOver");
                gameoverText.gameObject.SetActive(true);
                Time.timeScale = 0;
                quitButton.gameObject.SetActive(true);
                playagainButton.gameObject.SetActive(true);

            }
        }
    }
}