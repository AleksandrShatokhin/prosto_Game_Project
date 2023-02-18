using UnityEngine;
using UnityEngine.LowLevel;

public class CityMapManager : MonoBehaviour
{
    [SerializeField] private GameObject playerRoom, houses;

    public void DeleteCall()
    {
        foreach (Transform house in houses.transform)
        {
            if (house.gameObject.activeInHierarchy)
            {
                house.gameObject.SetActive(false);
            }
        }

        GameController.GetInstance().gameObject.GetComponent<CallCreator>().GenerateCall_On();
    }

    public void ComebackToPlayerRoom() => GameController.GetInstance().SwitchWindow(playerRoom, this.gameObject);
}
