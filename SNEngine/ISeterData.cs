namespace SNEngine
{
    public interface ISeterData<T>
    {
        void SetData(T data);
    }

    public interface ISeterData<T1, T2>
    {
        void SetData(T1 dataFirst, T2 dataSecond);
    }
}
