using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class StartTrigger : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finish;

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.BecameWinnable(true);
            //_finish.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.BecameWinnable(false);
            //_finish.gameObject.SetActive(false);
        }
    }
}
