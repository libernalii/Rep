using BLL.Models;
using DLL;
using DLL.Interfaces;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<SchooleContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True;").Options;
var context = new SchooleContext(options);
var _Srepository = new StudentRepository(context);
var _Trepository = new TeacherRepository(context);

Console.WriteLine("=== School Management System ===");
Console.WriteLine("1 - Add Student");
Console.WriteLine("2 - Delete Student");
Console.WriteLine("3 - Update Student");
Console.WriteLine("4 - Show All Students");
Console.WriteLine("5 - Search Student by ID");
Console.WriteLine("6 - Add Teacher");
Console.WriteLine("7 - Delete Teacher");
Console.WriteLine("8 - Update Teacher");
Console.WriteLine("9 - Show All Teachers");
Console.WriteLine("10 - Search Teacher by ID");
Console.WriteLine("0 - Exit");

string choice;

do
{
    Console.Write("\nEnter choice: ");
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                Console.Write("Enter student`s name: ");
                string name = Console.ReadLine();
                Console.Write("Enter student`s grade: ");
                string grade = Console.ReadLine();
                Console.Write("Enter student`s teacher id: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());

                Student student = new Student()
                {
                    Name = name,
                    Grade = grade,
                    TeacherId = teacherId,
                };
                await _Srepository.Add(student);
            }

            break;

        case "6":
            {
                Console.Write("Enter teacher`s name: ");
                string name = Console.ReadLine();
                Console.Write("Enter teacher`s subject: ");
                string subject = Console.ReadLine();

                Teacher teacher = new Teacher()
                {
                    Name = name,
                    Subject = subject,
                };
                await _Trepository.Add(teacher);
            }

            break;

        case "2":
            {
                Console.Write("Enter number student for deleted: ");
                Student[] student = await _Srepository.GetAll();
                for (int i = 0; i < student.Length; i++)
                {
                    Console.WriteLine($"{i}: {student[i].Name} - {student[i].Grade} - {student[i].TeacherId}");
                }
                int id = Convert.ToInt32(Console.ReadLine());
                await _Srepository.Delete(await _Srepository.GetById(student[id].Id));
            }
            break;

        case "7":
            {
                Console.Write("Enter number teacher for deleted: ");
                Teacher[] teacher = await _Trepository.GetAll();
                for (int i = 0; i < teacher.Length; i++)
                {
                    Console.WriteLine($"{i}: {teacher[i].Name} - {teacher[i].Subject}");
                }
                int id = Convert.ToInt32(Console.ReadLine());
                await _Trepository.Delete(await _Trepository.GetById(teacher[id].Id));
            }
            break;

        case "3":
            {
                Console.Write("Enter number student for updated: ");
                Student[] students = await _Srepository.GetAll();
                for (int i = 0; i < students.Length; i++)
                {
                    Console.WriteLine($"{i}: {students[i].Name} - {students[i].Grade} - {students[i].TeacherId}");
                }
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter student`s name: ");
                string name = Console.ReadLine();
                Console.Write("Enter student`s grade: ");
                string grade = Console.ReadLine();
                Console.Write("Enter student`s teacher id: ");
                int teacherId = Convert.ToInt32(Console.ReadLine());

                Student student = new Student()
                {
                    Id = id,
                    Name = name,
                    Grade = grade,
                    TeacherId = teacherId,
                };
                await _Srepository.Update(id, student);
            }
            break;

        case "8":
            {
                Console.Write("Enter number teacher for updated: ");
                Teacher[] teachers = await _Trepository.GetAll();
                for (int i = 0; i < teachers.Length; i++)
                {
                    Console.WriteLine($"{i}: {teachers[i].Name} - {teachers[i].Subject}");
                }
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter teacher`s name: ");
                string name = Console.ReadLine();
                Console.Write("Enter teacher`s subject: ");
                string subject = Console.ReadLine();

                Teacher teacher = new Teacher()
                {
                    Name = name,
                    Subject = subject,
                };
                await _Trepository.Update(id, teacher);
            }
            break;

        case "4":
            {
                Student[] student = await _Srepository.GetAll();
                for (int i = 0; i < student.Length; i++)
                {
                    Console.WriteLine($"{i}: {student[i].Name} - {student[i].Grade} - {student[i].TeacherId}");
                }
            }
            break;

        case "9":
            {
                Teacher[] teacher = await _Trepository.GetAll();
                for (int i = 0; i < teacher.Length; i++)
                {
                    Console.WriteLine($"{i}: {teacher[i].Name} - {teacher[i].Subject}");
                }
            }
            break;

        case "5":
            {
                Console.Write("Enter number student for search: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await _Srepository.GetById(id);
            }
            break;

        case "10":
            {
                Console.Write("Enter number teacher for search: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await _Trepository.GetById(id);
            }
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }

} while (choice != "0");
