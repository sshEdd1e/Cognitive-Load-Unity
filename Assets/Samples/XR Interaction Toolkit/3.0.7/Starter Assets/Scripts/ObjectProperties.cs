using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public enum ShapeType { Cube, Pyramid, Sphere }
    public enum ColorType { Blue, Red, Green, Yellow }

    public ShapeType shape;
    public ColorType color;
}
