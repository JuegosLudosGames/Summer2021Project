// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/ControlMapping.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace summer2021.csharp.controls
{
    public class @ControlMapping : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ControlMapping()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlMapping"",
    ""maps"": [
        {
            ""name"": ""CharacterControl"",
            ""id"": ""bdff680a-2c6d-4ca7-aac5-6c660f60deba"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""289f257d-f608-435e-be8d-004cc8aa8c61"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3e66c09d-95b9-490c-988e-2639ecbedc13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d9d6d470-3847-4be2-b52c-ff28040155cc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""908155a7-32f6-4a57-af47-cd470cbd9216"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bc3cddde-847f-4858-93c2-7858d28f2d3d"",
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
                    ""id"": ""560d68ba-84f4-4cd7-9d28-074abb9f9fd4"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e92b4b3-5b41-4e7f-8bf7-504c88dc1733"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbf8f807-c673-4691-a5cf-e2f326a3f187"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CharacterControl
            m_CharacterControl = asset.FindActionMap("CharacterControl", throwIfNotFound: true);
            m_CharacterControl_Movement = m_CharacterControl.FindAction("Movement", throwIfNotFound: true);
            m_CharacterControl_Jump = m_CharacterControl.FindAction("Jump", throwIfNotFound: true);
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

        // CharacterControl
        private readonly InputActionMap m_CharacterControl;
        private ICharacterControlActions m_CharacterControlActionsCallbackInterface;
        private readonly InputAction m_CharacterControl_Movement;
        private readonly InputAction m_CharacterControl_Jump;
        public struct CharacterControlActions
        {
            private @ControlMapping m_Wrapper;
            public CharacterControlActions(@ControlMapping wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_CharacterControl_Movement;
            public InputAction @Jump => m_Wrapper.m_CharacterControl_Jump;
            public InputActionMap Get() { return m_Wrapper.m_CharacterControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterControlActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterControlActions instance)
            {
                if (m_Wrapper.m_CharacterControlActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CharacterControlActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_CharacterControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public CharacterControlActions @CharacterControl => new CharacterControlActions(this);
        public interface ICharacterControlActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
    }
}
