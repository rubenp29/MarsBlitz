using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Catch : MonoBehaviour
{
    //Inputs
    private PlayerInput playerInput;
    private PlayerMovement playerMove;
    private WeaponComponentens weaponComp;

    // Components
    [SerializeField] private TextMeshProUGUI pickupText;
    [SerializeField] private GameObject weaponPosition;
    [SerializeField] private GameObject player;

    // text inputs
    private bool pickUpAllowed = false;
    private bool eKeyboard = false; // player input


    private void Start()
    {
        weaponComp = GetComponent<WeaponComponentens>();
        playerMove = player.GetComponent<PlayerMovement>();
        pickupText.gameObject.SetActive(false);
        playerInput = InputManager.Instance.GetInputActions();
    }

    private void Update()
    {
        Pickup();
    }


    // Grab weapon
    private void Pickup()
    {
        eKeyboard = playerInput.player.pickUp.triggered;
        if (eKeyboard && pickUpAllowed == true)
        {
            gameObject.transform.parent = weaponPosition.transform;
            gameObject.transform.position = weaponPosition.transform.position;

            Destroy(pickupText);
            playerMove.HasGun();
            weaponComp.HasPlayer();
        }
    }

    //Triggers for the text
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Artur"))
        {
            pickupText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Artur"))
        {
            pickupText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
}