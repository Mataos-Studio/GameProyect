using UnityEngine;

public interface IMovement
{
    void MoveTo(Vector3 position);
    void Move(Vector3 position);
    void ChangeSpeed(float newValue);
    void AddSpeed(float addValue);
    void ChangeDirection(Vector3 newDirection);
}