using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _waypointsContainer;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypointIndex;

    public float Speed => _speed;
    public Transform WaypointContainer => _waypointsContainer;
    
    private void Start()
    {
        _currentWaypointIndex = 0;
    }
    
    private void Update()
    {
        var _currentWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == _currentWaypoint.position) 
            SelectNextWaypoint();
    }

    public void SelectNextWaypoint()
    {
        _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;

        var waypointPosition = _waypoints[_currentWaypointIndex].transform.position;
        transform.forward = waypointPosition - transform.position;
    }

    #if UNITY_EDITOR
    
    [ContextMenu("FillChildrensArray")]
    private void FillChildArray()
    {
        _waypoints = new Transform[_waypointsContainer.childCount];

        for (int i = 0; i < _waypoints.Length; i++)
            _waypoints[i] = _waypointsContainer.GetChild(i);
    }

    #endif
}