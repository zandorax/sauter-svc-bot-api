using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class Alarm
{
    [JsonPropertyName("ID")]
    public string? Id {get; set;}

    [JsonPropertyName("DataObjectName")]
    public string? DataObjectName {get; set;}

    [JsonPropertyName("DataObjectID")]
    public string? DataObjectID {get; set;}

    [JsonPropertyName("Transition")]
    public string? Transition {get; set;}
    
    [JsonPropertyName("Acknowledged")]
    public string? Acknowledged {get; set;}

    [JsonPropertyName("AcknowledgeRequired")]
    public string? AcknowledgeRequired {get; set;}

    [JsonPropertyName("AcknowledgeRequested")]
    public string? AcknowledgeRequested {get; set;}

    [JsonPropertyName("DataObjectAddress")]
    public string? DataObjectAddress {get; set;}

    [JsonPropertyName("DataObjectDescription")]
    public string? DataObjectDescription {get; set;}
    
    [JsonPropertyName("DataObjectTypeCode")]
    public string? DataObjectTypeCode {get; set;}

    [JsonPropertyName("DataObjectTypeVendorID")]
    public string? DataObjectTypeVendorID {get; set;}

    [JsonPropertyName("DeviceId")]
    public string? DeviceId {get; set;}

    [JsonPropertyName("PropagateAcknowledge")]
    public string? PropagateAcknowledge {get; set;}
    
    [JsonPropertyName("DeviceName")]
    public string? DeviceName {get; set;}

    [JsonPropertyName("DeviceDescription")]
    public string? DeviceDescription {get; set;}

    [JsonPropertyName("AcknowledgeUser")]
    public string? AcknowledgeUser {get; set;}

    [JsonPropertyName("AcknowledgeTimestamp")]
    public string? AcknowledgeTimestamp {get; set;}

    [JsonPropertyName("NotifyTypeCode")]
    public string? NotifyTypeCode {get; set;}

    [JsonPropertyName("ConnectionId")]
    public string? ConnectionId {get; set;}

    [JsonPropertyName("ConnectionName")]
    public string? ConnectionName {get; set;}

    [JsonPropertyName("ConnectionDescription")]
    public string? ConnectionDescription {get; set;}

    [JsonPropertyName("DeviceTypeID")]
    public string? DeviceTypeID {get; set;}
    
    [JsonPropertyName("DeviceTypeDescription")]
    public string? DeviceTypeDescription {get; set;}

    [JsonPropertyName("LocalTimestamp")]
    public string? LocalTimestamp {get; set;}

    [JsonPropertyName("TimestampRawValue")]
    public string? TimestampRawValue {get; set;}

    [JsonPropertyName("BacDateTime")]
    public string? BacDateTime {get; set;}

    [JsonPropertyName("ReceivedTimestamp")]
    public string? ReceivedTimestamp {get; set;}
    
    [JsonPropertyName("Priority")]
    public string? Priority {get; set;}

    [JsonPropertyName("NotificationClass")]
    public string? NotificationClass {get; set;}

    [JsonPropertyName("FromState")]
    public string? FromState {get; set;}

    [JsonPropertyName("ToState")]
    public string? ToState {get; set;}
    
    [JsonPropertyName("Message")]
    public string? Message {get; set;}

    [JsonPropertyName("UnitName")]
    public string? UnitName {get; set;}

    [JsonPropertyName("HasComments")]
    public string? HasComments {get; set;}

    [JsonPropertyName("FromUnknownObject")]
    public string? FromUnknownObject {get; set;}

    [JsonPropertyName("BacNetObjectIdentifier")]
    public string? BacNetObjectIdentifier {get; set;}

    [JsonPropertyName("BacNetDeviceIdentifier")]
    public string? BacNetDeviceIdentifier {get; set;}

    [JsonPropertyName("ProcessId")]
    public string? ProcessId {get; set;}

    [JsonPropertyName("EventValue")]
    public string? EventValue {get; set;}

    [JsonPropertyName("CanAckObject")]
    public string? CanAckObject {get; set;}
    
    [JsonPropertyName("BindingTypeName")]
    public string? BindingTypeName {get; set;}

    [JsonPropertyName("BacNetEventType")]
    public string? BacNetEventType {get; set;}

    [JsonPropertyName("SourceTimestamp")]
    public string? SourceTimestamp {get; set;}

    [JsonPropertyName("SourceTag")]
    public string? SourceTag {get; set;}

    [JsonPropertyName("EventSequence")]
    public string? EventSequence {get; set;}
    
    [JsonPropertyName("IsSystemGenerated")]
    public string? IsSystemGenerated {get; set;}

    [JsonPropertyName("Flag")]
    public string? Flag {get; set;}

    [JsonPropertyName("FlagTimestamp")]
    public string? FlagTimestamp {get; set;}

}