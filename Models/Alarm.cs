using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class Alarm
{
    [JsonPropertyName("ID")]
    public int? Id {get; set;}

    [JsonPropertyName("DataObjectName")]
    public string DataObjectName {get; set;}

    [JsonPropertyName("DataObjectID")]
    public int? DataObjectID {get; set;}

    [JsonPropertyName("Transition")]
    public string Transition {get; set;}
    
    [JsonPropertyName("Acknowledged")]
    public bool Acknowledged {get; set;}

    [JsonPropertyName("AcknowledgeRequired")]
    public bool AcknowledgeRequired {get; set;}

    [JsonPropertyName("AcknowledgeRequested")]
    public bool AcknowledgeRequested {get; set;}

    [JsonPropertyName("DataObjectAddress")]
    public string DataObjectAddress {get; set;}

    [JsonPropertyName("DataObjectDescription")]
    public string DataObjectDescription {get; set;}
    
    [JsonPropertyName("DataObjectTypeCode")]
    public int? DataObjectTypeCode {get; set;}

    [JsonPropertyName("DataObjectTypeVendorID")]
    public int? DataObjectTypeVendorID {get; set;}

    [JsonPropertyName("DeviceId")]
    public int? DeviceId {get; set;}

    [JsonPropertyName("PropagateAcknowledge")]
    public bool PropagateAcknowledge {get; set;}
    
    [JsonPropertyName("DeviceName")]
    public string DeviceName {get; set;}

    [JsonPropertyName("DeviceDescription")]
    public string DeviceDescription {get; set;}

    [JsonPropertyName("AcknowledgeUser")]
    public string AcknowledgeUser {get; set;}

    [JsonPropertyName("AcknowledgeTimestamp")]
    public string AcknowledgeTimestamp {get; set;}

    [JsonPropertyName("NotifyTypeCode")]
    public int? NotifyTypeCode {get; set;}

    [JsonPropertyName("ConnectionId")]
    public int? ConnectionId {get; set;}

    [JsonPropertyName("ConnectionName")]
    public string ConnectionName {get; set;}

    [JsonPropertyName("ConnectionDescription")]
    public string ConnectionDescription {get; set;}

    [JsonPropertyName("DeviceTypeID")]
    public int? DeviceTypeID {get; set;}
    
    [JsonPropertyName("DeviceTypeDescription")]
    public string DeviceTypeDescription {get; set;}

    [JsonPropertyName("LocalTimestamp")]
    public string LocalTimestamp {get; set;}

    [JsonPropertyName("TimestampRawValue")]
    public string TimestampRawValue {get; set;}

    [JsonPropertyName("BacDateTime")]
    public string BacDateTime {get; set;}

    [JsonPropertyName("ReceivedTimestamp")]
    public string ReceivedTimestamp {get; set;}
    
    [JsonPropertyName("Priority")]
    public int? Priority {get; set;}

    [JsonPropertyName("NotificationClass")]
    public int? NotificationClass {get; set;}

    [JsonPropertyName("FromState")]
    public int? FromState {get; set;}

    [JsonPropertyName("ToState")]
    public int? ToState {get; set;}
    
    [JsonPropertyName("Message")]
    public string Message {get; set;}

    [JsonPropertyName("UnitName")]
    public string UnitName {get; set;}

    [JsonPropertyName("HasComments")]
    public bool HasComments {get; set;}

    [JsonPropertyName("FromUnknownObject")]
    public bool FromUnknownObject {get; set;}

    [JsonPropertyName("BacNetObjectIdentifier")]
    public int? BacNetObjectIdentifier {get; set;}

    [JsonPropertyName("BacNetDeviceIdentifier")]
    public int? BacNetDeviceIdentifier {get; set;}

    [JsonPropertyName("ProcessId")]
    public int? ProcessId {get; set;}

    [JsonPropertyName("EventValue")]
    public string EventValue {get; set;}

    [JsonPropertyName("CanAckObject")]
    public bool CanAckObject {get; set;}
    
    [JsonPropertyName("BindingTypeName")]
    public string BindingTypeName {get; set;}

    [JsonPropertyName("BacNetEventType")]
    public int? BacNetEventType {get; set;}

    [JsonPropertyName("SourceTimestamp")]
    public long SourceTimestamp {get; set;}

    [JsonPropertyName("SourceTag")]
    public string SourceTag {get; set;}

    [JsonPropertyName("EventSequence")]
    public int? EventSequence {get; set;}
    
    [JsonPropertyName("IsSystemGenerated")]
    public bool IsSystemGenerated {get; set;}

    [JsonPropertyName("Flag")]
    public bool Flag {get; set;}

    [JsonPropertyName("FlagTimestamp")]
    public string FlagTimestamp {get; set;}
}