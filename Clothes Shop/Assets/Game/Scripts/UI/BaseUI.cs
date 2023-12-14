using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Assertions;

[RequireComponent(typeof(UIDocument))]
public abstract class BaseUI : MonoBehaviour {
    public event System.Action OnOpened, OnClosed;

    protected  UIDocument uiDocument;
    protected VisualElement mainElement;

    protected virtual void Awake() {
        uiDocument = GetComponent<UIDocument>();
        mainElement = uiDocument.rootVisualElement.Q<VisualElement>("Main");
        Assert.IsNotNull(mainElement, "Missing 'Main' VisualElement.");
    }

    public bool IsOpened() {
        return mainElement.style.display == DisplayStyle.Flex;
    }

    public void Open() {
        if (IsOpened()) {
            return;
        }

        mainElement.style.display = DisplayStyle.Flex;
        OnOpened?.Invoke();
        Opened();
    }

    public void Close() {
        if (!IsOpened()) {
            return;
        }

        mainElement.style.display = DisplayStyle.None;
        OnClosed?.Invoke();
        Closed();
    }

    protected abstract void Opened();
    protected abstract void Closed();
}
