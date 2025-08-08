using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPLayer { get; private set; }
    [SerializeField]
    private float _playerAwarenessDistance;
    private Transform _player;

    private void Awake()
    {
        _player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPLayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= _playerAwarenessDistance )
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
