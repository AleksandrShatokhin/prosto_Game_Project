using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInPlayerRoom : MonoBehaviour, IClickable
{
    private const string message = "Пока нет входящего звонка!";

    private enum callStatus { Accept, NotAccept }
    private callStatus currentCallStatus;
    private Animator anim_Phone;
    private int numberHouse;

    [SerializeField] GameObject playerRoom, houses;

    [SerializeField] private UIPhoneAudio uiPhoneAudio;

    private void Start()
    {
        currentCallStatus = callStatus.NotAccept;
        anim_Phone = GetComponentInChildren<Animator>();
        CallAnimation_Off();
    }

    private void OnEnable()
    {
        if (anim_Phone == null)
        {
            return;
        }

        if (!GameController.GetInstance().GetComponent<CallCreator>().IsCallCreated() && currentCallStatus == callStatus.NotAccept)
        {
            CallAnimation_On();
        }
    }

    public void CallCame(int numberHouse)
    {
        this.numberHouse = numberHouse;
        currentCallStatus = callStatus.NotAccept;
        CallAnimation_On();
    }

    public void OnClick()
    {
        uiPhoneAudio.PlayPhonePickUpAudio();
        OpenMessageWimdow();
    }

    public void OpenMessageWimdow()
    {
        if (GameController.GetInstance().GetComponent<CallCreator>().IsCallCreated() || currentCallStatus == callStatus.Accept)
        {
            GameController.GetInstance().DisplayMessageOnScreen(message);
            return;
        }

        GameController.GetInstance().GetComponent<CallCreator>().GenerateCall_Off();
        GameObject house = houses.transform.GetChild(numberHouse).gameObject;
        house.GetComponent<CallOnMiniMap>().OpenMessageWindow();
    }

    public void CallStatus_Accept()
    {
        currentCallStatus = callStatus.Accept;
        CallAnimation_Off();
    }
    public void CallStatus_NotAccept()
    {
        currentCallStatus = callStatus.NotAccept;
        CallAnimation_Off();
    }
    private void CallAnimation_On() => anim_Phone.SetBool("isPhoneCall", true);
    private void CallAnimation_Off() => anim_Phone.SetBool("isPhoneCall", false);
}