using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance { get; set; }

    public GameObject InteractionInfo;
    TextMeshProUGUI interaction_text;
    public bool onTarget;


    private void Start()
    {
        onTarget = false;
        interaction_text = InteractionInfo.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if (!PauseMenu.isPaused) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10))
            {
                var selectionTransform = hit.transform;
                InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();

                if (interactable && interactable.playerInRange)
                {
                    onTarget = true;
                    InteractionInfo.SetActive(true);
                    interaction_text.text = interactable.GetItemName();
                }
                else
                {
                    onTarget = false;
                    InteractionInfo.SetActive(false);
                }
            }
            else
            {
                onTarget = false;
                InteractionInfo.SetActive(false);
            }
        }
    }
}
