using UnityEngine;

namespace SNEngine.Services
{
    public class RenderOldDialogueService : IService, IOldRenderDialogue
    {
        private IOldRenderDialogue _renderDialogue;

        public void Initialize()
        {
            var render = Resources.Load<OldRenderDialogue>("Render/OldRenderDialogue");

            var prefab = Object.Instantiate(render);

            prefab.name = render.name;

            Object.DontDestroyOnLoad(prefab);

            _renderDialogue = prefab;
        }

        public Texture2D UpdateRender()
        {
            return _renderDialogue.UpdateRender();
        }

        public void Clear()
        {
            _renderDialogue.Clear();
        }
    }
}
