using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureAnimationController : MonoBehaviour
{
    public void ReturnCherecterRoom() => this.GetComponentInParent<DemonRoom>().ClickComeBack();
}
