using UnityEngine;

// Handle rotation on the current object
public class RotateManager : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private Axis _axis = Axis.Y;
    [SerializeField]
    private bool _isLocal = false;


    public enum Axis
    {
        X,
        Y,
        Z
    }

    private float _eulerAngle = 0.0f;


    public void Rotate(float value)
    {
        _eulerAngle += _speed * value;
    }


    private void Update()
    {
        if (_isLocal)
        {
            transform.localEulerAngles = _eulerAngle * Direction;
        }
        else
        {
            transform.eulerAngles = _eulerAngle * Direction;
        }
    }


    private Vector3 Direction
    {
        get
        {
            switch (_axis)
            {
                case Axis.X: return Vector3.right;
                case Axis.Y: return Vector3.down;
                default:
                case Axis.Z: return Vector3.forward;
            }
        }
    }
}
