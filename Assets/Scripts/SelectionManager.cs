using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance { get; set; }

    public GameObject InteractionInfo;
    public float interactRange = 2;
    TextMeshProUGUI interaction_text;
    public bool onTarget;


    private void Start()
    {
        onTarget = false;
        interaction_text = InteractionInfo.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        //Debug.Log(onTarget);

        if (!PauseMenu.isPaused) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactRange))
            {
                var selectionTransform = hit.transform;
                InteractableObject interactable = selectionTransform.GetComponentInChildren<InteractableObject>();

                if (interactable)
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
