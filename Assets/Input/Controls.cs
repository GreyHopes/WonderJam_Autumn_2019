// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""6859a69a-3012-4802-bbf9-56768ee93839"",
            ""actions"": [
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""Value"",
                    ""id"": ""5267418b-2410-46ff-a100-877a456df384"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""5fcb3caf-cab9-4e37-be40-a646674f8575"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleUpgradeMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2f1dca60-cd7b-40d9-9f00-1a60eaf2a251"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextShip"",
                    ""type"": ""Button"",
                    ""id"": ""662bfd94-ebac-4c5a-b33c-94d51cd40aca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousShip"",
                    ""type"": ""Button"",
                    ""id"": ""eff1a88f-d85a-4b6d-91f3-6071e1bc0b7d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""feac8575-bc12-475b-bddc-99b1c14776fd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c31df0d1-ed01-40a9-842f-bae7ce089fdf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64146ecc-872e-409b-b8a9-62b03fc5b2c8"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bdab853-4f61-4a98-8a2b-e478a8a814cc"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88920655-53fc-4905-959c-03af2f68f4d0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleUpgradeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""132c5619-8e2c-4475-bc0e-0401fc9fd354"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleUpgradeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4908ae6a-87c4-4db6-83de-a685c013dd1f"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleUpgradeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1020d574-badb-43bd-92c7-85d1cdb1e8c0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleUpgradeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67256be0-9c49-4b9a-9af6-596aee9670ac"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""3be28d81-355d-42b0-8d14-631e64e91600"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1eb242f3-53f0-45c1-9c36-ead6a73571c6"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bde1dbc2-86cc-4365-976d-03abe78db5d0"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""33db49f4-d3cc-4fdf-a94b-c95ec665f088"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ab40b2f7-4bc9-444e-a87e-6aeeb6d9a2ca"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""d3611bd9-0fe0-401b-b048-3959cba3b6ba"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b9344dd2-728f-45c7-bb17-f3849529e589"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d5e841a8-c1e2-43bd-b37d-85bfd33de054"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0410b088-15c8-41dc-9c90-02e678c06862"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d330f2d1-3e4d-4838-8402-710ecd58e69a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""400b000d-171d-46a8-acce-506305c509c1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6349dd91-084a-4443-a806-a1c59a026680"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0710b6c0-cda4-47ba-84d5-4c284ed1f093"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10e98b84-db5a-4e99-810b-0b35e5e4d9e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fa1f416b-843b-41f8-9d4e-51e0041b3e5a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ec26f400-fd83-4c86-9750-fcf070fe06e4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8e0a040-a958-48ee-8933-a6c795514353"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ScrollUp"",
                    ""id"": ""f3fd4b00-1f89-4e05-95c1-164762403d99"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextShip"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e7634f97-0d4b-46f0-9af0-f639312bb941"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0ec41a3f-b767-4c90-b661-cf62b375f6a0"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ScrollDown"",
                    ""id"": ""e216d577-4de8-4ff6-9f39-6edb4260a9b6"",
                    ""path"": ""1DAxis(minValue=0)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousShip"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6fc978fc-1962-4f4c-98c3-4f5a8100e607"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""PreviousShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""83c448f3-8d01-404f-85eb-3e2539da3c8b"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousShip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UiControls"",
            ""id"": ""890ab56a-e593-47e1-b046-be2186b8be37"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""085e9cc4-f924-4085-9497-861a707b8cf6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""70d3c112-7bbe-419f-9239-8335c9226e45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bcecfbb5-3cc0-4fce-a89c-c3f7e28ea49b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""1baaac52-9a4f-42ad-94a8-338d6e6c4b37"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9c05e054-7e0a-4234-9891-aa15f9355cf3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""b7bfe4c9-e703-41f7-aef1-19d8eb549afd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AdvanceDialogue"",
                    ""type"": ""Button"",
                    ""id"": ""f9bdee09-f994-4fac-a3ec-a7d26d8a5973"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SkipDialogue"",
                    ""type"": ""Button"",
                    ""id"": ""8f45fa3e-43eb-43b6-ae8e-132a30d66a93"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""083fd704-4b2b-4ae6-8853-22f0e5884d2c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a80d7370-642b-428b-8f81-8e5fbc30fe34"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acf247a7-b11a-49fd-a85d-20313ebfbe89"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""7994c44b-e794-46a8-b903-780b1f371007"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8efb8210-1260-485e-b9c7-6800b609502a"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8c67e8f4-9699-4b5d-a812-0478a09efd28"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d94fe4ec-b80c-496c-bb6c-4a2189b3cdd5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""32fb6ee1-810a-4e62-85a3-9640f43994b6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""71e48071-a11e-460d-abc9-68d8e6381401"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""45cbec33-1d3b-4335-be58-d1a28aca6a53"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eaa9b3f4-45b5-4765-97b5-9d59747ee25a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""378edf4f-95a2-4cd5-b6bc-4b7d35bb7423"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9bb5a2cc-3fee-414d-bc31-6d665a555aae"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""4137aa2b-4f2a-48e6-b23d-e73448d10df0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b9aa50ec-b8ef-4c4e-b4c0-b883d0961ef5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5ca7b928-d91c-4bc1-80c1-214398867d42"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e966cdf2-1a36-47c4-a6bd-03caef5ebeb1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89b06f04-74ce-4339-998b-14a160a6acf2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2e776099-8c93-470b-8dca-515bd0e38347"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a84f2a1b-63fd-43e6-bf7d-46f6cf091be4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d6c2639-8ef0-4e23-880e-20ac25af8bf2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2655b673-403d-4074-b19a-be1851b91bb2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e68e9ddc-b069-49e1-b89a-d09bf93a7b86"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""RightStick"",
                    ""id"": ""7a2955f1-0f4b-4f24-8611-ff4900ffbcaa"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1b3931ea-ac43-4cc0-9983-e6aa55121aa8"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c838480b-8b78-4ac7-8216-16c0b845bf30"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MouseScroll"",
                    ""id"": ""bad9d30a-08a3-44a6-95cd-fbd0329ed62b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d53c2431-5ddf-4ac6-99cd-f5e0a0b2f7fb"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""82398411-28ee-4a99-acf7-1d9674bd906f"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""24743083-c08a-44fe-815c-f81602aad9b7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a00af0a-815e-4cec-b70b-2316dd6a102e"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea515f18-5b02-4791-992b-227fa296740f"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cadc8341-db02-4bf1-ab62-5918c0f4efbe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""244c2288-2ee6-465a-a9f8-f3c2bb7c63e7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvanceDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9371e68d-73de-4518-8b21-8da46eeddcbc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvanceDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1b794be-4026-4de5-89c9-3f937acc076a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdvanceDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3021498d-9a2c-41d3-8f3d-cd6b75e15377"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""942802ad-07fb-48c1-bd2c-2bd820cd9a00"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0fd7dd4-f264-40ad-aebf-5650f5e9ee12"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipDialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_MoveCursor = m_GameControls.FindAction("MoveCursor", throwIfNotFound: true);
        m_GameControls_Select = m_GameControls.FindAction("Select", throwIfNotFound: true);
        m_GameControls_ToggleUpgradeMenu = m_GameControls.FindAction("ToggleUpgradeMenu", throwIfNotFound: true);
        m_GameControls_NextShip = m_GameControls.FindAction("NextShip", throwIfNotFound: true);
        m_GameControls_PreviousShip = m_GameControls.FindAction("PreviousShip", throwIfNotFound: true);
        // UiControls
        m_UiControls = asset.FindActionMap("UiControls", throwIfNotFound: true);
        m_UiControls_Click = m_UiControls.FindAction("Click", throwIfNotFound: true);
        m_UiControls_AltClick = m_UiControls.FindAction("AltClick", throwIfNotFound: true);
        m_UiControls_MiddleClick = m_UiControls.FindAction("MiddleClick", throwIfNotFound: true);
        m_UiControls_Back = m_UiControls.FindAction("Back", throwIfNotFound: true);
        m_UiControls_Move = m_UiControls.FindAction("Move", throwIfNotFound: true);
        m_UiControls_Scroll = m_UiControls.FindAction("Scroll", throwIfNotFound: true);
        m_UiControls_AdvanceDialogue = m_UiControls.FindAction("AdvanceDialogue", throwIfNotFound: true);
        m_UiControls_SkipDialogue = m_UiControls.FindAction("SkipDialogue", throwIfNotFound: true);
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

    // GameControls
    private readonly InputActionMap m_GameControls;
    private IGameControlsActions m_GameControlsActionsCallbackInterface;
    private readonly InputAction m_GameControls_MoveCursor;
    private readonly InputAction m_GameControls_Select;
    private readonly InputAction m_GameControls_ToggleUpgradeMenu;
    private readonly InputAction m_GameControls_NextShip;
    private readonly InputAction m_GameControls_PreviousShip;
    public struct GameControlsActions
    {
        private Controls m_Wrapper;
        public GameControlsActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCursor => m_Wrapper.m_GameControls_MoveCursor;
        public InputAction @Select => m_Wrapper.m_GameControls_Select;
        public InputAction @ToggleUpgradeMenu => m_Wrapper.m_GameControls_ToggleUpgradeMenu;
        public InputAction @NextShip => m_Wrapper.m_GameControls_NextShip;
        public InputAction @PreviousShip => m_Wrapper.m_GameControls_PreviousShip;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterface != null)
            {
                MoveCursor.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMoveCursor;
                MoveCursor.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMoveCursor;
                MoveCursor.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMoveCursor;
                Select.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSelect;
                Select.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSelect;
                Select.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSelect;
                ToggleUpgradeMenu.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnToggleUpgradeMenu;
                ToggleUpgradeMenu.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnToggleUpgradeMenu;
                ToggleUpgradeMenu.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnToggleUpgradeMenu;
                NextShip.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnNextShip;
                NextShip.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnNextShip;
                NextShip.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnNextShip;
                PreviousShip.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnPreviousShip;
                PreviousShip.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnPreviousShip;
                PreviousShip.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnPreviousShip;
            }
            m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                MoveCursor.started += instance.OnMoveCursor;
                MoveCursor.performed += instance.OnMoveCursor;
                MoveCursor.canceled += instance.OnMoveCursor;
                Select.started += instance.OnSelect;
                Select.performed += instance.OnSelect;
                Select.canceled += instance.OnSelect;
                ToggleUpgradeMenu.started += instance.OnToggleUpgradeMenu;
                ToggleUpgradeMenu.performed += instance.OnToggleUpgradeMenu;
                ToggleUpgradeMenu.canceled += instance.OnToggleUpgradeMenu;
                NextShip.started += instance.OnNextShip;
                NextShip.performed += instance.OnNextShip;
                NextShip.canceled += instance.OnNextShip;
                PreviousShip.started += instance.OnPreviousShip;
                PreviousShip.performed += instance.OnPreviousShip;
                PreviousShip.canceled += instance.OnPreviousShip;
            }
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);

    // UiControls
    private readonly InputActionMap m_UiControls;
    private IUiControlsActions m_UiControlsActionsCallbackInterface;
    private readonly InputAction m_UiControls_Click;
    private readonly InputAction m_UiControls_AltClick;
    private readonly InputAction m_UiControls_MiddleClick;
    private readonly InputAction m_UiControls_Back;
    private readonly InputAction m_UiControls_Move;
    private readonly InputAction m_UiControls_Scroll;
    private readonly InputAction m_UiControls_AdvanceDialogue;
    private readonly InputAction m_UiControls_SkipDialogue;
    public struct UiControlsActions
    {
        private Controls m_Wrapper;
        public UiControlsActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_UiControls_Click;
        public InputAction @AltClick => m_Wrapper.m_UiControls_AltClick;
        public InputAction @MiddleClick => m_Wrapper.m_UiControls_MiddleClick;
        public InputAction @Back => m_Wrapper.m_UiControls_Back;
        public InputAction @Move => m_Wrapper.m_UiControls_Move;
        public InputAction @Scroll => m_Wrapper.m_UiControls_Scroll;
        public InputAction @AdvanceDialogue => m_Wrapper.m_UiControls_AdvanceDialogue;
        public InputAction @SkipDialogue => m_Wrapper.m_UiControls_SkipDialogue;
        public InputActionMap Get() { return m_Wrapper.m_UiControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiControlsActions set) { return set.Get(); }
        public void SetCallbacks(IUiControlsActions instance)
        {
            if (m_Wrapper.m_UiControlsActionsCallbackInterface != null)
            {
                Click.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnClick;
                Click.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnClick;
                Click.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnClick;
                AltClick.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnAltClick;
                AltClick.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnAltClick;
                AltClick.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnAltClick;
                MiddleClick.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnMiddleClick;
                MiddleClick.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnMiddleClick;
                MiddleClick.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnMiddleClick;
                Back.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnBack;
                Back.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnBack;
                Back.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnBack;
                Move.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnMove;
                Scroll.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnScroll;
                Scroll.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnScroll;
                Scroll.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnScroll;
                AdvanceDialogue.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnAdvanceDialogue;
                AdvanceDialogue.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnAdvanceDialogue;
                AdvanceDialogue.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnAdvanceDialogue;
                SkipDialogue.started -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnSkipDialogue;
                SkipDialogue.performed -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnSkipDialogue;
                SkipDialogue.canceled -= m_Wrapper.m_UiControlsActionsCallbackInterface.OnSkipDialogue;
            }
            m_Wrapper.m_UiControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Click.started += instance.OnClick;
                Click.performed += instance.OnClick;
                Click.canceled += instance.OnClick;
                AltClick.started += instance.OnAltClick;
                AltClick.performed += instance.OnAltClick;
                AltClick.canceled += instance.OnAltClick;
                MiddleClick.started += instance.OnMiddleClick;
                MiddleClick.performed += instance.OnMiddleClick;
                MiddleClick.canceled += instance.OnMiddleClick;
                Back.started += instance.OnBack;
                Back.performed += instance.OnBack;
                Back.canceled += instance.OnBack;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Scroll.started += instance.OnScroll;
                Scroll.performed += instance.OnScroll;
                Scroll.canceled += instance.OnScroll;
                AdvanceDialogue.started += instance.OnAdvanceDialogue;
                AdvanceDialogue.performed += instance.OnAdvanceDialogue;
                AdvanceDialogue.canceled += instance.OnAdvanceDialogue;
                SkipDialogue.started += instance.OnSkipDialogue;
                SkipDialogue.performed += instance.OnSkipDialogue;
                SkipDialogue.canceled += instance.OnSkipDialogue;
            }
        }
    }
    public UiControlsActions @UiControls => new UiControlsActions(this);
    public interface IGameControlsActions
    {
        void OnMoveCursor(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnToggleUpgradeMenu(InputAction.CallbackContext context);
        void OnNextShip(InputAction.CallbackContext context);
        void OnPreviousShip(InputAction.CallbackContext context);
    }
    public interface IUiControlsActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnAltClick(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnAdvanceDialogue(InputAction.CallbackContext context);
        void OnSkipDialogue(InputAction.CallbackContext context);
    }
}
