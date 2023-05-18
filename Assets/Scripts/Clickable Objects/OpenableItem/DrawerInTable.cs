using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInTable : PickableItem
{
    [SerializeField] GameObject opanableObject;
    private bool isOpenDrawer;

    private void Start()
    {
        isOpenDrawer = false;
    }

    public override void OnClick()
    {
        if (isOpenDrawer == false)
        {
            OpenDraawer();
        }
        else
        {
            CloseDraawer();
        }
    }

    private void OpenDraawer()
    {
        isOpenDrawer = true;
        opanableObject.SetActive(true);
        UIAudioManager.instance.PlayShelfSlideAudio(0.8f);
    }

    private void CloseDraawer()
    {
        isOpenDrawer = false;
        opanableObject.SetActive(false);
        UIAudioManager.instance.PlayShelfSlideAudio(0.8f);
    }

    public override void OnItemCombineAttempt()
    {
        throw new System.NotImplementedException();
    }
}
