using UnityEngine;

public class HasWeaponUI : MonoBehaviour
{
    [SerializeField] private GameObject gunSprite;
    [SerializeField] private PlayerMovement myPlayer;

    private void Update()
    {
        if (!myPlayer.PlayerHasGun())
        {
            gunSprite.SetActive(false);
        }
        else
        {
            gunSprite.SetActive(true);
        }
    }
}