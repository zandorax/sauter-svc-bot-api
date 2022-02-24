using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class AlarmDto : IComparable<AlarmDto>
{
    [JsonIgnore]
    [JsonPropertyName("ID")]
    public int? Id {get; set;}
    
    [JsonPropertyName("DataObjectName")]
    public string DataObjectName {get; set;}
    
    [JsonPropertyName("DataObjectID")]
    public int? DataObjectID {get; set;}

    [JsonIgnore]
    [JsonPropertyName("Transition")]
    public string Transition {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("Acknowledged")]
    public bool Acknowledged {get; set;}

    [JsonIgnore]
    [JsonPropertyName("AcknowledgeRequired")]
    public bool AcknowledgeRequired {get; set;}

    [JsonIgnore]
    [JsonPropertyName("AcknowledgeRequested")]
    public bool AcknowledgeRequested {get; set;}

    [JsonIgnore]
    [JsonPropertyName("DataObjectAddress")]
    public string DataObjectAddress {get; set;}

    
    [JsonPropertyName("DataObjectDescription")]
    public string DataObjectDescription {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("DataObjectTypeCode")]
    public int? DataObjectTypeCode {get; set;}

    [JsonIgnore]
    [JsonPropertyName("DataObjectTypeVendorID")]
    public int? DataObjectTypeVendorID {get; set;}

    [JsonIgnore]
    [JsonPropertyName("DeviceId")]
    public int? DeviceId {get; set;}

    [JsonIgnore]
    [JsonPropertyName("PropagateAcknowledge")]
    public bool PropagateAcknowledge {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("DeviceName")]
    public string DeviceName {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("DeviceDescription")]
    public string DeviceDescription {get; set;}

    [JsonIgnore]
    [JsonPropertyName("AcknowledgeUser")]
    public string AcknowledgeUser {get; set;}

    [JsonIgnore]
    [JsonPropertyName("AcknowledgeTimestamp")]
    public string AcknowledgeTimestamp {get; set;}

    [JsonIgnore]
    [JsonPropertyName("NotifyTypeCode")]
    public int? NotifyTypeCode {get; set;}

    [JsonIgnore]
    [JsonPropertyName("ConnectionId")]
    public int? ConnectionId {get; set;}

    [JsonIgnore]
    [JsonPropertyName("ConnectionName")]
    public string ConnectionName {get; set;}

    [JsonIgnore]
    [JsonPropertyName("ConnectionDescription")]
    public string ConnectionDescription {get; set;}

    [JsonIgnore]
    [JsonPropertyName("DeviceTypeID")]
    public int? DeviceTypeID {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("DeviceTypeDescription")]
    public string DeviceTypeDescription {get; set;}

    [JsonIgnore]
    [JsonPropertyName("LocalTimestamp")]
    public string LocalTimestamp {get; set;}

    [JsonIgnore]
    [JsonPropertyName("TimestampRawValue")]
    public string TimestampRawValue {get; set;}

    [JsonIgnore]
    [JsonPropertyName("BacDateTime")]
    public string BacDateTime {get; set;}

    
    [JsonPropertyName("ReceivedTimestamp")]
    public string ReceivedTimestamp {get; set;}
    
    
    [JsonPropertyName("Priority")]
    public int? Priority {get; set;}

    [JsonIgnore]
    [JsonPropertyName("NotificationClass")]
    public int? NotificationClass {get; set;}

    
    [JsonPropertyName("FromState")]
    public int? FromState {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("ToState")]
    public int? ToState {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("Message")]
    public string Message {get; set;}

    [JsonIgnore]
    [JsonPropertyName("UnitName")]
    public string UnitName {get; set;}

    [JsonIgnore]
    [JsonPropertyName("HasComments")]
    public bool HasComments {get; set;}

    [JsonIgnore]
    [JsonPropertyName("FromUnknownObject")]
    public bool FromUnknownObject {get; set;}

    [JsonIgnore]
    [JsonPropertyName("BacNetObjectIdentifier")]
    public int? BacNetObjectIdentifier {get; set;}

    [JsonIgnore]
    [JsonPropertyName("BacNetDeviceIdentifier")]
    public int? BacNetDeviceIdentifier {get; set;}

    [JsonIgnore]
    [JsonPropertyName("ProcessId")]
    public int? ProcessId {get; set;}

    [JsonIgnore]
    [JsonPropertyName("EventValue")]
    public string EventValue {get; set;}

    [JsonIgnore]
    [JsonPropertyName("CanAckObject")]
    public bool CanAckObject {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("BindingTypeName")]
    public string BindingTypeName {get; set;}

    [JsonIgnore]
    [JsonPropertyName("BacNetEventType")]
    public int? BacNetEventType {get; set;}

    [JsonIgnore]
    [JsonPropertyName("SourceTimestamp")]
    public long SourceTimestamp {get; set;}

    [JsonIgnore]
    [JsonPropertyName("SourceTag")]
    public string SourceTag {get; set;}

    [JsonIgnore]
    [JsonPropertyName("EventSequence")]
    public int? EventSequence {get; set;}
    
    [JsonIgnore]
    [JsonPropertyName("IsSystemGenerated")]
    public bool IsSystemGenerated {get; set;}

    [JsonIgnore]
    [JsonPropertyName("Flag")]
    public bool Flag {get; set;}

    [JsonIgnore]
    [JsonPropertyName("FlagTimestamp")]
    public string FlagTimestamp {get; set;}
    
    public int CompareTo(AlarmDto? compareAlarmDto)
    {
        return compareAlarmDto == null ? 1 : SourceTimestamp.CompareTo(compareAlarmDto.SourceTimestamp);
    }
}