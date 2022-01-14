using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsManager : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    [SerializeField] List<Sprite> sprites;
    public GameObject selectedSlot;
    [SerializeField]GameHelper gameHelper;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip goodClip;
    [SerializeField] AudioClip wrongClip;
    public bool canClick = true;



    private void Start()
    {
        RandomSpriteinSlot();
        selectedSlot = null;
    }


    void RandomSpriteinSlot()
    {
        foreach (var sprite in sprites)
        {
            var temp = Random.Range(0, slots.Count);
            slots[temp].GetComponent<Image>().sprite = sprite;
            slots[temp].GetComponent<Slot>().spriteSlot = sprite;
            slots.Remove(slots[temp]);

            temp = Random.Range(0, slots.Count);
            slots[temp].GetComponent<Image>().sprite = sprite;
            slots[temp].GetComponent<Slot>().spriteSlot = sprite;
            slots.Remove(slots[temp]);
        }
    }

    public void AreSlotTheSame(GameObject slot1, GameObject slot2)
    {
        Slot slot1Slot = slot1.GetComponent<Slot>();
        Image slot1Image = slot1.GetComponent<Image>();

        Slot slot2Slot = slot2.GetComponent<Slot>();
        Image slot2Image = slot2.GetComponent<Image>();


        if (slot1Slot.spriteSlot == slot2Slot.spriteSlot)
        {
            slot1Image.sprite = slot1Slot.spriteSlot;
            slot2Image.sprite = slot2Slot.spriteSlot;

            slot1Image.color = Color.green;
            slot2Image.color = Color.green;

            audioSource.clip = goodClip;
            audioSource.Play();
            
            gameHelper.Win(slots);
        }
        else
        {
            canClick = false;
            slot2Image.sprite = slot2Slot.spriteSlot;
            audioSource.clip = wrongClip;
            audioSource.Play();
            gameHelper.mistakes++;

            slot1Image.color = Color.red;
            slot2Image.color = Color.red;

            StartCoroutine(Hide(slot1Image, slot2Image));
        }
      
        selectedSlot = null;
    }

    IEnumerator Hide(Image image1, Image image2)
    {
        yield return new WaitForSeconds(2f);
        image1.sprite = null;
        image2.sprite = null;

        image1.color = Color.blue;
        image2.color = Color.blue;
        canClick = true;
    }

}
