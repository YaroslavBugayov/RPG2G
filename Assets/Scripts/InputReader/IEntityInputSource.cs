namespace InputReader
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }
        float VerticalDirection { get; }
        bool Use { get; }
        bool Collect { get; }

        void ResetOneTimeActions();
    }
}