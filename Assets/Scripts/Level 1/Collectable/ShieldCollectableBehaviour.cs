using UnityEngine;

public class ShieldCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private Crystal _crystal;

    public void OnCollected(GameObject player)
    {
        if(_crystal != null)
        {
            _crystal.ReduceCollisions();
        }
    }
}
