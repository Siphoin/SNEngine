namespace SNEngineLib.Interfaces
{
    public interface IContentPipeline
    {
        T GetAssetEngine<T>(string path);
        T LoadAsset<T>(string path);
    }
}
