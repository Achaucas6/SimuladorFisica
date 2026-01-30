using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 5f;
    public float gravity = 9.8f;
    public float mouseSensitiveX = 10f;
    public float mouseSensitiveY = 10f;
    public float maxAxisX = 45f;
    [Header("RaycastConfig")]
    public float rayMaxDistance = 10f;
    public LayerMask interactableLayer;

    private float xRotation;
    private Transform mainCamera;
    private CharacterController controller;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        xRotation = 0f;
    }


    // Update is called once per frame
    void Update()
    {

        Raycast();

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        //Movimiento camara en eje y
        this.transform.Rotate(new Vector3(0f, mouseX * mouseSensitiveX * Time.deltaTime, 0f));

        xRotation += mouseY * mouseSensitiveY * Time.deltaTime;

        //Movimiento camar en eje X
        xRotation = Mathf.Clamp(xRotation, -maxAxisX, maxAxisX);


        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Calcular dirección del movimiento
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Mover al jugador
        controller.Move(move * speed * Time.deltaTime);

        // Aplicar gravedad
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // mantiene el jugador pegado al suelo
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
        ControllSensitivity();
    }
    void Raycast()
    {
        bool bhit;
        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * rayMaxDistance, Color.green);
        bhit = Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hitInfo, rayMaxDistance, interactableLayer);
        if (Input.GetMouseButtonDown(0) && bhit)
        {
            Button button = hitInfo.collider.GetComponentInParent<Button>();
            Debug.Log("Se toco y presiono: "+hitInfo.collider.gameObject.name);
            if (button != null)
            {
                ButtonFunction(button);
            }
        }

    }
    void ControllSensitivity()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mouseSensitiveX -= 5.0f;
            mouseSensitiveX = Mathf.Max(1f, mouseSensitiveX);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            mouseSensitiveX += 5.0f;
        }

    }
    void ButtonFunction(Button button)
    {
        button.onClick.Invoke();
        Debug.Log("button clicked: " + button.name);
    }
}