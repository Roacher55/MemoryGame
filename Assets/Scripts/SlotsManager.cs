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

            

            audioSource.clip = goodClip;
            audioSource.Play();
            
            gameHelper.Win(slots);
        }
        else
        {
            audioSource.clip = wrongClip;
            audioSource.Play();
            slot1Image.sprite = null;
            slot2Image.sprite = null;

            slot1Image.color = Color.blue;
            slot2Image.color = Color.blue;

            gameHelper.mistakes++;
        }
      
        selectedSlot = null;
    }

    void Win()
    {

    }

}
