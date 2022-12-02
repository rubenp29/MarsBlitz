using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(dialogueSequence());
        }

        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);

                if (i == 6)
                {
                    UIManager.Instance.ShowWinPanel();
                    InputManager.Instance.ToggleInputActionsState(false);
                    PlayerMovement.Instance.CanMove(true);
                }
            }
            
            PlayerMovement.Instance.CanMove(true);
            gameObject.SetActive(false);
            UIManager.Instance.CanPause(true);

        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                PlayerMovement.Instance.CanMove(false);
                
            }
        }
    }
}