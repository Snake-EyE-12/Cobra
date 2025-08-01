using System.Collections.Generic;
using System.Linq;
using Cobra.Utilities.Extensions;
using UnityEngine;

namespace Cobra.Utilities
{
    public static class LineRenderExtensions
    {
        public static void Draw(this LineRenderer lineRenderer, List<Vector3> points)
        {
            lineRenderer.Draw(points.ToArray());
        }
        public static void Draw(this LineRenderer lineRenderer, Vector3[] points)
        {
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
        }
        public static void Draw(this LineRenderer lineRenderer, List<Vector2> points)
        {
            var newPoints = points.ToList().ConvertAll((x) => x.XYZ()).ToArray();
            lineRenderer.Draw(newPoints);
        }
        public static void Draw(this LineRenderer lineRenderer, Vector2[] points)
        {
            var newPoints = points.ToList().ConvertAll((x) => x.XYZ()).ToArray();
            lineRenderer.Draw(newPoints);
        }
    }
}
