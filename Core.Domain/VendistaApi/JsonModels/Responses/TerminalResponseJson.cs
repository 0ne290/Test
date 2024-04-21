using Newtonsoft.Json;

namespace Core.Domain.VendistaApi.JsonModels.Responses;

public class TerminalResponseJson
{
    [JsonProperty("bank_id")]
    public string? BankId { get; set; }
    
    [JsonProperty("serial_number")]
    public string? SerialNumber { get; set; }
    
    [JsonProperty("version")]
    public int Version { get; set; }
    
    [JsonProperty("fw_type")]
    public int FwType { get; set; }
    
    [JsonProperty("gsm_operator")]
    public string? GsmOperator { get; set; }
    
    [JsonProperty("gsm_rssi")]
    public int GsmRssi { get; set; }
    
    [JsonProperty("imei")]
    public long Imei { get; set; }
    
    [JsonProperty("partner_id")]
    public int PartnerId { get; set; }
    
    [JsonProperty("partner_name")]
    public string? PartnerName { get; set; }
    
    [JsonProperty("external_server_id")]
    public int? ExternalServerId { get; set; }
    
    [JsonProperty("last_online_time")]
    public string? LastOnlineTime { get; set; }
    
    [JsonProperty("last24_hours_online")]
    public int Last24HoursOnline { get; set; }
    
    [JsonProperty("last_hour_online")]
    public int LastHourOnline { get; set; }
    
    [JsonProperty("sber_qrid")]
    public string? SberGrid { get; set; }
    
    [JsonProperty("auto_cancel_timeout")]
    public int AutoCancelTimeout { get; set; }
    
    [JsonProperty("bonus_percent")]
    public float? BonusPercent { get; set; }
    
    [JsonProperty("qr_discount_percent")]
    public float QrDiscountPercent { get; set; }
    
    [JsonProperty("send_cash")]
    public bool SendCash { get; set; }
    
    [JsonProperty("send_cashless")]
    public bool SendCashless { get; set; }
    
    [JsonProperty("type")]
    public int Type { get; set; }
    
    [JsonProperty("sim_balance")]
    public int SimBalance { get; set; }
    
    [JsonProperty("sim_number")]
    public long? SimNumber { get; set; }
    
    [JsonProperty("paid_sim")]
    public bool PaidSim { get; set; }
    
    [JsonProperty("bootloader_version")]
    public int BootloaderVersion { get; set; }
    
    [JsonProperty("min_pay_server")]
    public int MinPayServer { get; set; }
    
    [JsonProperty("success_message")]
    public string? SuccessMessage { get; set; }
    
    [JsonProperty("success_message_timeout")]
    public int SuccessMessageTimeout { get; set; }
    
    [JsonProperty("machine_id")]
    public int MachineId { get; set; }
    
    [JsonProperty("ping")]
    public int Ping { get; set; }
    
    [JsonProperty("preffered_port")]
    public int? PrefferedPort { get; set; }
    
    [JsonProperty("disable_firmware_updates")]
    public bool DisableFirmwareUpdates { get; set; }
    
    [JsonProperty("comment")]
    public string? Comment { get; set; }
    
    [JsonProperty("owner_id")]
    public int OwnerId { get; set; }
    
    [JsonProperty("longitude")]
    public double Longitude { get; set; }
    
    [JsonProperty("latitude")]
    public double Latitude { get; set; }
    
    [JsonProperty("owner_name")]
    public string? OwnerName { get; set; }
    
    [JsonProperty("color")]
    public string? Color { get; set; }
    
    [JsonProperty("id")]
    public int Id { get; set; }
}