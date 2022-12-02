using UnityEngine;

public class ManobroActivate : MonoBehaviour
{
    private Animator myAnimator;

    private ManoBroController myMano;

    [SerializeField] private GameObject manoBro;


    private void Awake()

    {
        myMano = manoBro.GetComponent<ManoBroController>();
        myAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && RoomControllerFinalDoor.Instance.GetEnemiesCount() == 0)
        {
            myAnimator.SetTrigger("exit");
            myMano.CanSpawn();
        }
    }
}