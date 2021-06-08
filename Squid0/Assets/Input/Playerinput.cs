// GENERATED AUTOMATICALLY FROM 'Assets/Input/Playerinput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Playerinput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Playerinput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Playerinput"",
    ""maps"": [
        {
            ""name"": ""Squid"",
            ""id"": ""5283b7fa-f764-4d9b-8a0b-bed30348e130"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""6b74926c-a94c-4156-8ba9-def475113c36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Button"",
                    ""id"": ""8d3ec810-0223-4b43-9f66-f5f6b88aa755"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveY"",
                    ""type"": ""Button"",
                    ""id"": ""ed5714ed-951a-4c51-bd13-5151b4e4fd34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpeedUp"",
                    ""type"": ""Button"",
                    ""id"": ""ae6bd08c-79a4-421f-9678-10dd82cb68d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowDown"",
                    ""type"": ""Button"",
                    ""id"": ""1b7216be-7a42-43d7-a192-7b46047160e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""6074432b-9d7c-408b-bc80-c0367ea65785"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cf6a5cd8-1e09-442a-9493-f1bcc39955c9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left/Right"",
                    ""id"": ""6ecc1334-fe0a-49bd-bdd8-4257811ea048"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c3289830-45c9-4a11-85b4-d3ae14e3117f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d61a8efc-65ee-4669-b080-47ee3cf6e1c8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Up/Down"",
                    ""id"": ""6b7aa7ae-6a65-4d7b-8229-4cf8d14b1307"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3c6aeeba-a5dd-44a8-bd6a-87224d609e2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""225e7258-57e9-4a6b-88f4-f2f85eceabd3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a3e5ecd-fc8e-494a-a021-4904c75bac03"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60127a20-6187-4768-89f1-902db1ad5cd8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""7798befe-5a16-4169-8b4c-dd12e00d3d31"",
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
                    ""id"": ""84eb4701-0e22-4b94-a8a1-8c0750279c83"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b4047d71-fac7-446d-ac5d-f493f777f67c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b1f5e7a0-bd7a-487c-ad79-0520e6268b88"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""040cfd62-fdf2-405c-8d4d-33174bfe406e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""2463cce4-3ce0-4006-a8d3-3b8dd98de3e3"",
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
                    ""id"": ""f2341a6f-3dc4-4021-b646-5a045176e9d9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d6bc6df-48ae-4691-b92d-17ba1b85ddca"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fa71582-2104-43be-b459-57bed3da248e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""136aa1c6-827e-4b59-b286-e8319f17771f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyoard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyoard and Mouse"",
            ""bindingGroup"": ""Keyoard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Squid
        m_Squid = asset.FindActionMap("Squid", throwIfNotFound: true);
        m_Squid_Fire = m_Squid.FindAction("Fire", throwIfNotFound: true);
        m_Squid_MoveX = m_Squid.FindAction("MoveX", throwIfNotFound: true);
        m_Squid_MoveY = m_Squid.FindAction("MoveY", throwIfNotFound: true);
        m_Squid_SpeedUp = m_Squid.FindAction("SpeedUp", throwIfNotFound: true);
        m_Squid_SlowDown = m_Squid.FindAction("SlowDown", throwIfNotFound: true);
        m_Squid_Movement = m_Squid.FindAction("Movement", throwIfNotFound: true);
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

    // Squid
    private readonly InputActionMap m_Squid;
    private ISquidActions m_SquidActionsCallbackInterface;
    private readonly InputAction m_Squid_Fire;
    private readonly InputAction m_Squid_MoveX;
    private readonly InputAction m_Squid_MoveY;
    private readonly InputAction m_Squid_SpeedUp;
    private readonly InputAction m_Squid_SlowDown;
    private readonly InputAction m_Squid_Movement;
    public struct SquidActions
    {
        private @Playerinput m_Wrapper;
        public SquidActions(@Playerinput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Squid_Fire;
        public InputAction @MoveX => m_Wrapper.m_Squid_MoveX;
        public InputAction @MoveY => m_Wrapper.m_Squid_MoveY;
        public InputAction @SpeedUp => m_Wrapper.m_Squid_SpeedUp;
        public InputAction @SlowDown => m_Wrapper.m_Squid_SlowDown;
        public InputAction @Movement => m_Wrapper.m_Squid_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Squid; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SquidActions set) { return set.Get(); }
        public void SetCallbacks(ISquidActions instance)
        {
            if (m_Wrapper.m_SquidActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_SquidActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_SquidActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_SquidActionsCallbackInterface.OnFire;
                @MoveX.started -= m_Wrapper.m_SquidActionsCallbackInterface.OnMoveX;
                @MoveX.performed -= m_Wrapper.m_SquidActionsCallbackInterface.OnMoveX;
                @MoveX.canceled -= m_Wrapper.m_SquidActionsCallbackInterface.OnMoveX;
                @MoveY.started -= m_Wrapper.m_SquidActionsCallbackInterface.OnMoveY;
                @MoveY.performed -= m_Wrapper.m_SquidActionsCallbackInterface.OnMoveY;
                @MoveY.canceled -= m_Wrapper.m_SquidActionsCallbackInterface.OnMoveY;
                @SpeedUp.started -= m_Wrapper.m_SquidActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.performed -= m_Wrapper.m_SquidActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.canceled -= m_Wrapper.m_SquidActionsCallbackInterface.OnSpeedUp;
                @SlowDown.started -= m_Wrapper.m_SquidActionsCallbackInterface.OnSlowDown;
                @SlowDown.performed -= m_Wrapper.m_SquidActionsCallbackInterface.OnSlowDown;
                @SlowDown.canceled -= m_Wrapper.m_SquidActionsCallbackInterface.OnSlowDown;
                @Movement.started -= m_Wrapper.m_SquidActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SquidActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SquidActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_SquidActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @MoveX.started += instance.OnMoveX;
                @MoveX.performed += instance.OnMoveX;
                @MoveX.canceled += instance.OnMoveX;
                @MoveY.started += instance.OnMoveY;
                @MoveY.performed += instance.OnMoveY;
                @MoveY.canceled += instance.OnMoveY;
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
                @SlowDown.started += instance.OnSlowDown;
                @SlowDown.performed += instance.OnSlowDown;
                @SlowDown.canceled += instance.OnSlowDown;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public SquidActions @Squid => new SquidActions(this);
    private int m_KeyoardandMouseSchemeIndex = -1;
    public InputControlScheme KeyoardandMouseScheme
    {
        get
        {
            if (m_KeyoardandMouseSchemeIndex == -1) m_KeyoardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyoard and Mouse");
            return asset.controlSchemes[m_KeyoardandMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ISquidActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnMoveX(InputAction.CallbackContext context);
        void OnMoveY(InputAction.CallbackContext context);
        void OnSpeedUp(InputAction.CallbackContext context);
        void OnSlowDown(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
