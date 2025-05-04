using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    public UnityEvent OnEnterRoom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnterRoom.Invoke();
        }
    }

}
