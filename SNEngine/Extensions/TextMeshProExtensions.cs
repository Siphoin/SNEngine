using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SNEngine.Extensions
{
    public static class TextMeshProExtensions
    {
        public static void ChangeColor(this TextMeshProUGUI textMeshPro, int characterIndex, Color color)
        {
            textMeshPro.ForceMeshUpdate();
            Color[] colors = textMeshPro.mesh.colors;
            colors[4 * characterIndex] = color;
            colors[4 * characterIndex + 1] = color;
            colors[4 * characterIndex + 2] = color;
            colors[4 * characterIndex + 3] = color;
            textMeshPro.mesh.colors = colors;
            textMeshPro.UpdateVertexData();
        }
    }
}
