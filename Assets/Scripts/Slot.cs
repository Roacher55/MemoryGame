using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField]SlotsManager slotsManager;
    public Sprite spriteSlot;
    public Image imageSlot;


    // Start is called before the first frame update
    void Awake()
    {
        slotsManager = FindObjectOfType<SlotsManager>();
        slotsManager.slots.Add(this.gameObject);
        imageSlot = GetComponent<Image>();
        imageSlot.color = Color.blue;

    }

    private void Start()
    {
        Invoke("HideSprite", 5f);
    }

    void HideSprite()
    {
        slotsManager.slots.Add(this.gameObject);
        imageSlot.sprite = null;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imageSlot.sprite == null && imageSlot.color != Color.green)
        {
            imageSlot.color = Color.yellow;
        }
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        if (imageSlot.sprite == null && imageSlot.color != Color.green)
        {
            imageSlot.color = Color.blue;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (imageSlot.sprite == null && slotsManager.selectedSlot != null)
        {
            slotsManager.AreSlotTheSame(slotsManager.selectedSlot, this.gameObject);
            return;
        }


        if (imageSlot.sprite == null && slotsManager.selectedSlot == null && imageSlot.color == Color.yellow)
        {
            imageSlot.sprite = spriteSlot;
            slotsManager.selectedSlot = this.gameObject;
            return;
        }

    }

}
