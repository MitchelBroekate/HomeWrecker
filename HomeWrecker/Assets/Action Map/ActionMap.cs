//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Action Map/ActionMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ActionMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionMap"",
    ""maps"": [
        {
            ""name"": ""MainMenu"",
            ""id"": ""64eeeb98-43de-42fe-8c40-5e7a6f2fff1e"",
            ""actions"": [
                {
                    ""name"": ""Escape Key"",
                    ""type"": ""Button"",
                    ""id"": ""a6d5741c-869a-4705-b209-1ca2ddcd65af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu Left"",
                    ""type"": ""Button"",
                    ""id"": ""cd3a4f42-4f70-4348-b709-93bbd17f189a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu Right"",
                    ""type"": ""Button"",
                    ""id"": ""bf4da0b9-ab0d-4e1a-9f6d-d41703f48518"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68919e81-58fb-4f14-a760-7070bad78249"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape Key"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e66c4cc8-90cf-4e88-8d6e-c84bca64662e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a52cb9ee-44e8-43bc-b17f-6f8b690fc367"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Main Game"",
            ""id"": ""07128526-f56a-4734-a173-7a22512fff0d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a5aeef83-397b-4b84-af45-37226268f051"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""2e1e55b8-74f7-4dd5-9f64-ff340cddc600"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2824e147-369e-4ff7-9328-c848be5e44b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Key1"",
                    ""type"": ""Button"",
                    ""id"": ""f975314f-c82f-4c5b-8f41-8e38b0685467"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Key2"",
                    ""type"": ""Button"",
                    ""id"": ""26018cf8-1ecf-4f60-ab43-5a76884051f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Key3"",
                    ""type"": ""Button"",
                    ""id"": ""a06c2922-f874-4b5c-bfab-1ff77f075928"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Key4"",
                    ""type"": ""Button"",
                    ""id"": ""3e904f3f-9165-49e8-b846-aa0147981d1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""75d7c819-bdd3-4e3a-8ca7-406077503767"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DevAddScore"",
                    ""type"": ""Button"",
                    ""id"": ""de163887-c5b4-4b9c-818b-175c8a63e24a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DevDecreaseTime"",
                    ""type"": ""Button"",
                    ""id"": ""16288b05-a2ed-4c2f-9e56-fb422bb8f205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DevClearPlayerPrefs"",
                    ""type"": ""Button"",
                    ""id"": ""8db3db49-ec01-422b-82dc-d3263357403f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b8ce5eed-4bff-4056-9307-35e473ee7823"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e3dcf6d1-8b21-45aa-8f07-5404fb1c0d04"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ccd53bdc-4830-4398-8365-cbadb63d5485"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f05d661d-7218-4d6e-b200-e6d59a9b1a8e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""328c739f-e9b8-43db-916f-b3f6ec85ff70"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc34f2aa-9aba-417b-9fe6-c463494efb64"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fe42aff-4f70-402a-ad3e-1c3b0370ac6f"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a0ca1c3-3533-4d1d-a544-b311f269ffc5"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ca80e97-a999-48cc-a070-4ba89962c1bf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06e78042-6a17-4e4a-ba08-9163941e4c31"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cae1b29-01e3-4b9d-afa5-c14d24192642"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f943d15-decf-43fc-a7b1-3dee2299efaf"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DevAddScore"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d12299b1-c07f-4329-a718-ec05fe24ff1f"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DevDecreaseTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd706cdb-9734-4bf8-a0db-3a083cb8a346"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DevClearPlayerPrefs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95b327d9-3ab7-472b-82a4-76288196dd31"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Key4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_EscapeKey = m_MainMenu.FindAction("Escape Key", throwIfNotFound: true);
        m_MainMenu_MenuLeft = m_MainMenu.FindAction("Menu Left", throwIfNotFound: true);
        m_MainMenu_MenuRight = m_MainMenu.FindAction("Menu Right", throwIfNotFound: true);
        // Main Game
        m_MainGame = asset.FindActionMap("Main Game", throwIfNotFound: true);
        m_MainGame_Movement = m_MainGame.FindAction("Movement", throwIfNotFound: true);
        m_MainGame_Sprint = m_MainGame.FindAction("Sprint", throwIfNotFound: true);
        m_MainGame_Jump = m_MainGame.FindAction("Jump", throwIfNotFound: true);
        m_MainGame_Key1 = m_MainGame.FindAction("Key1", throwIfNotFound: true);
        m_MainGame_Key2 = m_MainGame.FindAction("Key2", throwIfNotFound: true);
        m_MainGame_Key3 = m_MainGame.FindAction("Key3", throwIfNotFound: true);
        m_MainGame_Key4 = m_MainGame.FindAction("Key4", throwIfNotFound: true);
        m_MainGame_PauseGame = m_MainGame.FindAction("PauseGame", throwIfNotFound: true);
        m_MainGame_DevAddScore = m_MainGame.FindAction("DevAddScore", throwIfNotFound: true);
        m_MainGame_DevDecreaseTime = m_MainGame.FindAction("DevDecreaseTime", throwIfNotFound: true);
        m_MainGame_DevClearPlayerPrefs = m_MainGame.FindAction("DevClearPlayerPrefs", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private List<IMainMenuActions> m_MainMenuActionsCallbackInterfaces = new List<IMainMenuActions>();
    private readonly InputAction m_MainMenu_EscapeKey;
    private readonly InputAction m_MainMenu_MenuLeft;
    private readonly InputAction m_MainMenu_MenuRight;
    public struct MainMenuActions
    {
        private @ActionMap m_Wrapper;
        public MainMenuActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @EscapeKey => m_Wrapper.m_MainMenu_EscapeKey;
        public InputAction @MenuLeft => m_Wrapper.m_MainMenu_MenuLeft;
        public InputAction @MenuRight => m_Wrapper.m_MainMenu_MenuRight;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void AddCallbacks(IMainMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MainMenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainMenuActionsCallbackInterfaces.Add(instance);
            @EscapeKey.started += instance.OnEscapeKey;
            @EscapeKey.performed += instance.OnEscapeKey;
            @EscapeKey.canceled += instance.OnEscapeKey;
            @MenuLeft.started += instance.OnMenuLeft;
            @MenuLeft.performed += instance.OnMenuLeft;
            @MenuLeft.canceled += instance.OnMenuLeft;
            @MenuRight.started += instance.OnMenuRight;
            @MenuRight.performed += instance.OnMenuRight;
            @MenuRight.canceled += instance.OnMenuRight;
        }

        private void UnregisterCallbacks(IMainMenuActions instance)
        {
            @EscapeKey.started -= instance.OnEscapeKey;
            @EscapeKey.performed -= instance.OnEscapeKey;
            @EscapeKey.canceled -= instance.OnEscapeKey;
            @MenuLeft.started -= instance.OnMenuLeft;
            @MenuLeft.performed -= instance.OnMenuLeft;
            @MenuLeft.canceled -= instance.OnMenuLeft;
            @MenuRight.started -= instance.OnMenuRight;
            @MenuRight.performed -= instance.OnMenuRight;
            @MenuRight.canceled -= instance.OnMenuRight;
        }

        public void RemoveCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MainMenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainMenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);

    // Main Game
    private readonly InputActionMap m_MainGame;
    private List<IMainGameActions> m_MainGameActionsCallbackInterfaces = new List<IMainGameActions>();
    private readonly InputAction m_MainGame_Movement;
    private readonly InputAction m_MainGame_Sprint;
    private readonly InputAction m_MainGame_Jump;
    private readonly InputAction m_MainGame_Key1;
    private readonly InputAction m_MainGame_Key2;
    private readonly InputAction m_MainGame_Key3;
    private readonly InputAction m_MainGame_Key4;
    private readonly InputAction m_MainGame_PauseGame;
    private readonly InputAction m_MainGame_DevAddScore;
    private readonly InputAction m_MainGame_DevDecreaseTime;
    private readonly InputAction m_MainGame_DevClearPlayerPrefs;
    public struct MainGameActions
    {
        private @ActionMap m_Wrapper;
        public MainGameActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MainGame_Movement;
        public InputAction @Sprint => m_Wrapper.m_MainGame_Sprint;
        public InputAction @Jump => m_Wrapper.m_MainGame_Jump;
        public InputAction @Key1 => m_Wrapper.m_MainGame_Key1;
        public InputAction @Key2 => m_Wrapper.m_MainGame_Key2;
        public InputAction @Key3 => m_Wrapper.m_MainGame_Key3;
        public InputAction @Key4 => m_Wrapper.m_MainGame_Key4;
        public InputAction @PauseGame => m_Wrapper.m_MainGame_PauseGame;
        public InputAction @DevAddScore => m_Wrapper.m_MainGame_DevAddScore;
        public InputAction @DevDecreaseTime => m_Wrapper.m_MainGame_DevDecreaseTime;
        public InputAction @DevClearPlayerPrefs => m_Wrapper.m_MainGame_DevClearPlayerPrefs;
        public InputActionMap Get() { return m_Wrapper.m_MainGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainGameActions set) { return set.Get(); }
        public void AddCallbacks(IMainGameActions instance)
        {
            if (instance == null || m_Wrapper.m_MainGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainGameActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Key1.started += instance.OnKey1;
            @Key1.performed += instance.OnKey1;
            @Key1.canceled += instance.OnKey1;
            @Key2.started += instance.OnKey2;
            @Key2.performed += instance.OnKey2;
            @Key2.canceled += instance.OnKey2;
            @Key3.started += instance.OnKey3;
            @Key3.performed += instance.OnKey3;
            @Key3.canceled += instance.OnKey3;
            @Key4.started += instance.OnKey4;
            @Key4.performed += instance.OnKey4;
            @Key4.canceled += instance.OnKey4;
            @PauseGame.started += instance.OnPauseGame;
            @PauseGame.performed += instance.OnPauseGame;
            @PauseGame.canceled += instance.OnPauseGame;
            @DevAddScore.started += instance.OnDevAddScore;
            @DevAddScore.performed += instance.OnDevAddScore;
            @DevAddScore.canceled += instance.OnDevAddScore;
            @DevDecreaseTime.started += instance.OnDevDecreaseTime;
            @DevDecreaseTime.performed += instance.OnDevDecreaseTime;
            @DevDecreaseTime.canceled += instance.OnDevDecreaseTime;
            @DevClearPlayerPrefs.started += instance.OnDevClearPlayerPrefs;
            @DevClearPlayerPrefs.performed += instance.OnDevClearPlayerPrefs;
            @DevClearPlayerPrefs.canceled += instance.OnDevClearPlayerPrefs;
        }

        private void UnregisterCallbacks(IMainGameActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Key1.started -= instance.OnKey1;
            @Key1.performed -= instance.OnKey1;
            @Key1.canceled -= instance.OnKey1;
            @Key2.started -= instance.OnKey2;
            @Key2.performed -= instance.OnKey2;
            @Key2.canceled -= instance.OnKey2;
            @Key3.started -= instance.OnKey3;
            @Key3.performed -= instance.OnKey3;
            @Key3.canceled -= instance.OnKey3;
            @Key4.started -= instance.OnKey4;
            @Key4.performed -= instance.OnKey4;
            @Key4.canceled -= instance.OnKey4;
            @PauseGame.started -= instance.OnPauseGame;
            @PauseGame.performed -= instance.OnPauseGame;
            @PauseGame.canceled -= instance.OnPauseGame;
            @DevAddScore.started -= instance.OnDevAddScore;
            @DevAddScore.performed -= instance.OnDevAddScore;
            @DevAddScore.canceled -= instance.OnDevAddScore;
            @DevDecreaseTime.started -= instance.OnDevDecreaseTime;
            @DevDecreaseTime.performed -= instance.OnDevDecreaseTime;
            @DevDecreaseTime.canceled -= instance.OnDevDecreaseTime;
            @DevClearPlayerPrefs.started -= instance.OnDevClearPlayerPrefs;
            @DevClearPlayerPrefs.performed -= instance.OnDevClearPlayerPrefs;
            @DevClearPlayerPrefs.canceled -= instance.OnDevClearPlayerPrefs;
        }

        public void RemoveCallbacks(IMainGameActions instance)
        {
            if (m_Wrapper.m_MainGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainGameActions instance)
        {
            foreach (var item in m_Wrapper.m_MainGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainGameActions @MainGame => new MainGameActions(this);
    public interface IMainMenuActions
    {
        void OnEscapeKey(InputAction.CallbackContext context);
        void OnMenuLeft(InputAction.CallbackContext context);
        void OnMenuRight(InputAction.CallbackContext context);
    }
    public interface IMainGameActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnKey1(InputAction.CallbackContext context);
        void OnKey2(InputAction.CallbackContext context);
        void OnKey3(InputAction.CallbackContext context);
        void OnKey4(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnDevAddScore(InputAction.CallbackContext context);
        void OnDevDecreaseTime(InputAction.CallbackContext context);
        void OnDevClearPlayerPrefs(InputAction.CallbackContext context);
    }
}
