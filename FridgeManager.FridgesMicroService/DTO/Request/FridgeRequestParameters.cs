namespace FridgesService.DTO.Request
{
    public class FridgeRequestParameters : RequestParameters
    {
        public string OwnerEmail { get; set; }

        public bool OwnerEmailConfirmed { get; set; }

        public bool OwnerMailingConfirmed { get; set; }
    }
}
