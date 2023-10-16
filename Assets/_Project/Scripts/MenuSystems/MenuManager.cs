using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using KLab.MessageBuses;
using Sirenix.OdinInspector;

public class MenuManager : MonoBehaviour
{
    public WelcomeMenu WelcomeMenuPreab;
    public PauseMenu PauseMenuPrefab;
    public GameOver GameOverMenuPrefab;
    public HUDMenu HUDMenuPrefab;

    [SerializeField] private Stack<Menu> _menuStack = new();

    public static MenuManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        WelcomeMenu.Show();

        MessageBus.GetBus<BoardAction>()
            .Connect(msg => OnActionMessage(msg));
        MessageBus.GetBus<HUDButtonAction>()
            .Connect(msg => OnHUDButtonActionMessage(msg));
    }

    private void OnHUDButtonActionMessage(HUDButtonActionType msg)
    {
        switch (msg)
        {
            case HUDButtonActionType.Pause:
                print("bomboclaat");
                PauseMenu.Show();
                break;
            case HUDButtonActionType.Exit:
                WelcomeMenu.Show();
                break;
            default:
                break;

        }
    }

    private void OnActionMessage(BoardActionType msg)
    {
        switch (msg)
        {
            case BoardActionType.Close:
                break;
            case BoardActionType.Show:
                HUDMenu.Show();
                break;
            default:
                break;

        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public T CreateInstance<T>() where T : Menu
    {
        var prefab = GetPrefab<T>();

        return Instantiate(prefab, transform);
    }

    public void OpenMenu(Menu instance)
    {
        // De-activate top menu
        if (_menuStack.Count > 0)
        {
            if (instance.DisableMenusUnderneath)
            {
                foreach (var menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);

                    if (menu.DisableMenusUnderneath)
                        break;
                }
            }

            var topCanvas = instance.GetComponent<Canvas>();
            var previousCanvas = _menuStack.Peek().GetComponent<Canvas>();
            topCanvas.sortingOrder = previousCanvas.sortingOrder + 1;
        }

        _menuStack.Push(instance);

    }

    private T GetPrefab<T>() where T : Menu
    {
        // Get prefab dynamically, based on public fields set from Unity
        // You can use private fields with SerializeField attribute too
        var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var field in fields)
        {
            var prefab = field.GetValue(this) as T;

            if (prefab != null)
            {
                return prefab;
            }
        }

        throw new MissingReferenceException("Prefab not found for type " + typeof(T));
    }

    public void CloseMenu(Menu menu)
    {
        if (_menuStack.Count == 0)
        {
            Debug.LogErrorFormat(menu, "{0} cannot be closed because menu stack is empty", menu.GetType());

            return;
        }

        if (_menuStack.Peek() != menu)
        {
            Debug.LogErrorFormat(menu, "{0} cannot be closed because it is not on top of stack", menu.GetType());
            return;
        }

        CloseTopMenu();
    }

    public void CloseTopMenu()
    {

        //Debug.Log("On close, Stack count: "+ _menuStack.Count);
        var instance = _menuStack.Pop();

        if (instance.DestroyWhenClosed)
            Destroy(instance.gameObject);
        else
            instance.gameObject.SetActive(false);

        // Re-activate top menu
        // If a re-activated menu is an overlay we need to activate the menu under it
        foreach (var menu in _menuStack)
        {
            menu.gameObject.SetActive(true);

            if (menu.DisableMenusUnderneath)
                break;
        }
    }

    private void Update()
    {
        // On Android the back button is sent as Esc
        if (Input.GetKeyDown(KeyCode.Escape) && _menuStack.Count > 0)
        {
            _menuStack.Peek().OnBackPressed();
        }
    }
}

