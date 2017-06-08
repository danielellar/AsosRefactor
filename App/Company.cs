namespace App
{
    public class Company : ICompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Classification Classification { get; set; }
    }
}