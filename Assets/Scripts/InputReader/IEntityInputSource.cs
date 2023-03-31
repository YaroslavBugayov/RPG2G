namespace InputReader
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }
        float VerticalDirection { get; }
        bool Use { get; }

        void ResetOneTimeActions();
    }
}