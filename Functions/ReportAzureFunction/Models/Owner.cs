namespace ReportAzureFunction.Models
{
    internal class Owner
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Owner owner)
            {
                return UserName == owner.UserName && Email == owner.Email;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (UserName + Email).GetHashCode();
        }
    }
}
