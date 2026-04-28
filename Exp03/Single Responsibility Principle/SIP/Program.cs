namespace SIP
{

    // Only stores student data
    class Student
    {
        public string Name;
    }

    // Only saves student data
    class StudentRepository
    {
        public void Save(Student s)
        {
            Console.WriteLine("Saving to database...");
        }
    }

    // Only prints student data
    class StudentPrinter
    {
        public void Print(Student s)
        {
            Console.WriteLine("Printing report for " + s.Name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.Name = "Rahul";

            StudentRepository repo = new StudentRepository();
            repo.Save(s);

            StudentPrinter printer = new StudentPrinter();
            printer.Print(s);
        }
    }
}
