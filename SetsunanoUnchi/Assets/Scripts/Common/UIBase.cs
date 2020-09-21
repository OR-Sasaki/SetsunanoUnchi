public abstract class UIBase
{
    public virtual void OnUIEvent(UIBase ui, string message) { }

    public void SendEvent(string message)
    {
        GameManager.I.OnUIEvent(this, message);
    }
}