using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField]
    private float _playerAwarenessDistance;
    private Transform _player;
    private Transform _crystal;
    public Vector2 DirectionToCrystal { get; private set; }

    private void Awake()
    {
        _player = FindFirstObjectByType<PlayerMovement>().transform;
        _crystal = FindFirstObjectByType<Crystal>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        Vector2 enemyToCrystalVector = _crystal.position - transform.position;
        DirectionToCrystal = enemyToCrystalVector.normalized;

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
