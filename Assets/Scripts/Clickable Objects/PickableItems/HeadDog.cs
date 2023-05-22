using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDog : PickableItem
{
    private Animator anim_HeadDog;

    private Vector2 defaultLocalPosition = new Vector3(3.2f, 1.5f, -0.02f);
    private Vector3 leftLocalPosition = new Vector3(-3.2f, 1.5f, -0.02f);

    [SerializeField] private GameObject canvasText;
    [SerializeField] private PickableItem bowlSoup_Type;
    [SerializeField] private AudioClip audioDogBarking;

    private bool isCanClick;

    private void Start()
    {
        anim_HeadDog = GetComponent<Animator>();
        isCanClick = true;
    }
    public override void OnClick()
    {
        if (isCanClick == false)
        {
            return;
        }

        if (TakingSoup() == false)
        {
            anim_HeadDog.SetTrigger("isBarking");
            GameController.GetInstance().PlaySimpleAudio(audioDogBarking);
            StartCoroutine(ForbbidenBarking());
        }
        else
        {
            UIAudioManager.instance.PlayDogEating(0.5f);
            transform.localPosition = leftLocalPosition;
            isCanClick = false;
        }
    }

    public void OpenBarkingCloud() => canvasText.SetActive(true);

    private bool TakingSoup()
    {
        foreach (InventoryItemSlot slot in playerInventory.GetComponentsInChildren<InventoryItemSlot>())
        {
            if (slot.IsItemSelected == true)
            {
                if (slot.ItemInSlot == bowlSoup_Type)
                {
                    playerInventory.RemoveItemFromInventory(slot.ItemInSlot);
                    slot.DeselectItem();
                    return true;
                }
            }
        }

        return false;
    }

    private IEnumerator ForbbidenBarking()
    {
        isCanClick = false;
        yield return new WaitForSeconds(1.0f);
        isCanClick = true;
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
