using System;

public class Teacher
{
    public Teacher(string fN, string lN)
    {
        this.firstName = fN;
        this.lastName = lN;
    }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int id { get; set; }
}