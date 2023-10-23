using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    public class SetBackgroundNode : BaseNodeInteraction
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Sprite _sprite;

        public Sprite Sprite => _sprite;

        public override void Execute()
        {
            Sprite sprite = _sprite;

            Sprite input = GetDataFromPort<Sprite>(nameof(_sprite));

            if (input != null)
            {
                sprite = input;
            }

            var backgroundService = NovelGame.GetService<BackgroundService>();

            backgroundService.Set(sprite);
        }
    }
}
