using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;

namespace SNEngine.Animations.TextEffects
{
    public class CharsReadTextEffect : TextEffect
    {
        [SerializeField] private Color _color;

        private bool _startedTask;
        protected override void TextUpdate(TextMeshProUGUI textMesh)
        {
            if (!_startedTask)
            {
                _startedTask = true;

                FadeChars(textMesh).Forget();
            }

        }

        private async UniTask FadeChars (TextMeshProUGUI textMesh)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Time.fixedDeltaTime);

            Color startColor = textMesh.color;

            while (!AllTextWrited)
            {
                textMesh.ForceMeshUpdate();

                var characterInfo = textMesh.textInfo.characterInfo;

                int characterLastIndex = characterInfo.Length - 1;

                for ( int i = characterInfo.Length - 1; i != 0; i--)
                {
                    int characterIndex = i;

                    int meshIndex = characterInfo[characterIndex].materialReferenceIndex;

                    int vertexIndex = textMesh.textInfo.characterInfo[characterIndex].vertexIndex;

                    Color32[] vertexColors = textMesh.textInfo.meshInfo[meshIndex].colors32;


                    for (int j = 0; j < 4; j++)
                    {
                        int index = vertexIndex + j;

                        vertexColors[index] =  i != characterLastIndex ? startColor : _color;


                    }
                }

                textMesh.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                await UniTask.Delay(timeSpan);
            }

            textMesh.color = startColor;

            _startedTask = false;
        }
        }

    }