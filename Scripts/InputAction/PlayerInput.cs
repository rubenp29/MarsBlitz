// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputAction/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""80f9e618-da63-4e4c-9f7e-d2b5ca6e6b4d"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""28b57d96-1b71-405d-a722-c57aa98aa755"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1f09eb56-893c-4390-a0da-215687d94d99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""mousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7705b53b-aafd-49e7-8a13-872baba5f52f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""pickUp"",
                    ""type"": ""Button"",
                    ""id"": ""983300fb-e640-4b40-a8a9-ee5909842981"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""pause"",
                    ""type"": ""Button"",
                    ""id"": ""80aefb16-7b06-43c5-8b4b-235949a262d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""83a3c10a-82f1-43a5-91cf-46ffc4be0f8e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cd3adaf7-f09e-4070-bf9d-c1a2c7fcca4e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a2c67d1-c614-448c-a1d1-b352117765f9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a092ad1b-6270-4b30-890b-af5f237c6091"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""efc80c21-5ea0-403a-909f-8ef0f18517a8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f5b1888e-b1ba-454f-93d4-81d0a6854cad"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4a2be24-df43-4197-a952-3b78c6edde80"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""902a9c39-4b5c-4b1a-b31b-391199c5db96"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512bd960-d023-48fd-b163-ba46c48d3233"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ui"",
            ""id"": ""8470c20d-b849-47ff-abdc-404351b5cf7b"",
            ""actions"": [
                {
                    ""name"": ""AnimationActivation"",
                    ""type"": ""Value"",
                    ""id"": ""e1acf245-20d9-4283-bfa4-7e7fba0d3a39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f8f2aba-7692-4ee4-b911-b41e3c25abce"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnimationActivation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_movement = m_player.FindAction("movement", throwIfNotFound: true);
        m_player_shoot = m_player.FindAction("shoot", throwIfNotFound: true);
        m_player_mousePosition = m_player.FindAction("mousePosition", throwIfNotFound: true);
        m_player_pickUp = m_player.FindAction("pickUp", throwIfNotFound: true);
        m_player_pause = m_player.FindAction("pause", throwIfNotFound: true);
        // ui
        m_ui = asset.FindActionMap("ui", throwIfNotFound: true);
        m_ui_AnimationActivation = m_ui.FindAction("AnimationActivation", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_movement;
    private readonly InputAction m_player_shoot;
    private readonly InputAction m_player_mousePosition;
    private readonly InputAction m_player_pickUp;
    private readonly InputAction m_player_pause;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_player_movement;
        public InputAction @shoot => m_Wrapper.m_player_shoot;
        public InputAction @mousePosition => m_Wrapper.m_player_mousePosition;
        public InputAction @pickUp => m_Wrapper.m_player_pickUp;
        public InputAction @pause => m_Wrapper.m_player_pause;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @mousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @mousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @mousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @pickUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUp;
                @pickUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUp;
                @pickUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickUp;
                @pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
                @mousePosition.started += instance.OnMousePosition;
                @mousePosition.performed += instance.OnMousePosition;
                @mousePosition.canceled += instance.OnMousePosition;
                @pickUp.started += instance.OnPickUp;
                @pickUp.performed += instance.OnPickUp;
                @pickUp.canceled += instance.OnPickUp;
                @pause.started += instance.OnPause;
                @pause.performed += instance.OnPause;
                @pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);

    // ui
    private readonly InputActionMap m_ui;
    private IUiActions m_UiActionsCallbackInterface;
    private readonly InputAction m_ui_AnimationActivation;
    public struct UiActions
    {
        private @PlayerInput m_Wrapper;
        public UiActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @AnimationActivation => m_Wrapper.m_ui_AnimationActivation;
        public InputActionMap Get() { return m_Wrapper.m_ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void SetCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterface != null)
            {
                @AnimationActivation.started -= m_Wrapper.m_UiActionsCallbackInterface.OnAnimationActivation;
                @AnimationActivation.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnAnimationActivation;
                @AnimationActivation.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnAnimationActivation;
            }
            m_Wrapper.m_UiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AnimationActivation.started += instance.OnAnimationActivation;
                @AnimationActivation.performed += instance.OnAnimationActivation;
                @AnimationActivation.canceled += instance.OnAnimationActivation;
            }
        }
    }
    public UiActions @ui => new UiActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUiActions
    {
        void OnAnimationActivation(InputAction.CallbackContext context);
    }
}
