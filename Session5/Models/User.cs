namespace Session5.Models
{
    public class User:BasicUser
    {
        public int id { get; set; }
        public int userTypeId { get; set; }
        public string fullName { get; set; }
        public bool gender { get; set; }
        public string birthDate { get; set; }
        public int familyCount { get; set; }


    }
}