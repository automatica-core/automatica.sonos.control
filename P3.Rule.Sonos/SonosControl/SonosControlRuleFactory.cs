using System;
using Automatica.Core.Base.Templates;
using Automatica.Core.EF.Models;
using Automatica.Core.Rule;
using RuleInterfaceDirection = Automatica.Core.Base.Templates.RuleInterfaceDirection;

namespace P3.Rule.Sonos.SonosControl;

public class SonosControlRuleFactory : RuleFactory
{
    public override Version RuleVersion => new Version(0, 2, 0, 1);

    public override bool InDevelopmentMode => true;

    public override string RuleName => "SonosControl";
    public override Guid RuleGuid => new Guid("550c0290-40e3-4d60-b016-3588d2a367fe");

    //Inputs
    public static readonly Guid PlayPauseTrigger = new Guid("93a1e9b7-77df-41ff-a02e-55722d3281ab");
    public static readonly Guid PauseTrigger = new Guid("8cc610dd-235e-4f7c-accf-9c1624c0e35f");
    public static readonly Guid Volume = new Guid("473461b1-f28b-4159-a85b-1ec824a808a6");

    public static readonly Guid VolumeIncrement = new Guid("63fd6575-1c29-4537-b26f-f3d795bd4220");
    public static readonly Guid VolumeDecrement = new Guid("efdc7c97-f6da-4b64-a1f8-cb8ae576620d");
    public static readonly Guid Next = new Guid("1049fcc8-ecd8-43cd-be15-c351eadb75be");
    public static readonly Guid RadioStationInput = new Guid("c24e12b1-79a1-4cc4-a926-b46bfa181625");

    //Params
    public static readonly Guid VolumeOnPlay = new Guid("c1af8a31-094b-4411-9db3-1cca9ee73235");
    public static readonly Guid RadioStation = new Guid("01bf3fb1-cac8-43c4-95c9-c024fde1a2af");
    public static readonly Guid MaxVolume = new Guid("ac7e676e-d562-4f38-b66b-4581a44bd9ba");


    //Outputs
    public static readonly Guid PlayOutputStatus = new Guid("e182d7b3-3644-47c6-899f-4b1d1afe1348");
    public static readonly Guid PauseOutputStatus = new Guid("caf3ee10-a41e-4c60-97f7-b86eb71cfb20");
    public static readonly Guid VolumeOutputStatus = new Guid("fc9b4105-ca37-46a2-afa0-89c281d5b30a");
    public static readonly Guid RadioStationOutputValue = new Guid("9a12a267-338c-4a48-9d7a-5af4fe8189be");
    public static readonly Guid NextOutput = new Guid("2aa90a39-8410-4e26-b707-96d7a5f10342");

    public static readonly long DefaultVolume = 10;
    public static readonly long DefaultRadioStation = 8007;


    public override void InitTemplates(IRuleTemplateFactory factory)
    {
        factory.CreateRuleTemplate(RuleGuid, "SONOS_CONTROL.NAME", "SONOS_CONTROL.DESCRIPTION", "sonos.control", "SONOS.NAME", 100, 100);

        factory.CreateParameterRuleInterfaceTemplate(RadioStation, "SONOS_CONTROL.RADIO_STATION.NAME",
            "SONOS_CONTROL.RADIO_STATION.DESCRIPTION", RuleGuid, 1, RuleInterfaceParameterDataType.Integer, DefaultRadioStation);
        factory.CreateParameterRuleInterfaceTemplate(VolumeOnPlay, "SONOS_CONTROL.VOLUME_ON_START.NAME",
            "SONOS_CONTROL.VOLUME_ON_START.DESCRIPTION", RuleGuid, 2, RuleInterfaceParameterDataType.Integer, DefaultVolume);
        factory.CreateParameterRuleInterfaceTemplate(MaxVolume, "SONOS_CONTROL.MAX_VOLUME.NAME",
            "SONOS_CONTROL.MAX_VOLUME.DESCRIPTION", RuleGuid, 3, RuleInterfaceParameterDataType.Integer, 100);


        factory.CreateRuleInterfaceTemplate(PlayPauseTrigger, "SONOS_CONTROL.PLAY_PAUSE.NAME", "SONOS_CONTROL.PLAY_PAUSE.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 1);
        factory.CreateRuleInterfaceTemplate(PauseTrigger, "SONOS_CONTROL.PAUSE_INPUT_STATUS.NAME", "SONOS_CONTROL.PAUSE_INPUT_STATUS.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 2);
        factory.CreateRuleInterfaceTemplate(Volume, "SONOS_CONTROL.VOLUME.NAME", "SONOS_CONTROL.VOLUME.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 3);
        factory.CreateRuleInterfaceTemplate(VolumeIncrement, "SONOS_CONTROL.VOLUME_INCREMENT.NAME", "SONOS_CONTROL.VOLUME_INCREMENT.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 4);
        factory.CreateRuleInterfaceTemplate(VolumeDecrement, "SONOS_CONTROL.VOLUME_DECREMENT.NAME", "SONOS_CONTROL.VOLUME_DECREMENT.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 5);
        factory.CreateRuleInterfaceTemplate(Next, "SONOS_CONTROL.NEXT.NAME", "SONOS_CONTROL.NEXT.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 6);
        factory.CreateRuleInterfaceTemplate(RadioStationInput, "SONOS_CONTROL.RADIO_STATION.NAME", "SONOS_CONTROL.RADIO_STATION.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Input, 0, 7);

        factory.CreateRuleInterfaceTemplate(PlayOutputStatus, "SONOS_CONTROL.PLAY_OUTPUT_STATE.NAME", "SONOS_CONTROL.PLAY_OUTPUT_STATE.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Output, 0, 1);
        factory.CreateRuleInterfaceTemplate(PauseOutputStatus, "SONOS_CONTROL.PAUSE_OUTPUT_STATE.NAME", "SONOS_CONTROL.PAUSE_OUTPUT_STATE.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Output, 0, 2);
        factory.CreateRuleInterfaceTemplate(VolumeOutputStatus, "SONOS_CONTROL.VOLUME_OUTPUT_STATE.NAME", "SONOS_CONTROL.VOLUME_OUTPUT_STATE.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Output, 0, 3);
        factory.CreateRuleInterfaceTemplate(RadioStationOutputValue, "SONOS_CONTROL.RADIO_STATION_OUTPUT_VALUE.NAME", "SONOS_CONTROL.RADIO_STATION_OUTPUT_VALUE.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Output, 0, 4);
        factory.CreateRuleInterfaceTemplate(NextOutput, "SONOS_CONTROL.NEXT.NAME", "SONOS_CONTROL.NEXT.DESCRIPTION", RuleGuid, RuleInterfaceDirection.Output, 0, 5);

    }

    public override IRule CreateRuleInstance(IRuleContext context)
    {
        return new SonosControlRule(context);
    }
}