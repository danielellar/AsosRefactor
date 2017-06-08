namespace App
{
    public interface ICompany
    {
        int Id { get; set; }
        string Name { get; set; }
        Classification Classification { get; set; }
    }
}