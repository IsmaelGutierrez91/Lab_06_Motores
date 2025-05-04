using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Interact;
    public GameObject Dialogue;
    public TextMeshProUGUI DialogueText;
    public string Text1;
    public string Text2;
    public string Text3;
    public bool CanInteract = false;

    public float npcSpeed;
    public int xDirection;
    public int zDirection;
    bool canChangueDirection = true;
    public bool canMove = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Interact.SetActive(false);
        Dialogue.SetActive(false);
    }
    private void Update()
    {
        StartCoroutine(ChangueDirection());
    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            rb.linearVelocity = new Vector3(npcSpeed * xDirection, rb.linearVelocity.y, npcSpeed * zDirection);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
    private void OnEnable()
    {
        PlayerController.OnNpcInteraction += OnInteractionWhitPlayer;
    }
    private void OnDisable()
    {
        PlayerController.OnNpcInteraction -= OnInteractionWhitPlayer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Interact.SetActive(true);
            CanInteract = true;
            canMove = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Interact.SetActive(false);
            Dialogue.SetActive(false);
            CanInteract = false;
            canMove = true;
        }
    }
    public void OnInteractionWhitPlayer()
    {
        if (CanInteract == true)
        {
            Dialogue.SetActive(true);
        }
    }
    private IEnumerator ChangueDirection()
    {
        if(canChangueDirection == true)
        {
            canChangueDirection = false;
            switch (Random.Range(1, 4))
            {
                case 1:
                    DialogueText.text = Text1;
                    break;
                case 2:
                    DialogueText.text = Text2;
                    break;
                case 3:
                    DialogueText.text = Text3;
                    break;
            }
            yield return new WaitForSeconds(3);
            xDirection = Random.Range(-1, 2);
            zDirection = Random.Range(-1, 2);

            canChangueDirection = true;
        }
    }
}
