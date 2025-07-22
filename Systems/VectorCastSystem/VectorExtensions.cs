using UnityEngine;

namespace Cobra.Utilities.Extensions
{

    public static class VectorExtensions
    {
        
        
        
        
        
        
        
        //public static Vector3 operator +(Vector3 vector3, Vector2 vector2) => vector3 + (Vector3)vector2;
        
        
        
        
        
        
        
        
        
        // // Implicit conversion: Vector3 -> Vector2 (z is discarded)
        // public static implicit operator Vector2(Vector3 vector3)
        // {
        //     return new Vector2(vector3.x, vector3.y); // Ignore the z component
        // }
        //
        // // Explicit conversion: Vector2 -> Vector3 (set z to 0 or some default)
        // public static explicit operator Vector3(Vector2 vector2)
        // {
        //     return new Vector3(vector2.x, vector2.y, 0f); // Set z to 0 (or any value)
        // }
        
        
        
        
        
        
        public static Vector3Int ToVector3Int(this Vector3 vector3) => new Vector3Int((int)vector3.x, (int)vector3.y, (int)vector3.z);
        public static Vector3Int ToVector3IntCeil(this Vector3 vector3) => new Vector3Int(Mathf.CeilToInt(vector3.x), Mathf.CeilToInt(vector3.y), Mathf.CeilToInt(vector3.z));
        public static Vector3Int ToVector3IntFloor(this Vector3 vector3) => new Vector3Int(Mathf.FloorToInt(vector3.x), Mathf.FloorToInt(vector3.y), Mathf.FloorToInt(vector3.z));
        public static Vector3Int ToVector3IntRound(this Vector3 vector3) => new Vector3Int(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.y), Mathf.RoundToInt(vector3.z));
        public static Vector3 ToVector3(this Vector3Int vector3) => new Vector3(vector3.x, vector3.y, vector3.z);
        
        public static Vector2Int ToVector2Int(this Vector2 vector2) => new Vector2Int((int)vector2.x, (int)vector2.y);
        public static Vector2Int ToVector2IntCeil(this Vector2 vector2) => new Vector2Int(Mathf.CeilToInt(vector2.x), Mathf.CeilToInt(vector2.y));
        public static Vector2Int ToVector2IntFloor(this Vector2 vector2) => new Vector2Int(Mathf.FloorToInt(vector2.x), Mathf.FloorToInt(vector2.y));
        public static Vector2Int ToVector2IntRound(this Vector2 vector2) => new Vector2Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
        public static Vector2 ToVector2(this Vector2Int vector2) => new Vector2(vector2.x, vector2.y);
        
        public static Vector3Int ToVector3Int(this Vector2 vector2) => new Vector3Int((int)vector2.x, (int)vector2.y, 0);
        public static Vector3Int ToVector3IntCeil(this Vector2 vector2) => new Vector3Int(Mathf.CeilToInt(vector2.x), Mathf.CeilToInt(vector2.y), 0);
        public static Vector3Int ToVector3IntFloor(this Vector2 vector2) => new Vector3Int(Mathf.FloorToInt(vector2.x), Mathf.FloorToInt(vector2.y), 0);
        public static Vector3Int ToVector3IntRound(this Vector2 vector2) => new Vector3Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y), 0);
        public static Vector3 ToVector3(this Vector2Int vector2) => new Vector3(vector2.x, vector2.y, 0.0f);
        
        public static Vector2Int ToVector2Int(this Vector3 vector3) => new Vector2Int((int)vector3.x, (int)vector3.y);
        public static Vector2Int ToVector2IntCeil(this Vector3 vector3) => new Vector2Int(Mathf.CeilToInt(vector3.x), Mathf.CeilToInt(vector3.y));
        public static Vector2Int ToVector2IntFloor(this Vector3 vector3) => new Vector2Int(Mathf.FloorToInt(vector3.x), Mathf.FloorToInt(vector3.y));
        public static Vector2Int ToVector2IntRound(this Vector3 vector3) => new Vector2Int(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.y));
        public static Vector2 ToVector2(this Vector3Int vector3) => new Vector2(vector3.x, vector3.y);
        
        
        public static Vector2 ToVector2(this Vector3 vector3) => new Vector2(vector3.x, vector3.y);
        public static Vector2 XY(this Vector3 vector3) => ToVector2(vector3);
        public static Vector2 xy(this Vector3 vector3) => ToVector2(vector3);
        
        public static Vector2Int ToVector2Int(this Vector3Int vector3) => new Vector2Int(vector3.x, vector3.y);
        public static Vector2Int XY(this Vector3Int vector3) => ToVector2Int(vector3);
        public static Vector2Int xy(this Vector3Int vector3) => ToVector2Int(vector3);
        
        public static Vector3 ToVector3(this Vector2 vector2) => new Vector3(vector2.x, vector2.y, 0f);
        public static Vector3 XYZ(this Vector2 vector2) => ToVector3(vector2);
        public static Vector3 xyz(this Vector2 vector2) => ToVector3(vector2);
        public static Vector3 Z(this Vector2 vector2) => ToVector3(vector2);
        public static Vector3 z(this Vector2 vector2) => ToVector3(vector2);
        
        public static Vector3Int ToVector3Int(this Vector2Int vector2) => new Vector3Int(vector2.x, vector2.y, 0);
        public static Vector3Int XYZ(this Vector2Int vector2) => ToVector3Int(vector2);
        public static Vector3Int xyz(this Vector2Int vector2) => ToVector3Int(vector2);
        public static Vector3Int Z(this Vector2Int vector2) => ToVector3Int(vector2);
        public static Vector3Int z(this Vector2Int vector2) => ToVector3Int(vector2);
    }
}