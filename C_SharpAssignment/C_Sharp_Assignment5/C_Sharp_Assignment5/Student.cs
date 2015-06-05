using System;

public class Student
{
    public Student(string fN, string lN)
    {
        this.firstName = fN;
        this.lastName = lN;
    }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string birthday { get; set; }
    public string addressLine1 { get; set; }
    public string addressLine2 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public int postal_or_Zip { get; set; }
    public string country { get; set; }
    public bool male { get; set; }
    public float height { get; set; }
    public float weight { get; set; }
}