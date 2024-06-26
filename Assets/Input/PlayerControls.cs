//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Flight"",
            ""id"": ""2cc04e8e-7194-453b-81d5-cbd3c2851dce"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""fd63cbb7-2071-4864-a276-911a4015c961"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Propel"",
                    ""type"": ""Button"",
                    ""id"": ""92b65855-c6af-45b5-a0ea-dfa529eaca51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""a679189c-1386-4f9a-9c13-4d4412f20b3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""bc1a2ac6-4076-4179-b885-d0ee82602354"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b391ea3c-eda4-45c0-b0e5-97de79285e33"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0b05fb3d-4ec2-4744-8a85-3b58302a42b8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9399d894-4144-4be7-8e13-40ca351b8c4d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Propel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e91d2ca9-22d3-4a20-954c-f4970346eb3e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""0f0b58fc-174f-4d9c-800f-057f417fc274"",
            ""actions"": [
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""7757ea55-8605-47d1-8a3b-54697c1e86c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""79af6422-20e1-4209-8fa3-2ed9ae6e3a60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blink"",
                    ""type"": ""Button"",
                    ""id"": ""b9da3aa6-49f2-4e32-9281-6c5b5e49359c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a43beeab-7b34-46e6-b349-1d3f72491a7c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf57c277-05cd-457b-b22c-46864d0a9196"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48a647e6-27c4-4c31-93a7-3392072cfb1e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blink"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Flight
        m_Flight = asset.FindActionMap("Flight", throwIfNotFound: true);
        m_Flight_Rotate = m_Flight.FindAction("Rotate", throwIfNotFound: true);
        m_Flight_Propel = m_Flight.FindAction("Propel", throwIfNotFound: true);
        m_Flight_Brake = m_Flight.FindAction("Brake", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Shield = m_Combat.FindAction("Shield", throwIfNotFound: true);
        m_Combat_Fire = m_Combat.FindAction("Fire", throwIfNotFound: true);
        m_Combat_Blink = m_Combat.FindAction("Blink", throwIfNotFound: true);
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

    // Flight
    private readonly InputActionMap m_Flight;
    private List<IFlightActions> m_FlightActionsCallbackInterfaces = new List<IFlightActions>();
    private readonly InputAction m_Flight_Rotate;
    private readonly InputAction m_Flight_Propel;
    private readonly InputAction m_Flight_Brake;
    public struct FlightActions
    {
        private @PlayerControls m_Wrapper;
        public FlightActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Flight_Rotate;
        public InputAction @Propel => m_Wrapper.m_Flight_Propel;
        public InputAction @Brake => m_Wrapper.m_Flight_Brake;
        public InputActionMap Get() { return m_Wrapper.m_Flight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlightActions set) { return set.Get(); }
        public void AddCallbacks(IFlightActions instance)
        {
            if (instance == null || m_Wrapper.m_FlightActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FlightActionsCallbackInterfaces.Add(instance);
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Propel.started += instance.OnPropel;
            @Propel.performed += instance.OnPropel;
            @Propel.canceled += instance.OnPropel;
            @Brake.started += instance.OnBrake;
            @Brake.performed += instance.OnBrake;
            @Brake.canceled += instance.OnBrake;
        }

        private void UnregisterCallbacks(IFlightActions instance)
        {
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Propel.started -= instance.OnPropel;
            @Propel.performed -= instance.OnPropel;
            @Propel.canceled -= instance.OnPropel;
            @Brake.started -= instance.OnBrake;
            @Brake.performed -= instance.OnBrake;
            @Brake.canceled -= instance.OnBrake;
        }

        public void RemoveCallbacks(IFlightActions instance)
        {
            if (m_Wrapper.m_FlightActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFlightActions instance)
        {
            foreach (var item in m_Wrapper.m_FlightActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FlightActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FlightActions @Flight => new FlightActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
    private readonly InputAction m_Combat_Shield;
    private readonly InputAction m_Combat_Fire;
    private readonly InputAction m_Combat_Blink;
    public struct CombatActions
    {
        private @PlayerControls m_Wrapper;
        public CombatActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shield => m_Wrapper.m_Combat_Shield;
        public InputAction @Fire => m_Wrapper.m_Combat_Fire;
        public InputAction @Blink => m_Wrapper.m_Combat_Blink;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void AddCallbacks(ICombatActions instance)
        {
            if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
            @Shield.started += instance.OnShield;
            @Shield.performed += instance.OnShield;
            @Shield.canceled += instance.OnShield;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Blink.started += instance.OnBlink;
            @Blink.performed += instance.OnBlink;
            @Blink.canceled += instance.OnBlink;
        }

        private void UnregisterCallbacks(ICombatActions instance)
        {
            @Shield.started -= instance.OnShield;
            @Shield.performed -= instance.OnShield;
            @Shield.canceled -= instance.OnShield;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Blink.started -= instance.OnBlink;
            @Blink.performed -= instance.OnBlink;
            @Blink.canceled -= instance.OnBlink;
        }

        public void RemoveCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICombatActions instance)
        {
            foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface IFlightActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnPropel(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnShield(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnBlink(InputAction.CallbackContext context);
    }
}
