using UnityEngine;

public class BadExmaple : MonoBehaviour
{
    private Transform[] _placePoints;
    private int _currentPlaceIndex;
    
    public float Speed { get; private set; }
    public Transform AllPlacePoints { get; private set; }
    
    private void Start()
    {
        _placePoints = new Transform[AllPlacePoints.childCount];
        _currentPlaceIndex = 0;

        for (int i = 0; i < _placePoints.Length; i++)
            _placePoints[i] = AllPlacePoints.GetChild(i).GetComponent<Transform>();
    }
    
    private void Update()
    {
        var _currentPlace = _placePoints[_currentPlaceIndex];
        transform.position = Vector3.MoveTowards(transform.position, _currentPlace.position, Speed * Time.deltaTime);

        if (transform.position == _currentPlace.position) 
            SelectNextPlace();
    }

    public void SelectNextPlace()
    {
        _currentPlaceIndex++;

        if (_currentPlaceIndex == _placePoints.Length)
            _currentPlaceIndex = 0;

        var pointPosition = _placePoints[_currentPlaceIndex].transform.position;
        transform.forward = pointPosition - transform.position;
    }
}